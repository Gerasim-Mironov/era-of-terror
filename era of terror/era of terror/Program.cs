using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace era_of_terror
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo mtd = new DirectoryInfo("D:\\");
            explorer ex = new explorer();
            ex.treeLang(mtd);

            Console.ReadLine();
        }
    }
}
