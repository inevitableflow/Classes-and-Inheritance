using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_And_Inheritance
{
    public class Dishwasher : Appliance
    {
        private string soundRating = string.Empty;
        public string Feature { get; set; }
        public string SoundRating
        {
            get
            {
                return soundRating;
            }
            set
            {
                switch (value)
                {
                    case "Qt":
                        soundRating = "Quietest";
                        break;
                    case "Qr":
                        soundRating = "Quieter";
                        break;
                    case "Qu":
                        soundRating = "Quiet";
                        break;
                    case "M":
                        soundRating = "Moderate";
                        break;
                    default:
                        throw new ArgumentException(
                            $"{value} is not a valid sound rating. " +
                            "Choose from: Qt (Quietest), Qr (Quieter), Qu (Quiet) or M (Moderate).");
                }
            }
        }

        public static Dishwasher Parse(string s)
        {
            string[] args = s.Split(';');

            Dishwasher dishwasher = new Dishwasher();
            dishwasher.ItemNumber = long.Parse(args[0]);
            dishwasher.Brand = args[1];
            dishwasher.Quantity = int.Parse(args[2]);
            dishwasher.Wattage = double.Parse(args[3]);
            dishwasher.Color = args[4];
            dishwasher.Price = double.Parse(args[5]);
            dishwasher.Feature = args[6];
            dishwasher.SoundRating = args[7];

            return dishwasher;
        }

        public override string ToString()
        {
            string s = base.ToString()
                + $"Feature: {Feature}\n"
                + $"SoundRating: {SoundRating}\n";
            return s; 
        }

        public override string FormatForFile()
        {
            string[] args =
            {
                base.FormatForFile(),
                Feature,
                SoundRating
            };
            string s = string.Join(";", args);
            return s;
        }

        public override bool Matches(string option)
        {
            return option == SoundRating;
        }
    }
}

