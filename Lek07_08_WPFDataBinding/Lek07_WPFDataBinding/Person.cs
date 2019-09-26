using System.ComponentModel;

namespace Lek07_WPFDataBinding
{
    public partial class Person : INotifyPropertyChanged
    {
        private string name;
        private double weight;
        private int age;
        private int score;
        private bool accepted;

        public Person(string name, double weight, int age, int score = 0, bool accepted = false)
        {
            Name = name;
            Weight = weight;
            Age = age;
            Score = score;
            Accepted = accepted;
        }

        // Events
        public delegate void BMIChanged();
        public event BMIChanged BMIChangedEvent;

        public override string ToString()
        {
            return "Person: " + (accepted ? "✔" : "❌") + name + " (" + age + ")";
        }

    }

    public partial class Person
    {

        // Events act like lists of delegates.
        public event PropertyChangedEventHandler PropertyChanged;

        private void notifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                // Meaning calling the event will call all the added eventhandlers (i.e. PropertyChanged += myEventHandler)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ListBoxString
        {
            get
            {
                return (accepted ? "✔" : "❌") + name + " (" + age + ")";
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                // Call our method to fire the event to all listeners.
                notifyPropertyChanged("Name");
                notifyPropertyChanged("ListBoxString");
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                // We can avoid wrapping our event call in a method (notfyPropertyChanged), by calling directly from the mutator.
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Weight"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListBoxString"));
                notifyPropertyChanged("ListBoxString");
                BMIChangedEvent?.Invoke(); // Events
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Age"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListBoxString"));
                BMIChangedEvent?.Invoke(); // Events
            }
        }
        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Score"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListBoxString"));
            }
        }
        public bool Accepted
        {
            get { return accepted; }
            set
            {
                accepted = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Accepted"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListBoxString"));
            }
        }
    }
}
