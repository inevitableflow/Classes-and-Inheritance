using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_And_Inheritance

    public class Microwave : Appliance
    {
        private string roomType = string.Empty;
        public double Capacity { get; set; }
        public string RoomType 
        { get
            {
                return roomType;
            }
            set
            {
                switch (value.ToLower())
                {
                    case "K":
                        roomType = "kitchen";
                        break;
                    case "W":
                        roomType = "work";
                        break;
                    default:
                        throw new ArgumentException(
                            $"{value} is not a valid Room Type. Please only select K (kitchen) or W (worksite)" +
                            "Room where the microwave will be installed: K (kitchen) or W (work site): ");

                }
            }
        }
        public static Microwave Parse(string s)
        {
            string[] args = s.Split(';');

            Microwave microwave = new Microwave();
            microwave.ItemNumber = long.Parse(args[0]);
            microwave.Brand = args[1];
            microwave.Quantity = int.Parse(args[2]);
            microwave.Wattage = double.Parse(args[3]);
            microwave.Color = args[4];
            microwave.Price = double.Parse(args[5]);
            microwave.Capacity = double.Parse(args[6]);
            microwave.RoomType = args[7];

            return microwave;
        }

        public override string ToString()
        {
            string s = base.ToString()
                + $"Capacity: {Capacity}\n"
                + $"Room Type: {RoomType}\n";
            return s;
        }

        public override string FormatForFile()
        {
            string s = base.ToString()
                + $"Capacity: {Capacity}\n"
                + $"Room Type: {RoomType}\n";
            return s;
        }

    }
}
