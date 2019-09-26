using SudokuLib;
using System.Windows;

namespace SudokuPlayer
{
    /// <summary>
    /// Interaction logic for CollectionViewerWindow.xaml
    /// </summary>
    public partial class CollectionViewerWindow : Window
    {
        public delegate void SudokuSelected(ISudoku sudoku);
        public event SudokuSelected OnSudokuSelected;

        private ISudoku[] sudokus;
        private int selected;

        public CollectionViewerWindow(ISudoku[] sudokus)
        {
            InitializeComponent();

            this.sudokus = sudokus;
            SelectSudoku(0);
            pagesLabel.Content = (sudokus.Length - 1).ToString();
        }

        private void SelectSudoku(int index)
        {
            if (index < 0 || index >= sudokus.Length)
                return;

            selected = index;
            sudokuLabel.Content = sudokus[index].ToHumanString();
            pageTextBox.Text = index.ToString();
        }

        private void PageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            int index;
            if (int.TryParse(pageTextBox.Text, out index))
            {
                SelectSudoku(index);
            }
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            SelectSudoku(selected - 1);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            SelectSudoku(selected + 1);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            OnSudokuSelected?.Invoke(sudokus[selected]);
            Close();
        }
    }
}
