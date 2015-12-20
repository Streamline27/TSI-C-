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

namespace Lab5_DataBind.form
{
    public partial class DbForm : Form
    {
        private const string DEFAULT_SOURCE_URL = "127.0.0.1";
        private const string DEFAULT_INITIAL_CATALOG = "cs_test";
        private const string DEFAULT_USERNAME = "root";
        private const string DEFAULT_PASSWORD = "root";

        private string SourceUrl { get; set; }
        private string InitialCatalog { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }

        private PersonDAO PersonDAO { get; set; }
        private IList<Person> People { get; set; }

        public DbForm(IList<Person> people)
        {
            InitializeComponent();
            PutDefaultConnectionParamsIntoTextboxes();
            AssignDefaultConnectionParams();

            People = people;
        }




        /* Form events */
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            RecieveConnectionParamsFromForm();
            PersonDAO = new SqlPersonDAO(SourceUrl, InitialCatalog, Username, Password);

            ToggleWorkingMode();
        }

        private void ToggleWorkingMode()
        {
            if (PersonDAO.IsConnected) EnableWorkingMode();
            else DisableWorkingMode();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            RefreshDataSource();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            PersonDAO.Insert(People);
            People.Clear();
            RefreshDataSource();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsGridEmpty()) return;

            Person person = GetPersonFromSelectedRow();
            PersonDAO.Delete(person);
            RefreshDataSource();
        }


        /* Private helper functions */
        private void AssignDefaultConnectionParams()
        {
            SourceUrl = DEFAULT_SOURCE_URL;
            InitialCatalog = DEFAULT_INITIAL_CATALOG;
            Username = DEFAULT_USERNAME;
            Password = DEFAULT_PASSWORD;
        }

        private void EnableButtons()
        {
            btnAddAll.Enabled = true;
            btnSelect.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void DisableButtons()
        {
            btnAddAll.Enabled = false;
            btnSelect.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void RefreshDataSource()
        {
            dbGridView.DataSource = PersonDAO.Select();
        }

        private void PutDefaultConnectionParamsIntoTextboxes()
        {
            tbxServer.Text = DEFAULT_SOURCE_URL;
            tbxSchema.Text = DEFAULT_INITIAL_CATALOG;
            tbxUser.Text = DEFAULT_USERNAME;
            tbxPass.Text = DEFAULT_PASSWORD;
        }

        private void RecieveConnectionParamsFromForm()
        {
            SourceUrl = tbxServer.Text;
            InitialCatalog = tbxSchema.Text;
            Username = tbxUser.Text;
            Password = tbxPass.Text;
        }

        private Person GetPersonFromSelectedRow()
        {
            var row = dbGridView.SelectedRows[0];
            var first = row.Cells[0].Value.ToString();
            var second = row.Cells[1].Value.ToString();

            var age = Convert.ToInt32(row.Cells[2].Value.ToString());
            Person person = new Person(first, second, age);
            return person;
        }

        private void DisableWorkingMode()
        {
            DisableButtons();
            dbGridView.DataSource = null;
        }

        private void EnableWorkingMode()
        {
            RefreshDataSource();
            EnableButtons();
        }

        private bool IsGridEmpty()
        {
            return (dbGridView.RowCount == 0);
        }


    }
}
