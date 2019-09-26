using System.Windows;

namespace Lek07_WPFDataBinding
{
    /// <summary>
    /// Interaction logic for CreatePersonWindow.xaml
    /// </summary>
    public partial class CreatePersonWindow : Window
    {
        public delegate void PersonCreated(Person p);
        public event PersonCreated PersonCreatedEvent;

        public CreatePersonWindow()
        {
            InitializeComponent();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            int age;
            if (!int.TryParse(ageTxb.Text, out age))
            {
                return;
            }

            double weight;
            if (!double.TryParse(weightTxb.Text, out weight))
            {
                return;
            }

            PersonCreatedEvent?.Invoke(new Person(nameTxb.Text, weight, age));
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
