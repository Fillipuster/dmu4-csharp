using Microsoft.Win32;
using SudokuLib;
using System;
using System.Collections.Generic;
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
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //LoadSudoku(HumanSudokuFactory.FromString("1...48....5....9....6...3.....57.2..8.3.........9............4167..........2....."));
        }

        private bool ShouldColorCellAt(int i, int j)
        {
            if (i / 3 % 3 == 1)
            {
                // Middle row.
                return j / 3 % 3 != 1;
            }
            else
            {
                // Top and bottom row.
                return j / 3 % 3 == 1;
            }
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

                    // Alternate 3-cell group coloring.
                    Console.WriteLine(cell);
                    if (ShouldColorCellAt(i, j))
                        cellLabel.Background = Brushes.LightGray;

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

            UpdateStatistics();
        }

        //
        // Cell selection
        //

        private void SelectCell(Label cell, int i, int j)
        {
            if (selectedCell != null)
            {
                if (selectedCell.Background == Brushes.Pink)
                    selectedCell.Content = " ";

                selectedCell.Background = ShouldColorCellAt(selectedRow, selectedColumn) ? Brushes.LightGray : Brushes.Transparent;
            }

            cell.Background = Brushes.LightBlue;

            selectedCell = cell;
            selectedRow = i;
            selectedColumn = j;
        }

        private void OnCellLeftClick(object sender, MouseButtonEventArgs e)
        {
            Label cell = (Label)sender;
            SelectCell(cell, cell.GetRow(), cell.GetColumn());
        }

        //
        // Cell value submission
        //

        private void SetCell(Label cell, byte value)
        {
            cell.Content = value == 0 ? " " : value.ToString();
            sudoku[cell.GetRow(), cell.GetColumn()] = value;

            UpdateStatistics();
        }

        private void UpdateStatistics()
        {
            statusRight.Content = $"Cells {sudoku.NumberOfOpenCells()}/{sudoku.NumberOfFilledCells()} (empty/filled)";
        }

        private void AttemptToSubmit(byte submission)
        {
            if (selectedCell == null)
                return;

            selectedCell.Background = ShouldColorCellAt(selectedRow, selectedColumn) ? Brushes.LightGray : Brushes.Transparent;

            if (solution[selectedRow, selectedColumn] == submission)
            {
                // Submission success.
                SetCell(selectedCell, submission);

                statusLeft.Content = $"Successfully placed a {submission}.";

                selectedCell = null;

                if (sudoku.IsSolved())
                {
                    MessageBox.Show("🎉 Congratulations 🎉\nYou've solved the Sudoku!", "Sudoku solved!", MessageBoxButton.OK, MessageBoxImage.Information);
                    statusLeft.Content = $"Congratulations! You've solved the Sudoku 🎉";
                }
            }
            else
            {
                // Submission failed.
                selectedCell.Background = Brushes.Pink;
                selectedCell.Content = submission == 0 ? " " : submission.ToString();

                statusLeft.Content = $"Nope! That {submission} doesn't go there. Try something else.";
            }
        }

        private void ClearSelectedCell()
        {
            if (selectedCell != null)
            {
                SetCell(selectedCell, 0);
                statusLeft.Content = "Cleared cell.";
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            //System.Windows.Input.Key.D1 = 35
            //System.Windows.Input.Key.D9 = 43
            if (e.Key == Key.Delete || e.Key == Key.Back)
                ClearSelectedCell();

            if (e.Key >= Key.D1 && e.Key <= Key.D9)
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
                ISudoku[] sudokus = HumanSudokuFactory.FromArray(sudokuStrings);
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
                Console.WriteLine(sudokuString);
                try
                {
                    LoadSudoku(SudokuFactory.CreateSudoku(sudokuString.Trim()), openFileDialog.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("There was a problem opening the Sudoku.\nPlease ensure the Sudoku is solveable, and that the file is properly formatted.", "Failed opening Sudoku", MessageBoxButton.OK, MessageBoxImage.Error);
                    statusLeft.Content = "Failed to open Sudoku. Please ensure the Sudoku is solveable, and the file is properly formatted.";
                }
            }
        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "sudoku files (*.sud)|*.sud";
            if (saveFileDialog.ShowDialog() == true)
            {
                string sudokuString = string.Empty;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        sudokuString += sudoku[i, j];
                    }
                }

                File.WriteAllText(saveFileDialog.FileName, sudokuString);
            }
        }

        private void MenuSolveSudoku_Click(object sender, RoutedEventArgs e)
        {
            foreach (Border container in sudokuGrid.Children)
            {
                Label cell = (Label)container.Child;
                SetCell(cell, solution[cell.GetRow(), cell.GetColumn()]);
            }

            statusLeft.Content = "Computationally solved active Sudoku.";
        }

        private void MenuHint_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCell != null)
            {
                List<byte> possibleNums = sudoku.PossibleNumbers(selectedCell.GetRow(), selectedCell.GetColumn());
                string possibleNumsStr = string.Empty;

                if (possibleNums != null)
                {
                    for (int i = 0; i < possibleNums.Count; i++)
                    {
                        possibleNumsStr += possibleNums[i];
                        if (i < possibleNums.Count - 1)
                            possibleNumsStr += ", ";
                    }

                    statusLeft.Content = $"Possible numbers for selected cell are: {possibleNumsStr}.";
                }
                else
                {
                    statusLeft.Content = $"A number is already placed in the selected cell.";
                }

            }
            else
            {
                statusLeft.Content = "You have to select a cell to get a hint.";
            }
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?\nAny unsaved progress will be lost.", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                Application.Current.Shutdown();

        }
    }
}
