using RoPaSci;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Set up console settings
        AsciiScreen.SetUpConsole();

        // Ask game mode and AI setting
        AsciiScreen.ShowWelcomeScreen();

        // Game loop


        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey(true);

    }
}