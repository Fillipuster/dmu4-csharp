using Microsoft.Win32;
using SudokuLib;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SudokuPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadSudoku(SudokuFactory.CreateSudoku("012345678900000000000000000000000000000000000000000000000000000000000000000000000"));
        }

        private void LoadSudoku(ISudoku sudoku)
        {
            for (int i = 0; i < 81; i++)
            {
                var l = new Label();
                l.Content = i.ToString();

                var b = new Border();
                b.BorderBrush = Brushes.Black;
                b.BorderThickness = new Thickness(1);

                b.Child = l;
                sudokuGrid.Children.Add(b);
            }
        }

        private void MenuOpenCollection_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                string[] sudokuStrings = File.ReadAllLines(openFileDialog.FileName);
                ISudoku[] sudokus = SudokuHelper.FromHumanStringArray(sudokuStrings);
                CollectionViewerWindow popup = new CollectionViewerWindow(sudokus);
                popup.Title = openFileDialog.FileName;
                popup.Show();
            }
        }
    }
}
