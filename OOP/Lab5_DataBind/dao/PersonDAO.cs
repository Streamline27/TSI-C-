using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_DataBind.dao
{
    public interface PersonDAO
    {
        IList<Person> Select();
        void Insert(Person person);
        void Insert(IList<Person> personList);
        void Delete(Person person);
        bool IsConnected { get; }
    }

}
