using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Polimorfism
{
    public enum ShipType
    { 
        TransportShip = 0,
        FightShip = 1
    }

    class BadShip
    {
        public ShipType ShipType { get; set; }

        public string Move(int distance)
        {
            double time = 0;
            
            if (ShipType  == ShipType.TransportShip)
            {
                time = (double) distance/1000;
            }
            if (ShipType  == ShipType.FightShip)
            {
                time = (double) distance/2000;
            }
            return string.Format("Current Distance: {0} for {1} mins", distance, time);
        }

        public string Fight()
        {
            if (ShipType == ShipType.TransportShip)
            {
                return "Transportship can not fight";
            }
            if (ShipType == ShipType.FightShip)
            {
                return "Enemy is distroyed";
            }

            return "Unknown ship type";
            
        }
    }
}
