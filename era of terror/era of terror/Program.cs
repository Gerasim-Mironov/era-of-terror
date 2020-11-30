using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace era_of_terror
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("instructions:\n\ne- switching drives\nr- rename\ndel- delete something\nenter- move on\nnavigate with arrows\n");
            Console.ReadKey();

            #region settings
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            #endregion

            
            explorer ex = new explorer();

            DirectoryInfo mtd = new DirectoryInfo(explorer.AllDrives[0].Name);
            List<string> antique = new List<string> { };
            int returnCount = 1;

            

            while(true)
            {
                antique.Add(explorer.currentLocation);

                ex.shortenedFileRoutes = explorer.haulFiles(mtd);
                ex.shortenedRoutes = explorer.fetchDirectories(mtd);
                ex.fullRoutes = explorer.convertStrings(ex.shortenedRoutes);
                ex.fullFileRoutes = explorer.convertLines(ex.shortenedFileRoutes);

                Console.Clear();
                Console.WriteLine(explorer.currentLocation + "\n");

                List<string> rits = new List<string> { };
                rits.AddRange(ex.prepareTheTree(ex.shortenedRoutes));
                rits.AddRange(ex.prepareTheTree(ex.shortenedFileRoutes));
                string[] kats = rits.ToArray();

                var demand = graphicMenu.VerticalMenu(kats, ex);

                Console.Clear();

                if (demand == -13)
                {
                    
                }
                else if (demand == -9)
                {
                    List<string> unl = new List<string> { };
                    List<string> vh = new List<string> { };

                    foreach (DriveInfo item in explorer.AllDrives)
                    {
                        unl.Add(item.Name);
                        vh.Add(item.Name + $"\t{item.DriveFormat}" + $"\t{item.TotalFreeSpace}bytes from {item.TotalSize}bytes");
                    }

                    int spray = graphicMenu.VerticalMenu(vh.ToArray());

                    DirectoryInfo temple = new DirectoryInfo(unl[spray]);
                    mtd = temple;
                }
                else if (demand != -2)
                {
                    returnCount = 1;
                    try
                    {
                        mtd = ex.fullRoutes[demand];
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        try
                        {
                            Process.Start(ex.shortenedFileRoutes[demand - ex.shortenedRoutes.Length]);
                        }
                        catch (Exception ppun)
                        {
                            MessageBox.Show($"{ppun.Message}", "an exception has occured");
                        }
                    }
                }
                else
                {
                    DirectoryInfo temporary = new DirectoryInfo(antique[antique.Count - returnCount]);
                    mtd = temporary;
                    returnCount += 2;
                }
            }
        }
    }
}