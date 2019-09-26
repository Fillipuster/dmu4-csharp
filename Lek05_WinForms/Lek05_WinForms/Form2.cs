using System.Windows.Forms;

namespace Lek05_WinForms
{
    public partial class Form2 : Form
    {
        private Form1 mother;

        public Form2(Form1 mother)
        {
            InitializeComponent();

            this.mother = mother;
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void BtnAddLeft_Click(object sender, System.EventArgs e)
        {
            int age;
            if (int.TryParse(txfAge.Text, out age))
            {
                mother.AddLeft(new Person(txfFirstName.Text, txfLastName.Text, age));
            }
            else
            {
                mother.AddLeft(new Person(txfFirstName.Text, txfLastName.Text));
            }

            Close();
        }

        private void BtnAddRight_Click(object sender, System.EventArgs e)
        {
            int age;
            if (int.TryParse(txfAge.Text, out age))
            {
                mother.AddRight(new Person(txfFirstName.Text, txfLastName.Text, age));
            }
            else
            {
                mother.AddRight(new Person(txfFirstName.Text, txfLastName.Text));
            }

            Close();
        }
    }
}
