using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_DataBind
{
    class PersonDAO
    {
        private delegate void commandDelegate(MySqlConnection con);

        private string SourceUrl { get; set; }
        private string InitialCatalog { get; set; }
        private string Username {get; set; }
        private string Password { get; set; }

        private string SELECT_QUERY = "SELECT first_name, last_name, age FROM People";
        private string INSERT_FIRTS_PART = "INSERT INTO People (first_name, last_name, age) ";

        public bool IsConnected { get; private set; }

        public PersonDAO(string sourceUrl, String initialCatalog, String username, String password){
            this.SourceUrl = sourceUrl;
            this.InitialCatalog = initialCatalog;
            this.Username = username;
            this.Password = password;
            IsConnected = false;

            ExecuteInTransaction((connection) => { });
        }

        public void selectPeople(DataGridView gridView)
        {        
            // Lambda expression
            ExecuteInTransaction((connection)=>{
                // Execute sql query
                MySqlCommand command = new MySqlCommand(SELECT_QUERY, connection);
                MySqlDataReader sqlDataReader = command.ExecuteReader();

                // Fill gridView with data
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);
                gridView.DataSource = dataTable; 
            });
        }

        public void addPerson(Person person)
        {
            string insert_query = INSERT_FIRTS_PART+ getSecondInsertPart(person);
            // Lambda expression
            ExecuteInTransaction((connection) =>
            {
                // Execute sql query
                MySqlCommand command = new MySqlCommand(insert_query, connection);
                MySqlDataReader sqlDataReader = command.ExecuteReader();

            });
        }


        /****************************/
        /* Private helper functions */
        private void ExecuteInTransaction(commandDelegate command)
        {
            MySqlConnection dbConnection = null;
            try
            {
                // Opening database connection
                dbConnection = new MySqlConnection(getConnectionString());
                dbConnection.Open();

                // Executing massed command
                command(dbConnection);
                IsConnected = true;
            }
            catch
            {
                MessageBox.Show("Error connection to database");
            }

            finally
            {
                dbConnection.Close();
            }
        }

        private string getSecondInsertPart(Person person)
        {
            string first = person.FirstName;
            string last = person.LastName;
            int age = person.Age;

            //      values("Roman", "Komjakov", 22);
            return "values(\"" + first + "\", \"" + last + "\", " + age + ");" ;
        }

        private string getConnectionString(){
            string cs = "";
            cs += "server=" +SourceUrl + ";";
            cs += "database=" + InitialCatalog + ";";
            cs += "uid="+Username+";";
            cs += "pwd="+Password+";";
            return cs;
        }
    }
}
