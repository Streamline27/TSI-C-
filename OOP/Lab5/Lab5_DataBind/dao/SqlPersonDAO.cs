using Lab5_DataBind.dao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_DataBind
{
    
    public class SqlPersonDAO : PersonDAO
    {
        private delegate void SqlCommandHandler(MySqlConnection con);

        private string SourceUrl { get; set; }
        private string InitialCatalog { get; set; }
        private string Username {get; set; }
        private string Password { get; set; }

        private const string SELECT_QUERY = "SELECT first_name, last_name, age FROM People";
        private const string INSERT_FIRTS_PART = "INSERT INTO People (first_name, last_name, age) ";

        public bool IsConnected { get; private set; }


        /*  Public interface methods   */
        public SqlPersonDAO(string sourceUrl, String initialCatalog, String username, String password){
            this.SourceUrl = sourceUrl;
            this.InitialCatalog = initialCatalog;
            this.Username = username;
            this.Password = password;
            IsConnected = false;

            ExecuteInTransaction((connection) => { }); // Checking if connection established successfully
        }


        public virtual void Insert(IList<Person> personList)
        {
            foreach (var person in personList) Insert(person);
        }

        public virtual void Insert(Person person)
        {
            string insert_query = getInsertQuery(person);
            ExecuteSqlWithoutResponse(insert_query);
        }

        public virtual void Delete(Person person)
        {
            string delete_query = getDeleteQuery(person);
            ExecuteSqlWithoutResponse(delete_query);
        }

        public virtual IList<Person> Select()
        {
            IList<Person> people = null;

            ExecuteInTransaction((connection) => // Lambda expression
            {
                MySqlCommand command = new MySqlCommand(SELECT_QUERY, connection);
                MySqlDataReader sqlDataReader = command.ExecuteReader();
                people = getPersonListFromSqlReader(sqlDataReader);
            });
            return people;
        }


        /* Private helper methods */
        protected virtual string getConnectionString()
        {
            string cs = "";
            cs += "server=" + SourceUrl + ";";
            cs += "database=" + InitialCatalog + ";";
            cs += "uid=" + Username + ";";
            cs += "pwd=" + Password + ";";
            return cs;
        }

        private string getDeleteQuery(Person person)
        {
            string first = person.FirstName;
            string last = person.LastName;
            int age = person.Age;

            return "DELETE FROM People WHERE first_name='"+first+"' AND last_name='"+last+"' AND age="+age+";";
        }

        private string getInsertQuery(Person person)
        {
            string first = person.FirstName;
            string last = person.LastName;
            int age = person.Age;

            return INSERT_FIRTS_PART + ConstructSecondInsertQueryPart(first, last, age);
        }

        private string ConstructSecondInsertQueryPart(string first, string last, int age)
        {
            //      values("Roman", "Komjakov", 22);
            return "values(\"" + first + "\", \"" + last + "\", " + age + ");";
        }

        private IList<Person> getPersonListFromSqlReader(MySqlDataReader reader)
        {
            IList<Person> personList = new BindingList<Person>();
            while (reader.Read()) personList.Add(GetPersonFromSqlReader(reader));

            return personList;
        }

        private Person GetPersonFromSqlReader(MySqlDataReader reader)
        {
            String first = reader["first_name"].ToString();
            String last = reader["last_name"].ToString();
            int age = Convert.ToInt32(reader["age"].ToString());

            return new Person(first, last, age);
        }


        // Transaction helper methods
        private void ExecuteSqlWithoutResponse(string query)
        {
            ExecuteInTransaction((connection) => // Lambda expression
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            });
        }

        private void ExecuteInTransaction(SqlCommandHandler inTransactionExecutable)
        {
            MySqlConnection dbConnection = null;
            try
            {
                dbConnection = new MySqlConnection(getConnectionString());
                dbConnection.Open();

                inTransactionExecutable.Invoke(dbConnection); // Invoke action passed as a parameter
                IsConnected = true;
            }
            catch(Exception)
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
