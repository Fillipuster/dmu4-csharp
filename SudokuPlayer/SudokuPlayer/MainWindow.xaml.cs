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

        private void LoadSudoku(ISudoku sudokuToLoad)
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
        }

        //
        // Cell selection
        //

        private void SelectCell(Label cell, int i, int j)
        {
            if (selectedCell != null)
            {
                selectedCell.Background = Brushes.Transparent;

                Border oldCellBorder = (Border)selectedCell.Parent;
                oldCellBorder.BorderBrush = Brushes.Black;
                oldCellBorder.BorderThickness = new Thickness(1);
            }

            Border cellBorder = (Border)cell.Parent;
            cellBorder.BorderBrush = Brushes.Blue;
            cellBorder.BorderThickness = new Thickness(2);

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

        //
        // Cell value submission
        //

        private void AttemptToSubmit(byte submission)
        {
            selectedCell.Background = Brushes.Transparent;

            if (solution[selectedRow, selectedColumn] != submission)
            {
                // Failed.
                selectedCell.Background = Brushes.Pink;
                statusLeft.Content = $"Nope! That {submission} doesn't go there. Try something else.";
                return;
            }

            sudoku.SetNumberAt(selectedRow, selectedColumn, submission);


            selectedCell.Content = submission != 0 ? submission.ToString() : " ";
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

            if (openFileDialog.ShowDialog() == true)
            {
                string[] sudokuStrings = File.ReadAllLines(openFileDialog.FileName);
                ISudoku[] sudokus = SudokuHelper.FromHumanStringArray(sudokuStrings);
                CollectionViewerWindow popup = new CollectionViewerWindow(sudokus);
                popup.Title = openFileDialog.FileName;
                popup.OnSudokuSelected += LoadSudoku;
                popup.Show();
            }
        }
    }
}
