using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace era_of_terror
{
    class explorer
    {
        public explorer()
        {

        }
        public void treeLang()
        {
            const string direction = "C:\\";

            if (Directory.Exists(direction))
            {
                string[] vh = Directory.GetDirectories(direction);
                foreach (string item in vh)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\nфайлы: ");
                string[] ask = Directory.GetFiles(direction);
                foreach (string item in ask)
                {
                    Console.WriteLine(item);
                }

            }
        }

        public bool deleteFolder(string toKill)
        {
            try
            {
                DirectoryInfo dv = new DirectoryInfo(toKill);
                dv.Delete(true);
                Console.WriteLine("оно умерщвлено");
                return true;
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
                return false;
            }
        }
       
    }
}
