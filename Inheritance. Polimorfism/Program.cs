using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Polimorfism
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseShip ship = GetShipType (ShipType.TransportShip);
            string result = ship.Fight();

            Console.WriteLine(result);

            Console.ReadLine();
        }

        static BaseShip GetShipType(ShipType shipType)
        {
            switch (shipType)
            { 
                case ShipType.TransportShip:
                    return new TransportShip();

                case ShipType.FightShip:
                    return new FightShip();

                default:
                    throw new Exception("Unknown ship type");
            }
        }
    }
}
