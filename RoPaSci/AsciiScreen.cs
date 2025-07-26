using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoPaSci
{
    internal class AsciiScreen
    {
        public static void SetUpConsole()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "RoPaSci - A Rock Paper Scissors Game";
            Console.CursorVisible = false;

            // Could add settings like window size, but remember to use Try catch
        }

        public static void ShowWelcomeScreen()
        {
            Console.Clear();
            WriteCentredText("Welcome to RoPaSci!", 2);
            WriteCentredText("A Rock, Paper, Scissors Game", 3);
            WriteCentredText("Press any key to start...", 5);
            Console.ReadKey(true);
        }



        private static void WriteCentredText(string text, int row)
        {
            int leftPad = (Console.WindowWidth - text.Length) / 2;
            Console.SetCursorPosition(leftPad, row);
            Console.Write(text);
        }
    }
}
