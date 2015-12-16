using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Polimorfism
{
    class BaseShip
    {
        public virtual string Move(int distance)
        {
           string result = string.Format("Current Distance: {0}", distance);
           return result;
        }

        public virtual string Fight()
        {
            return "Fight completed";
        }
    }

}
