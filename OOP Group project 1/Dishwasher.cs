using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Group_project_1
{
    public class Dishwasher 
    {
        private string soundRating = string.Empty;
        public double ItemNumber { get; set; }
        public string Brand { get; set; }   
        public double Quantity { get; set; }    
        public double Wattage { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public string Feature { get; set; }
        public string SoundRating
        {
            get
            {
                return soundRating;
            }
            set
            {
                switch (value.ToLower())
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
        public string Feature { get; set; }

        public static Dishwasher Parse(string s)
        {
            string[] args = s.Split(';');

            Dishwasher dishwasher = new Dishwasher();
            dishwasher.ItemNumber = double.Parse(args[0]);
            dishwasher.Brand = args[1];
            dishwasher.Quantity = double.Parse(args[2]);
            dishwasher.Wattage = double.Parse(args[3]);
            dishwasher.Color = args[4];
            dishwasher.Price = double.Parse(args[5]);
            dishwasher.Feature = args[6];
            dishwasher.SoundRating = args[7];

            return dishwasher;
        }

        public override string ToString()
        {
            string s = $"Item Number: {ItemNumber}\n"
                + $"Brand: {Brand}\n"
                + $"Quantity: {Quantity}\n"
                + $"Wattage: {Wattage}\n"
                + $"Color: {Color}\n"
                + $"Price: {Price}\n"
                + $"Feature: {Feature}\n"
                + $"SoundRating: {SoundRating}\n";
            return s; 
        }
    }
}

