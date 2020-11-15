using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace era_of_terror
{
    class Program
    {
        static void Main(string[] args)
        {
            const string toKill = "E:\\PICTURE";
            explorer mtd = new explorer();
            
            mtd.deleteFolder(toKill);

            Console.ReadLine();
        }
    }
}
