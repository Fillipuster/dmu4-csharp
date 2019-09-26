using Microsoft.Win32;
using SudokuLib;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SudokuPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ISudoku sudoku;
        private ISudoku solution;
        private Label selectedCell;
        private int selectedRow;
        private int selectedColumn;

        public MainWindow()
        {
            InitializeComponent();

            // DEV
            LoadSudoku(SudokuHelper.FromHumanString("1...48....5....9....6...3.....57.2..8.3.........9............4167..........2....."));
            // /DEV
        }

        private void LoadSudoku(ISudoku sudokuToLoad, string name = "a Sudoku.")
        {
            sudokuGrid.Children.RemoveRange(0, sudokuGrid.Children.Count);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int cell = sudokuToLoad[i, j];

                    Label cellLabel = new Label
                    {
                        Content = cell != 0 ? cell.ToString() : " ",
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        FontSize = 32,
                        MinWidth = 50,
                        MinHeight = 50,
                        Tag = Tuple.Create(i, j)
                    };

                    // "Click" handler.
                    cellLabel.MouseLeftButtonUp += OnCellLeftClick;

                    Border cellBorder = new Border
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1),
                        Child = cellLabel
                    };

                    // Add our border, containing our label (i.e. cell)
                    sudokuGrid.Children.Add(cellBorder);
                }
            }

            sudoku = sudokuToLoad;
            solution = sudokuToLoad.Clone().Solve();

            statusLeft.Content = "Loaded " + name;
        }

        //
        // Cell selection
        //

        private void SelectCell(Label cell, int i, int j)
        {
            if (selectedCell != null)
                selectedCell.Background = Brushes.Transparent;

            cell.Background = Brushes.LightBlue;

            selectedCell = cell;
            selectedRow = i;
            selectedColumn = j;
        }

        private void OnCellLeftClick(object sender, MouseButtonEventArgs e)
        {
            Label cell = (Label)sender;
            Tuple<int, int> coordinate = (Tuple<int, int>)cell.Tag;
            SelectCell(cell, coordinate.Item1, coordinate.Item2);
        }

        // Arrow key selection.
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // To be implemented (hopefully)
        }

        //
        // Cell value submission
        //

        private void AttemptToSubmit(byte submission)
        {
            selectedCell.Background = Brushes.Transparent;

            if (solution[selectedRow, selectedColumn] == submission)
            {
                sudoku.SetNumberAt(selectedRow, selectedColumn, submission);
            }
            else
            {
                selectedCell.Background = Brushes.Red;
                selectedCell.Content = submission != 0 ? submission.ToString() : " ";

                statusLeft.Content = $"Nope! That {submission} doesn't go there. Try something else.";
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            //System.Windows.Input.Key.D1 = 35
            //System.Windows.Input.Key.D9 = 43
            if (e.Key == Key.Delete || e.Key == Key.Back)
                AttemptToSubmit(0);

            if (e.Key.CompareTo(Key.D1) >= 0 && e.Key.CompareTo(Key.D9) <= 0)
                AttemptToSubmit((byte)(e.Key.GetHashCode() - 34));
        }

        //
        // Menu item events
        //

        private void MenuOpenCollection_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files(*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string[] sudokuStrings = File.ReadAllLines(openFileDialog.FileName);
                ISudoku[] sudokus = SudokuHelper.FromHumanStringArray(sudokuStrings);
                CollectionViewerWindow popup = new CollectionViewerWindow(sudokus, openFileDialog.FileName);
                popup.Title = openFileDialog.FileName;
                popup.OnSudokuSelected += LoadSudoku;
                popup.Show();
            }
        }

        private void MenuOpenSingle_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "sudoku files (*.sud)|*.sud";

            if (openFileDialog.ShowDialog() == true)
            {
                string sudokuString = File.ReadAllText(openFileDialog.FileName);
                LoadSudoku(SudokuHelper.FromHumanString(sudokuString), openFileDialog.FileName);
            }
        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "sudoku files (*.sud)|*.sud";
            if (saveFileDialog.ShowDialog() == true)
            {
                using (var file = saveFileDialog.OpenFile())
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            file.WriteByte(sudoku[i, j]);
                        }
                    }
                }
            }
        }
    }
}
