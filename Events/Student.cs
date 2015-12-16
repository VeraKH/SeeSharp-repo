using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EventsExample
{
    class Student
    {
        public void Move(int distance)
        {
            for (int i = 1; i <= distance; i++)
            {
                Thread.Sleep(1000);
                if (Moving !=null)
                Moving(this, new MovingEentArgs(string.Format("Moving... distance: {0}", i)));
            }
        }

        public event EventHandler<MovingEentArgs> Moving;
    }
}
