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
            #region settings
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            #endregion
            explorer ex = new explorer();

            DirectoryInfo mtd = new DirectoryInfo("C:\\");
            ex.shortenedRoutes = explorer.fetchDirectories(mtd, ex.fullRoutes);
            
            while(true)
            {
                Console.Clear();
                int demand = graphicMenu.VerticalMenu(ex.prepareTheTree(ex.shortenedRoutes));

                Console.Clear();

                DirectoryInfo mt = ex.fullRoutes[demand];
                ex.shortenedRoutes = explorer.fetchDirectories(mt, ex.fullRoutes);//тут ошибка где- то

                //graphicMenu.VerticalMenu(ex.prepareTheTree(ex.shortenedRoutes));
            }
        }
    }
}
