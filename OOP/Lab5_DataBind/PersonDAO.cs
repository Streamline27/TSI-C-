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
        private delegate void SqlCommandHandler(MySqlConnection con);

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

        /*******************************/
        /*  Public interface methods   */

        public DataTable Select()
        {        
            DataTable dataTable = new DataTable();

            // Lambda expression
            ExecuteInTransaction((connection)=>
            {
                MySqlCommand command = new MySqlCommand(SELECT_QUERY, connection);
                MySqlDataReader sqlDataReader = command.ExecuteReader();
                dataTable.Load(sqlDataReader);
            });
            return dataTable; 
        }

        public void Insert(Person person)
        {
            string insert_query = getInsertQuery(person);

            // Lambda expression
            ExecuteInTransaction((connection) =>
            {
                MySqlCommand command = new MySqlCommand(insert_query, connection);
                MySqlDataReader sqlDataReader = command.ExecuteReader();
            });
        }


        /****************************/
        /* Private helper functions */
        
        private string getConnectionString()
        {
            string cs = "";
            cs += "server=" + SourceUrl + ";";
            cs += "database=" + InitialCatalog + ";";
            cs += "uid=" + Username + ";";
            cs += "pwd=" + Password + ";";
            return cs;
        }

        
        private string getInsertQuery(Person person)
        {
            string first = person.FirstName;
            string last = person.LastName;
            int age = person.Age;

            return INSERT_FIRTS_PART + ConstructSecondQueryPart(first, last, age);
        }

        private string ConstructSecondQueryPart(string first, string last, int age)
        {
            //      values("Roman", "Komjakov", 22);
            return "values(\"" + first + "\", \"" + last + "\", " + age + ");";
        }

        
        private void ExecuteInTransaction(SqlCommandHandler inTransactionExecutable)
        {
            MySqlConnection dbConnection = null;
            try
            {
                dbConnection = new MySqlConnection(getConnectionString());
                dbConnection.Open();

                inTransactionExecutable.Invoke(dbConnection);
                IsConnected = true;
            }
            catch
            {
                MessageBox.Show("Error connecting to database");
                IsConnected = false;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        
    }
}
