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
        } // WriteApplianceToFile
        static int ChooseOptionFromMenu()
        {
            Console.WriteLine("\nWelcome to Modern Appliances!\n"
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
                    int appOption = ChooseOptionFromApplianceMenu(list);
                    ExecuteApplianceMenu(appOption, list);
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
            int quantity = int.Parse(Console.ReadLine());
            Random rnd = new Random();
            for (int i = 0; i<quantity; i++)
            {
                int a = rnd.Next(0,list.Count);
                Appliance appliance = list.ElementAt(a);
                Console.WriteLine(appliance.ToString());
            }
        } // DisplayRandomAppliances

         static int ChooseOptionFromApplianceMenu (List<Appliance> list)
        {
            Console.WriteLine("\nAppliance Types \n"
                +"1 - Refrigerators \n"
                +"2 - Vacuums \n"
                +"3 - Microwaves \n"
                +"4 - Dishwashers \n"
                +"Enter type of appliance: ");

            int applianceType = int.Parse(Console.ReadLine());
            return applianceType;

        } //ChooseOptionFromApplianceMenu

        static void ExecuteApplianceMenu(int option, List<Appliance> list)
        {
            switch (option)
            {
                case 1:
                    RefrigeratorMenu(list);
                    break;
                case 2:
                    VacuumMenu(list);
                    break;
                case 3:
                    MicrowaveMenu(list);
                    break;
                case 4:
                    DishwasherMenu(list);
                    break;
            }
        }

        static void RefrigeratorMenu(List<Appliance> list)
        {
            Console.WriteLine("Enter number of doors. 2 (double doors), 3 (three doors) or 4 (four doors): ");
            string option = Console.ReadLine();
            Console.WriteLine("\nMatching refrigerators: ");
            if (option == "2")
            {
                option = "double doors";
            } else if (option == "3")
            {
                option = "three doors";
            } else if (option == "4")
            {
                option = "four doors";
            }
            PrintMatching(list, option);
        } //RefrigeratorMenu

        static void VacuumMenu(List<Appliance> list)
        {
            Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high): ");
            string option = Console.ReadLine();
            Console.WriteLine("\nMatching vacuums: ");
            if (option == "18")
            {
                option = "Low";
            }
            else if (option == "24")
            {
                option = "High";
            }
            PrintMatching(list, option);
        } //VacuumMenu

        static void MicrowaveMenu(List<Appliance> list)
        {
            Console.WriteLine("Room where the microwave will be installed. K (kitchen) or W (work site): ");
            string option = Console.ReadLine();
            Console.WriteLine("\nMatching microwaves: ");
            if (option.ToLower() == "k")
            {
                option = "kitchen";
            }
            else if (option.ToLower() == "w")
            {
                option = "work";
            }
            PrintMatching(list, option);
        } // MicrowaveMenu
        static void DishwasherMenu(List<Appliance> list)
        {
            Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate): ");
            string option = Console.ReadLine();
            Console.WriteLine("\nMatching diswashers: ");
            if (option.ToLower() == "qt")
            {
                option = "Quietest";
            }
            else if (option.ToLower() == "qr")
            {
                option = "Quieter";
            }
            else if (option.ToLower() == "qu")
            {
                option = "Quiet";
            }
            else if (option.ToLower() == "m")
            {
                option = "Moderate";
            }
            PrintMatching(list, option);
        } // DishwasherMenu

        static void PrintMatching(List<Appliance> list, string option)
        {
            foreach (Appliance appliance in list)
            {
                if (appliance.Matches(option))
                {
                    Console.WriteLine(appliance.ToString());
                }
            }
        }
    } // classs Program
} // namespace