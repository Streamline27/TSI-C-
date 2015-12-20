using Lab5_DataBind.dao;
using Lab5_DataBind.form;
using Lab5_DataBind.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_DataBind
{
    public partial class InputForm : Form
    {
        private IList<Person> PersonList { get; set; }
        private const string ILLEGAL_AGE_MSG = "Age must be a number.";
        private const string EMPTY_FIELD_MSG = "Some field is empty.";

        private DbForm dbForm { get; set; }
        private JsonForm jsonForm { get; set; }

        public InputForm()
        {
            InitializeComponent();
            PersonList = new BindingList<Person>();
            AttachDataSource(); // <-- DataBinding happens here
        }


        /* Form events */
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (SomeFieldIsEmpty()) return;
            if (!AgeIsNumber()) return;

            Person person = getPersonFromForm();

            if (PersonCanBeAdded(person)) PersonList.Add(person);
            
        }

        private bool PersonCanBeAdded(Person person)
        {
            if ((!checkBox1.Checked)&&(HasDublicate(person))) return false;
            else return true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            PersonList.Clear();
        }

        private void buttonDb_Click(object sender, EventArgs e)
        {
            if (radioJson.Checked)  RunJsonForm();
            if (radioMySql.Checked) RunMySqlForm();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows();
        }

        

        /* Private helper methods */
        private void AttachDataSource()
        {
            // Binds PersonList to dataGridView
            // Now every change in GridView are applied to List and vice versa.
            // Too see that you can change values of field in cells of Data Grid.
            // When items are added they are added only to list.
            // Data grid listens to events inside list and updates automatically.
            // This sort of object field binding is called data binding.

            var source = new BindingSource(PersonList, null);
            dataGridView.DataSource = source;
        }

        private Person getPersonFromForm()
        {
            return new Person(tbFirstName.Text, tbLastName.Text, GetInputedAge());
        }

        private int GetInputedAge()
        {
            int age;
            Int32.TryParse(tbAge.Text, out age);
            return age;          
        }

        private void RunMySqlForm()
        {
            dbForm = new DbForm(PersonList);
            dbForm.Show();
        }

        private void RunJsonForm()
        {
            jsonForm = new JsonForm(PersonList);
            jsonForm.Show();
        }

        private bool SomeFieldIsEmpty()
        {
            if (((IsEmpty(tbFirstName)) || (IsEmpty(tbLastName))) || (IsEmpty(tbAge)))
            {
                MessageBox.Show(EMPTY_FIELD_MSG);
                return true;
            }
            return false;
        }

        private bool IsEmpty(TextBox tb)
        {
            return String.IsNullOrWhiteSpace(tb.Text);
        }

        private bool AgeIsNumber()
        {
            int age;
            bool res = Int32.TryParse(tbAge.Text, out age);
            if (!res) MessageBox.Show(ILLEGAL_AGE_MSG);
            return res;
        }

        private bool HasDublicate(Person p)
        {
            foreach (var item in PersonList)
            {
                if (item.Equals(p)) return true;
            }
            return false;
        }

        private void DeleteSelectedRows()
        {
            foreach (DataGridViewRow item in this.dataGridView.SelectedRows)
            {
                dataGridView.Rows.RemoveAt(item.Index);
            }
        }

    }
}
