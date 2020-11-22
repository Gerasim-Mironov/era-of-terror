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
            explorer ex = new explorer();

            DirectoryInfo mtd = new DirectoryInfo("D:\\");
            string[] ask = explorer.fetchDirectories(mtd);
            //ex.tree(ask);
            graphicMenu.VerticalMenu(ask);

            
            
            Console.ReadLine();
        }
    }
}
