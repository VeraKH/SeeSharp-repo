using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Polimorfism
{
    class TransportShip : BaseShip
    {
        public override string Move(int distance)
        {
            double time = (double)distance / 1000;

            return string.Format("Current Distance: {0} for {1} mins", distance, time);
        } 

        public override string Fight()
        {
            return "Transportship can not fight";
        }

        public override string ToString()
        {
            return "Transportship";
        }
    }
}
