using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            Action<string> method  = Show;

            student.Move(7, method);

        }

        static void Show(string message)
        {
            Console.WriteLine(message); 
        }

    }
}

