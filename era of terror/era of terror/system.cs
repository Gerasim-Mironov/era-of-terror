using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace era_of_terror
{


    class explorer
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
        public bool fullscreen = false;


        public string moveString { get; set; }
        public static List<DriveInfo> AllDrives = DriveInfo.GetDrives().ToList();

        public string currentLocation = "";
        public string[] shortenedRoutes { get; set; }
        public List<DirectoryInfo> fullRoutes { get; set; }

        public string[] shortenedFileRoutes { get; set; }
        public List<FileInfo> fullFileRoutes { get; set; }

        public bool copy = false;

        //public List<>
        public explorer()
        {
            moveString = "";
            shortenedRoutes = new string[] { };
            fullRoutes = new List<DirectoryInfo> { };

            shortenedFileRoutes = new string[] { };
            fullFileRoutes = new List<FileInfo> { };
        }



        public string[] fetchDirectories(DirectoryInfo mtd)
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


        public bool delete(DirectoryInfo toKill)
        {
            try
            {
                toKill.Delete(true);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}", "an exception has occured");
                return false;
            }
        }
        public bool delete(FileInfo toKill)
        {
            try
            {
                toKill.Delete();
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show($"{e.Message}", "an exception has occured");
                return false;
            }
        }

        public bool moveTo(DirectoryInfo mt, string sati)
        {
            try
            {
                Directory.Move(mt.FullName, sati);
                this.moveString = "";
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}", "an exception has occured");
                this.moveString = "";
                return false;
            }
        }
        public bool moveTo(FileInfo mt, string sati)
        {
            try
            {
                File.Move(mt.FullName, sati);
                this.moveString = "";
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}", "an exception has occured");
                this.moveString = "";
                return false;
            }
            
        }

        public DirectoryInfo createFolder(string name)
        {
            return Directory.CreateDirectory(name);
        }
        public FileStream createFile(string name)
        {
            return File.Create(name); 
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
                                Console.WriteLine(ex.currentLocation + $"\n{ex.shortenedRoutes[pos]} ->");
                                string newName = ex.currentLocation + "\\" + Console.ReadLine();
                                ex.moveTo(ex.fullRoutes[pos], newName);
                            }
                            catch(IndexOutOfRangeException)
                            {
                                Console.WriteLine(ex.currentLocation + $"\n{ex.shortenedFileRoutes[pos - ex.fullRoutes.Count]} -> ");
                                string newName = ex.currentLocation + "\\" + Console.ReadLine();
                                ex.moveTo(ex.fullFileRoutes[pos - ex.fullRoutes.Count], newName);
                            }

                            return -13;
                        }
                        break;
                    
                    case ConsoleKey.C:
                        {
                            try
                            {
                                ex.moveString = ex.shortenedRoutes[pos];
                            }
                            catch (IndexOutOfRangeException)
                            {
                                ex.moveString = ex.shortenedFileRoutes[pos];
                            }
                            ex.copy = true;
                        }
                        break;

                    case ConsoleKey.X:
                        {
                            try
                            {
                                ex.moveString = ex.shortenedRoutes[pos];
                            }
                            catch (IndexOutOfRangeException)
                            {
                                ex.moveString = ex.shortenedFileRoutes[pos];
                            }
                            ex.copy = false;
                        }
                        break;

                    case ConsoleKey.V:
                        return -25;
                        break;

                    case ConsoleKey.Delete:
                        {
                            try
                            {
                                DirectoryInfo temple = new DirectoryInfo(ex.shortenedRoutes[pos]);
                                ex.delete(temple);
                            }
                            catch(IndexOutOfRangeException)
                            {
                                FileInfo temple = new FileInfo(ex.shortenedFileRoutes[pos - ex.shortenedRoutes.Length]);
                                ex.delete(temple);
                            }
                            return -13;
                        }
                        break;

                    case ConsoleKey.F:
                        {
                            if (ex.fullscreen == false)
                            {
                                Process ask = Process.GetCurrentProcess();
                                explorer.ShowWindow(ask.MainWindowHandle, 3);
                                ex.fullscreen = true;
                            }
                            else
                            {
                                Process ask = Process.GetCurrentProcess();
                                explorer.ShowWindow(ask.MainWindowHandle, 9);
                                ex.fullscreen = false;
                            }
                        }
                        break;

                    case ConsoleKey.A:
                        {
                            Console.Clear();
                            Console.WriteLine(ex.currentLocation + "\n");
                            string sati = Console.ReadLine();
                            ex.createFolder(ex.currentLocation + "\\" + sati);
                            return -13;
                        }
                        break;

                    case ConsoleKey.S:
                        {
                            Console.Clear();
                            Console.WriteLine(ex.currentLocation + "\n");
                            string sati = Console.ReadLine();
                            ex.createFile(ex.currentLocation + "\\" + sati);
                            return -13;
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