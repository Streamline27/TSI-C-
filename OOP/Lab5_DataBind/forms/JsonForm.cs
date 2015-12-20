using Lab5_DataBind.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_DataBind.forms
{
    public partial class JsonForm : Form
    {
        private PersonDAO personDAO { get; set; }
        private String DEF_PATH = "people.txt";
        private IList<Person> InputFormPeople { get; set; }


        /* Public interface methods */
        public JsonForm(IList<Person> people)
        {
            InitializeComponent();
            tbxFilePath.Text = DEF_PATH;
            InputFormPeople = people;
        }


        /* Form events */
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataSource();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            personDAO = new JsonPersonDAO(tbxFilePath.Text);
            ToggleWorkingMode();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsGridEmpty()) return;

            Person person = GetPersonFromSelectedRow();
            personDAO.Delete(person);
            RefreshDataSource();
        }

        private void btnFlush_Click(object sender, EventArgs e)
        {
            personDAO.Insert(InputFormPeople);
            InputFormPeople.Clear();
            RefreshDataSource();
        }


        /* Private helper methods */
        private void ToggleWorkingMode()
        {
            if (personDAO.IsConnected) EnableWorkinMode();
            else DisableWorkingMode();
        }

        private void DisableWorkingMode()
        {
            dbGridView.DataSource = null;
            DisableButtons();
        }

        private void EnableWorkinMode()
        {
            RefreshDataSource();
            EnableButtons();
        }

        private void RefreshDataSource()
        {
            dbGridView.DataSource = personDAO.Select();
        }

        private Person GetPersonFromSelectedRow()
        {
            var row = dbGridView.SelectedRows[0];

            String first = row.Cells["FirstName"].Value.ToString();
            String second = row.Cells["LastName"].Value.ToString();
            int age = Convert.ToInt32(row.Cells["Age"].Value.ToString());

            return new Person(first, second, age);
        }

        private void EnableButtons()
        {
            ToggleButtons(true);
        }

        private void DisableButtons()
        {
            ToggleButtons(false);
        }

        private void ToggleButtons(bool cond)
        {
            btnFlush.Enabled = cond;
            btnRefresh.Enabled = cond;
            btnDelete.Enabled = cond;
        }

        private bool IsGridEmpty()
        {
            return (dbGridView.RowCount == 0);
        }


    }
}
