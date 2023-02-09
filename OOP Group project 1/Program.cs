using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Classes_and_Appliances
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
        static Appliance CreateAppliance(string line)
        {
            Appliance a = null;
            if (line[0] == '1')
            {
               // a = Refrigerator.Parse(line);
            }
            else if (line[0] == '2')
            {
               // a = Vacuum.Parse(line);
            }
            else if (line[0] == '3')

            {
                //a = Microwave.Parse(line);
            }
            else if (line[0] >= '4' && line[0] <= '5')

            {
                a = Dishwasher.Parse(line);
            }
            return a;
        }
}
