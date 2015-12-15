using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_DataBind
{
    public class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Age { get; set; }

        public Person(String firstName, String lastName, int age){
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}
