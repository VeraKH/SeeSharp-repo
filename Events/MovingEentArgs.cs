using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace EventsExample
{
    class MovingEentArgs : EventArgs
    {
        public MovingEentArgs(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}
