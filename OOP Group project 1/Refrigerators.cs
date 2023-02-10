using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Refrigerators : Appliance
    {
        public string numberOfDoors { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string NumberOfDoors
        {
            get
            {
                return numberOfDoors;
            }

            set
            {
                switch (value.ToLower())
                {
                    case "2":
                        numberOfDoors = "double doors";
                        break;
                    case "3":
                        numberOfDoors = "three doors";
                        break;
                    case "4":
                        numberOfDoors = "four doors";
                        break;
                    default:
                        throw new ArgumentException(
                        $"{value} is not a valid number of doors. Please only select 2 (double doors), or 3 (three doors), 4 (four doors)" + "Choose from: 2 (double doors), 3 (three dours), or 4 (four doors): ");
                }

            }
        }

        public static Refrigerators Parse(string s)
        {
            string[] args = s.Split(';');

            Refrigerators refrigerators = new Refrigerators();
            refrigerators.ItemNumber = long.Parse(args[0]);
            refrigerators.Brand = args[1];
            refrigerators.Quantity = int.Parse(args[2]);
            refrigerators.Wattage = double.Parse(args[3]);
            refrigerators.Color = args[4];
            refrigerators.Price = double.Parse(args[5]);
            refrigerators.NumberOfDoors = args[6];
            refrigerators.Height = int.Parse(args[7]);
            refrigerators.Width = int.Parse(args[8]);

            return refrigerators;
        }

        public override string ToString()
        {
            string s = base.ToString()
                 + $"NumberOfDoors: {NumberOfDoors}\n"
                 + $"Height: {Height}\n" 
                 +$"Width: {Width}\n";
            return s;

        }
    }
}
