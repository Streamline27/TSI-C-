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
        private string SOURCE_URL = "127.0.0.1";
        private string INITIAL_CATALOG = "cs_test";
        private string USERNAME = "root";
        private string PASSWORD = "root";

        private PersonDAO PersonDAO { get; set; }
        private IList<Person> People { get; set; }

        public DbForm(IList<Person> people)
        {
            InitializeComponent();
            PutConnectionParamsIntoTextboxes();
            People = people;
        }


        /********************/
        /*      Events      */
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            RecieveConnectionParamsFromForm();
            PersonDAO = new PersonDAOImpl(SOURCE_URL, INITIAL_CATALOG, USERNAME, PASSWORD);

            if (PersonDAO.IsConnected)
            {
                RefreshDataSource();
                EnableButtons();
            }
            else DisableButtons();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataSource();
        }

        private void btnFlush_Click(object sender, EventArgs e)
        {
            foreach (var person in People)
            {
                PersonDAO.Insert(person);
            }
            People.Clear();
            RefreshDataSource();
        }

        /**************************/
        // Private helper functions
        private void EnableButtons()
        {
            btnFlush.Enabled = true;
            btnRefresh.Enabled = true;
        }

        private void DisableButtons()
        {
            btnFlush.Enabled = false;
            btnRefresh.Enabled = false;
        }


        private void RefreshDataSource()
        {
            dbGridView.DataSource = PersonDAO.Select();
        }


        private void PutConnectionParamsIntoTextboxes()
        {
            tbxServer.Text = SOURCE_URL;
            tbxSchema.Text = INITIAL_CATALOG;
            tbxUser.Text = USERNAME;
            tbxPass.Text = PASSWORD;
        }

        private void RecieveConnectionParamsFromForm()
        {
            this.SOURCE_URL = tbxServer.Text;
            this.INITIAL_CATALOG = tbxSchema.Text;
            this.USERNAME = tbxUser.Text;
            this.PASSWORD = tbxPass.Text;
        }

    }
}
