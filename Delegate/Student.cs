using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace StudentDelegate
{
    public delegate void ShowMessage(string message);

    class Student
    {
        public void Move(int distance, Action<string> method)
        {
            for (int i = 1; i <= distance; i++)
            {
                Thread.Sleep(2000);
                method(string.Format("Moving ... km: {0}", i));
            }
        }
        
        public int GetAge()
        {
            return 17;
        }
    }

}