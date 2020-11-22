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
        public static string[] fetchDirectories(DirectoryInfo mtd)
        {
            string[] ask = Directory.GetDirectories(mtd.FullName);
            return ask;
        }
        public void tree(string[] ask)
        {
            foreach(string item in ask)
            {
                bool mane = false;
                char mz = '\\';
                int sl = 0;
                for (int i = item.Length - 1; i > 0; i--)
                {
                    if (item[i] == mz)
                    {
                        sl = i;
                        string mis = item.Remove(0, sl + 1);
                        Console.WriteLine(mis);
                        mane = true;

                        break;
                    }
                }

                if (mane == false)
                    Console.WriteLine(item);
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
                        return elements.Length - 1;
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

        public static int HorizontalMenu(string[] elements)
        {
            return 0;
        }
    }
    #endregion
}
