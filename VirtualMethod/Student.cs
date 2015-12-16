using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Student : Person
    {
        public string grade { get; set; }
        public string speciality { get; set; }

        public override void Passport()
        {
            Console.WriteLine("Person: Name={0}, Surname={1}, birthDay={2}, grade{3}, speciality={4}", name, surName, birthDay, grade, speciality);
        }

        public Student (string name, string surName, string birthDay, string grade, string speciality)
            : base (name, surName, birthDay)
        {
            this.grade = grade;
            this.speciality = speciality;
        }
    }
}
