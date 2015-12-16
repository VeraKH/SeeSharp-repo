using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Person
    {
        public string name;
        public string surName;
        public string birthDay;


        public virtual void Passport()
        {
            Console.WriteLine("Person: Name={0}, Surname={1}, birthDay={2}", name, surName, birthDay);
        }

        public Person(string name, string surName, string birthDay)
        {
            this.name = name; this.surName = surName; this.birthDay = birthDay;
        }
    }
}
