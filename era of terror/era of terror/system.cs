using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace era_of_terror
{
    class explorer
    { 
        public int moveNum = -1;
        public string moveString { get; set; }
        public static List<DriveInfo> AllDrives = DriveInfo.GetDrives().ToList();

        public static string currentLocation = "";
        public string[] shortenedRoutes { get; set; }
        public List<DirectoryInfo> fullRoutes { get; set; }

        public string[] shortenedFileRoutes { get; set; }
        public List<FileInfo> fullFileRoutes { get; set; }

        //public List<>
        public explorer()
        {
            moveString = "";
            shortenedRoutes = new string[] { };
            fullRoutes = new List<DirectoryInfo> { };

            shortenedFileRoutes = new string[] { };
            fullFileRoutes = new List<FileInfo> { };
        }



        public static string[] fetchDirectories(DirectoryInfo mtd)
        {
            currentLocation = mtd.FullName;

            string[] ask = new string[] { };
            try
            {
                ask = Directory.GetDirectories(mtd.FullName);
            }
            catch (UnauthorizedAccessException)
            {

            }
            return ask;
        }

        public static string[] haulFiles(DirectoryInfo mtd)
        {
            string[] ayanami = new string[] { };
            try
            {
                ayanami = Directory.GetFiles(mtd.FullName);
            }
            catch (UnauthorizedAccessException)
            {

            }
            return ayanami;
        }

        public static List<DirectoryInfo> convertStrings(string[] roots)
        {
            List<DirectoryInfo> storage = new List<DirectoryInfo> { };

            foreach (string item in roots)
            {
                DirectoryInfo temp = new DirectoryInfo(item);
                storage.Add(temp);
            }

            return storage;
        }

        public static List<FileInfo> convertLines(string[] fileRoots)
        {
            List<FileInfo> storage = new List<FileInfo> { };

            foreach (string item in fileRoots)
            {
                FileInfo temp = new FileInfo(item);
                storage.Add(temp);
            }

            return storage;
        }

        public string[] prepareTheTree(string[] ask)
        {
            List<string> vh = new List<string> { };
            foreach (string item in ask)
            {
                char mz = '\\';
                int sl = 0;
                for (int i = item.Length - 1; i > 0; i--)
                {
                    if (item[i] == mz)
                    {
                        sl = i;
                        string mis = item.Remove(0, sl + 1);
                        vh.Add(mis);

                        break;
                    }
                }
            }

            string[] langley = vh.ToArray();
            return langley;
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
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return false;
            }
        }

        public bool rename(DirectoryInfo mt, string sati)
        {
            try
            {
                Directory.Move(mt.FullName, sati);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}", "an exception has occured");
                return false;
            }
        }
        public bool rename(FileInfo mt, string sati)
        {
            try
            {
                File.Move(mt.FullName, sati);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}", "an exception has occured");
                return false;
            }

        }

        }
        #region gololobov
        class graphicMenu
        {
            public static int VerticalMenu(string[] elements)
            {
                int maxLen = 0;
                foreach (var item in elements)
                {
                    if (item.Length > maxLen)
                        maxLen = item.Length;
                }
                ConsoleColor bg = Console.BackgroundColor;
                ConsoleColor fg = Console.ForegroundColor;
                int x = Console.CursorLeft;
                int y = Console.CursorTop;
                Console.CursorVisible = false;
                int pos = 0;
                while (true)
                {

                    for (int i = 0; i < elements.Length; i++)
                    {
                        Console.SetCursorPosition(x, y + i);
                        if (i == pos)
                        {
                            Console.BackgroundColor = fg;
                            Console.ForegroundColor = bg;
                        }
                        else
                        {
                            Console.BackgroundColor = bg;
                            Console.ForegroundColor = fg;
                        }
                        Console.Write(elements[i].PadRight(maxLen));
                    }

                    ConsoleKey consoleKey = Console.ReadKey().Key;
                    switch (consoleKey)
                    {

                        case ConsoleKey.Enter:
                            return pos;
                            break;

                        case ConsoleKey.Escape:
                            return -2;
                            break;

                        case ConsoleKey.E:
                            return -9;
                            break;

                        case ConsoleKey.UpArrow:
                            if (pos > 0)
                                pos--;
                            break;

                        case ConsoleKey.DownArrow:
                            if (pos < elements.Length - 1)
                                pos++;
                            break;


                        default:
                            break;
                    }

                }
            }
        public static int VerticalMenu(string[] elements, explorer ex)
        {
            int maxLen = 0;
            foreach (var item in elements)
            {
                if (item.Length > maxLen)
                    maxLen = item.Length;
            }
            ConsoleColor bg = Console.BackgroundColor;
            ConsoleColor fg = Console.ForegroundColor;
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.CursorVisible = false;
            int pos = 0;
            while (true)
            {

                for (int i = 0; i < elements.Length; i++)
                {
                    Console.SetCursorPosition(x, y + i);
                    if (i == pos)
                    {
                        Console.BackgroundColor = fg;
                        Console.ForegroundColor = bg;
                    }
                    else
                    {
                        Console.BackgroundColor = bg;
                        Console.ForegroundColor = fg;
                    }
                    Console.Write(elements[i].PadRight(maxLen));
                }

                ConsoleKey consoleKey = Console.ReadKey().Key;
                switch (consoleKey)
                {

                    case ConsoleKey.Enter:
                        return pos;
                        break;

                    case ConsoleKey.Escape:
                        return -2;
                        break;

                    case ConsoleKey.E:
                        return -9;
                        break;

                    case ConsoleKey.R:
                        {
                            Console.Clear();
                            try
                            {
                                Console.WriteLine(explorer.currentLocation + $"\n{ex.shortenedRoutes[pos]} ->");
                                string newName = explorer.currentLocation + "\\" + Console.ReadLine();
                                ex.rename(ex.fullRoutes[pos], newName);
                            }
                            catch(IndexOutOfRangeException)
                            {
                                Console.WriteLine(explorer.currentLocation + $"\n{ex.shortenedFileRoutes[pos - ex.fullRoutes.Count]} -> ");
                                string newName = explorer.currentLocation + "\\" + Console.ReadLine();
                                ex.rename(ex.fullFileRoutes[pos - ex.fullRoutes.Count], newName);
                            }

                            return -13;
                        }
                        break;

                    case ConsoleKey.C:
                        {
                            ex.moveNum = pos;
                            return pos;
                        }
                        break;

                    case ConsoleKey.X:
                        {
                            ex.moveNum = pos;
                            return pos;
                        }
                        break;

                    case ConsoleKey.V:
                        {

                        }

                    case ConsoleKey.UpArrow:
                        if (pos > 0)
                            pos--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (pos < elements.Length - 1)
                            pos++;
                        break;


                    default:
                        break;
                }

            }
        }

        public static int HorizontalMenu(string[] elements)
            {
                return 0;
            }
        }
        #endregion
}