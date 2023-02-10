using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Vacuum : Appliance
    {
        private string batteryVoltage = string.Empty;
        public string Grade { get; set; }

        public string BatteryVoltage
        {
            get { return batteryVoltage; }

            set
            {
                switch (value.ToLower())
                {
                    case "18V":
                        batteryVoltage = "Low";
                        break;
                    case "24V":
                        batteryVoltage = "High";
                        break;
                    default:
                        throw new ArgumentException(
                            $"{value} is not valid battery voltage. " + "Choose from: 18V (Low) or 24V (High).");
                }
            }
        }

        public static Vacuum Parse(string s)
        {
            string[] args = s.Split(';');

            Vacuum vacuum = new Vacuum();
            vacuum.ItemNumber = long.Parse(args[0]);
            vacuum.Brand = args[1];
            vacuum.Quantity = int.Parse(args[2]);
            vacuum.Wattage = double.Parse(args[3]);
            vacuum.Color = args[4];
            vacuum.Price = double.Parse(args[5]);
            vacuum.Grade = args[6];
            vacuum.BatteryVoltage = args[7];
            return vacuum;

        }

        public override string ToString()
        {
            string s = base.ToString()
                + $"Battery Voltage: {BatteryVoltage}\n"
                + $"Grade: {Grade}\n";
            return s;
        }

        public override string FormatForFile()
        {
            string s = base.ToString()
                + $"Battery Voltage: {BatteryVoltage}\n"
                + $"Grade: {Grade}\n";
            return s;
        }
    }
}

    