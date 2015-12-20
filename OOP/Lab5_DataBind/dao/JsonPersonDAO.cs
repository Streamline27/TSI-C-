using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_DataBind.dao
{
    public class JsonPersonDAO : PersonDAO
    {
        private string FilePath { get; set; }
        public bool IsConnected { get; set; }

        /* Public interface methods */
        public JsonPersonDAO(String filePath)
        {
            FilePath = filePath;
            try
            {
                CreateIfNotExist(filePath);
                Select();
                IsConnected = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error connecting to file.");
            }
            
        }

        public IList<Person> Select()
        {
            var personList = ReadFromJsonFile();
            return personList;
        }
        
        public void Insert(Person person)
        {
            var personList = Select();
            personList.Add(person);
            WriteToJsonFile(personList);
        }

        public void Insert(IList<Person> personList)
        {
            var people = Select();
            foreach (var person in personList) people.Add(person);
            WriteToJsonFile(people);
        }

        public void Delete(Person person)
        {
            var personList = Select();
            Remove(person, personList);
            WriteToJsonFile(personList);
        }


        /* Private helper methods */
        private void Remove(Person person, IList<Person> personList)
        {
            int i = 0;
            while(i<personList.Count){
                Person item = personList[i];
                if (person.Equals(item)) personList.Remove(item);
                else i++;
            }
        }

        private IList<Person> ReadFromJsonFile()
        {
            string jsonText = File.ReadAllText(FilePath);
            var pl = JsonConvert.DeserializeObject<BindingList<Person>>(jsonText);
            if (pl == null) return new BindingList<Person>();
            return pl;
        }

        private void CreateIfNotExist(String filePath)
        {
            if (!File.Exists(filePath))
            {
                var f = File.Create(filePath);
                f.Close();
            }
        }

        private void WriteToJsonFile(IList<Person> personList)
        {
            var output = JsonConvert.SerializeObject(personList);
            System.IO.File.WriteAllText(FilePath, output);
        }

        
    }
}
