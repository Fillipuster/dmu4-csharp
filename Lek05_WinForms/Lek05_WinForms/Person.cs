namespace Lek05_WinForms
{
    public class Person
    {
        public delegate string PersonToString(Person person);

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string firstName, string lastName, int age = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} ({Age})";
        }
    }
}
