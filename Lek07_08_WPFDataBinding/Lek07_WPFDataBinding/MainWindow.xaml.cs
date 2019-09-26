using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Lek07_WPFDataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Person> people = new ObservableCollection<Person>() {
            new Person("Frederik Sloth", 82, 25, 12),
            new Person("Michael Kragelund", 87, 23, 28),
            new Person("Jan Grove", 91, 28, 41),
            new Person("Mulle Meck", 79, 41, 3),
            new Person("Hyacinth Bucket", 98, 58, 0)
        };

        public MainWindow()
        {
            InitializeComponent();

            Binding binding = new Binding();
            binding.Source = people;
            binding.Path = new PropertyPath("Age");
            binding.Mode = BindingMode.OneWayToSource;
            ageTxb.SetBinding(TextBox.TextProperty, binding);

            gridPnl.DataContext = people;
            listView.ItemsSource = people;

            // Events
            // Test of event exercise.
            Person mulle = new Person("Mulle Meck", 79, 41, 3);
            mulle.BMIChangedEvent += MullesBMIHarÆndretSig; // Subscribe to the event.

            System.Console.WriteLine("mulle.Age += 1");
            mulle.Age += 1;
            System.Console.WriteLine();

            System.Console.WriteLine("mulle.Accepted = true");
            mulle.Accepted = true;
            System.Console.WriteLine();

            System.Console.WriteLine("mulle.Weight *= 2");
            mulle.Weight *= 2;
            System.Console.WriteLine();

            mulle.BMIChangedEvent -= MullesBMIHarÆndretSig; // Unsubscribe to the event.

            // We've unsubscribed, so this shouldn't fire the event.
            System.Console.WriteLine("mulle.Weight -= 3");
            mulle.Weight -= 3;
            System.Console.WriteLine();
        }

        private void MullesBMIHarÆndretSig()
        {
            System.Console.WriteLine("Mulles BMI har ændret sig!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreatePersonWindow popup = new CreatePersonWindow();
            popup.PersonCreatedEvent += people.Add;
            popup.Show();

            //// The lazy way...
            //Person newPerson = new Person("<new person>", 0, 0);
            //people.Add(newPerson);
            //listView.SelectedItems.Clear();
            //listView.SelectedItems.Add(newPerson);
        }
    }
}
