using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoPaSci
{
    public class AsciiScreen
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteCentredText("Welcome to RoPaSci!", 2);
            Console.ForegroundColor = ConsoleColor.White;
            WriteCentredText("A Rock, Paper, Scissors Game", 3);
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteCentredText("Press any key to begin...", 5);
            Console.ResetColor();

            Console.ReadKey(true);
        }

        public static int GameSetUpChoice(List<string> choices)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteCentredText("Choose Game Mode", 2);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < choices.Count; i++)
            {
                WriteCentredText($"{i + 1}. {choices[i]}", 4 + i);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteCentredText("Press the corresponding number to select...", 8);
            Console.ResetColor();
            // Here you would capture the input and handle the game mode selection
            int choice = -1;
            while (choice < 1 || choice > choices.Count)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (int.TryParse(keyInfo.KeyChar.ToString(), out choice) && choice >= 1 && choice <= choices.Count)
                {
                    return choice - 1; // Return zero-based index
                }
                else
                {
                    Console.Beep(); // Invalid input, beep sound
                }
            }

            // If we reach here, it means the input was invalid
            return -1;
        }

        public static void ShowMoveChoice(List<Program.Move> allowedMoves)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteCentredText("Choose Your Move", 2);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < allowedMoves.Count; i++)
            {
                WriteCentredText($"{i + 1}. {allowedMoves[i]}", 4 + i);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteCentredText("Press the corresponding number to select...", 4 + allowedMoves.Count + 1);
            Console.ResetColor();
            // Here you would capture the input and handle the move selection
            int choice = -1;
            while (choice < 1 || choice > allowedMoves.Count)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (int.TryParse(keyInfo.KeyChar.ToString(), out choice) && choice >= 1 && choice <= allowedMoves.Count)
                {
                    // Return zero-based index
                    Console.WriteLine($"\nYou chose: {allowedMoves[choice - 1]}");
                    return;
                }
                else
                {
                    Console.Beep(); // Invalid input, beep sound
                }
            }
        }

        public static void AskToPlayAgain()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteCentredText("Do you want to play again? (Y/N)", Console.WindowHeight - 2);
            Console.ResetColor();

            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                consoleKeyInfo = Console.ReadKey(true);
                if (consoleKeyInfo.Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    return; // Restart the game
                }
                else if (consoleKeyInfo.Key == ConsoleKey.N)
                {
                    Environment.Exit(0); // Exit the game
                }
                else
                {
                    Console.Beep(); // Invalid input, beep sound
                }
            } while (true);

        }


        private static void WriteCentredText(string text, int row)
        {
            int leftPad = (Console.WindowWidth - text.Length) / 2;
            Console.SetCursorPosition(leftPad, row);
            Console.Write(text);
        }

    }
}
