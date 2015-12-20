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

        
        public override bool Equals(object obj)
        {
            if (obj.GetType()!= this.GetType()) return false;
            var o = (Person)obj;
            if (o.FirstName != this.FirstName) return false;
            if (o.LastName != this.LastName) return false;
            if (o.Age != this.Age) return false;
            return true;
        }
    }
}
