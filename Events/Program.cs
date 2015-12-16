using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            student.Moving += student_Moving;
            student.Move(7);
        }

        static void student_Moving(object sender, MovingEentArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
