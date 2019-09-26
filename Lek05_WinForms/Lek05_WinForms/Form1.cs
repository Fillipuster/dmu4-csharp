using System.Windows.Forms;

namespace Lek05_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AddDummyItems();
        }

        private void AddDummyItems()
        {
            Person[] people = { new Person("Jonas", "Priestyard", 22), new Person("Michael", "Kragelund", 22), new Person("Torben", "Grove", 29), new Person("Frederik", "Sloth", 26), new Person("Morten", "Faber", 21) };
            leftList.Items.AddRange(people);
        }

        public void AddLeft(Person p)
        {
            leftList.Items.Add(p);

            lblStatus.Text = $"Added {p} to left list.";
        }

        public void AddRight(Person p)
        {
            rightList.Items.Add(p);

            lblStatus.Text = $"Added {p} to right list.";
        }

        private void ExitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void HelpToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("I'm afraid I cannot help you.", "Help"); // message, title
        }

        private void RemoveItemToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Person leftSelected = (Person)leftList.SelectedItem;
            Person rightSelected = (Person)rightList.SelectedItem;

            if (leftSelected != null)
            {
                leftList.Items.Remove(leftSelected);
                lblStatus.Text = $"Removed {leftSelected} from left list.";
            }
            else if (rightSelected != null)
            {
                rightList.Items.Remove(rightSelected);
                lblStatus.Text = $"Removed {rightSelected} from right list.";
            }
            else
            {
                lblStatus.Text = "Removed nothing. No item selected.";
            }
            rightList.Items.Remove(rightList.SelectedItem);
        }

        private void AddItemToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Form2 popup = new Form2(this);
            popup.Show();
            lblStatus.Text = "Add menu opened.";
        }

        private void MoveItemToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Person leftSelect = (Person)leftList.SelectedItem;
            Person rightSelected = (Person)rightList.SelectedItem;

            if (leftSelect != null)
            {
                rightList.Items.Add(leftSelect);
                leftList.Items.Remove(leftSelect);

                lblStatus.Text = $"Moved {leftSelect} to the right list.";
            }
            else if (rightSelected != null)
            {
                leftList.Items.Add(rightSelected);
                rightList.Items.Remove(rightSelected);

                lblStatus.Text = $"Moved {rightSelected} to the left list.";
            }
            else
            {
                lblStatus.Text = "Moved nothing. No item selected.";
            }
        }

        private void LeftList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            rightList.ClearSelected();
        }

        private void RightList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            leftList.ClearSelected();
        }
    }
}
