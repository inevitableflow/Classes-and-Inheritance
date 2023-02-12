using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Classes_And_Inheritance;

namespace Classes_And_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Appliance> list = ReadApplianceFromFile("..\\..\\res\\appliances.txt");
            int option = 0;
            while (option != 5) 
            {
                option = ChooseOptionFromMenu();
                Execute(option, list);
            }

        }  // Main

        static Appliance CreateAppliance(string line)
        {
            Appliance a = null;
            if (line[0] == '1')
            {
                a = Refrigerator.Parse(line);
            }
            else if (line[0] == '2')
            {
                a = Vacuum.Parse(line);
            }
            else if (line[0] == '3')

            {
                a = Microwave.Parse(line);
            }
            else if (line[0] >= '4' && line[0] <= '5')

            {
                a = Dishwasher.Parse(line);
            }
            return a;
        } // CreateAppliance

        static Appliance Quantity(List<Appliance> appliances)
        {
            Appliance a = appliances.First();
            foreach (Appliance appliance in appliances)
            {
                /*
                if (appliance.Quantity == Quantity)
                {
                    a = appliance;
                }
                */
            }
            return a;

        } // Quantity

        static List<Appliance> ReadApplianceFromFile(string filename)
        {
            List<Appliance> list = new List<Appliance>();

            foreach (string line in System.IO.File.ReadLines(filename))
            {
                Appliance appliance = CreateAppliance(line);

                list.Add(appliance);
            }
            return list;
        } // ReadApplianceFromFile

        static void WriteApplianceToFile(string filename, List<Appliance> list)
        {
           StreamWriter file = new StreamWriter(filename);

            foreach (Appliance appliance in list)
            {
                string s = appliance.FormatForFile();
                file.Write(s);
            }
        }
        static int ChooseOptionFromMenu()
        {
            Console.WriteLine("Welcome to MOdern Appliances!\n"
                + "How May We Assist You? \n"
                + "1 - Check out appliance \n"
                + "2 - Find appliances by brand \n"
                + "3 - Display appliances by type \n"
                + "4 - Produce random appliance list \n"
                + "5 - Save & exit\n"
                + " \n"
                + "Enter option:\n");

            int itemNumber = int.Parse(Console.ReadLine());
            return itemNumber;
        } // ChooseOptionFromMenu 

        static void Execute(int option, List<Appliance> list)
        {
            switch (option)
            {
                case 1:
                    Checkout(list);
                    break;
                case 2:
                    FindByBrand(list);
                    break;
                case 3:
                    //display by type
                    break;
                case 4:
                    DisplayRandomAppliances(list);
                    break;
                case 5:
                    WriteApplianceToFile("appliances.txt", list);
                    break;
            }
        } // Execute 

        static void Checkout(List<Appliance> list)
        {
            Console.WriteLine("Enter the item number of an appliance: ");
            long itemNumber = long.Parse(Console.ReadLine());

            var foundAppliance = list.FirstOrDefault(a => a.ItemNumber == itemNumber);
            if (foundAppliance == null)
            {
                Console.WriteLine("No appliance found with that item number.");
                return;
            }

            foundAppliance.Checkout();
        } // Checkout

        static void FindByBrand(List<Appliance> list)
        {
            Console.WriteLine("Enter the brand of the appliances you want to display: ");
            string brand = Console.ReadLine();

            bool found = false;
            foreach (Appliance appliance in list)
            {
                if (appliance.Brand.ToLower() == brand.ToLower())
                {
                    Console.WriteLine(appliance.ToString());
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("No appliances brand found.");
            }
        } // FindByBrand

        static void DisplayRandomAppliances(List<Appliance> list)
        {
            Console.WriteLine("Enter number of appliances: ");
            int Quantity = int.Parse(Console.ReadLine());
        } // DisplayRandomAppliances

    } // class Program
} // namespace