using Classes_and_Appliances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Inheritance.Properties
{
    class Program
    {
    
        static void Main(string[] args)
        {
           //Method that allows customer to purchase an appliance
            List<Appliance> appliances = ReadAppliancesFromFile("appliances.txt");

            Console.WriteLine("Enter the item number of an appliance: ");
            long itemNumber = long.Parse(Console.ReadLine());

            var foundAppliance = appliances.FirstOrDefault(a => a.ItemNumber == itemNumber);
            if (foundAppliance == null)
            {
                Console.WriteLine("No appliance found with that item number.");
                return;
            }

            foundAppliance.Checkout();
            WriteAppliancesToFile("appliances.txt", appliances);

            // CHECK AVAILABILITY!!!!!!!!!!!

            // Method to search for brand

            Console.WriteLine("Enter the brand of the appliances you want to display: ");
            string brand = Console.ReadLine();

            bool found = false;
            foreach (Appliance appliance in appliances)
            {
                if (appliance.Brand.ToLower() == brand.ToLower())
                {
                    Console.WriteLine(appliance.ToString());
                    found = true;
                    break;
                }
            }
            if (found)
            {
               
            }
            else
            {
                Console.WriteLine("No appliances brand found.");
            }


        }
    }
}