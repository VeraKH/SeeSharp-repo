using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Teacher : Person
    {
        public string department { get; set; }
        public string employmentDate { get; set; }
        public string subject { get; set; }


        public override void Passport()
        {
            Console.WriteLine("Person: Name={0}, Surname={1}, birthDay={2}, department={3}, employmentDate={4}, subject={5}", name, surName, birthDay, department, employmentDate, subject);
        }

        public Teacher(string name, string surName, string birthDay, string department, string employmentDate, string subject)
            : base (name, surName, birthDay)
        {
            this.department = department;
            this.employmentDate = employmentDate;
            this.subject = subject;
        }
    }
}
