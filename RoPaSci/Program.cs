using RoPaSci;
using System;

public class Program
{
    /// <summary>
    /// Moves ENUM
    /// </summary>  
    public enum Move
    {
        Rock,
        Paper,
        Scissors,
        Lizard,
        Spock,
        None
    }

    private static List<Move>? AllowedMoves;
    private static RandAI? SelectedAI;


    public static void Main(string[] args)
    {
        // Set up console settings
        AsciiScreen.SetUpConsole();
        AsciiScreen.ShowWelcomeScreen();

        // Ask game mode
        List<string> gameModes =
        [
            "Rock, Paper, Scissors",
            "Rock, Paper, Scissors, Lizard, Spock",
        ];
        int gameMode = AsciiScreen.GameSetUpChoice(gameModes);
        switch (gameMode)
        {
            case 0:
                // Initialize game logic for RPS
                AllowedMoves = [Move.Rock, Move.Paper, Move.Scissors];
                break;
            case 1:
                // Initialize game logic for RPSLS
                AllowedMoves = [Move.Rock, Move.Paper, Move.Scissors, Move.Lizard, Move.Spock];
                break;
            default:
                return;
        }

        // Ask AI type
        List<string> aiTypes =
        [
            "Random AI",
            "Last Choice AI"
        ];
        int aiType = AsciiScreen.GameSetUpChoice(aiTypes);
        switch (aiType)
        {
            case 0:
                // Initialize Random AI
                SelectedAI = new RandAI(AllowedMoves);
                break;
            case 1:
                // Initialize Last Choice AI
                SelectedAI = new LastChoiceAI(AllowedMoves);
                break;
            default:
                return;
        }


        // Game loop
        bool gameRunning = true;
        while (gameRunning)
        {
            // AI decides move
            Move aiMove = SelectedAI.GetMove();
            // Get player input
            Move playerMove = AsciiScreen.ShowMoveChoice(AllowedMoves);
            // Determine outcome
            Console.WriteLine($"\nYou chose: {playerMove}");
            Console.WriteLine($"AI chose: {aiMove}");


            // Update AI knowledge with player move
            SelectedAI.UpdateKnowledge(playerMove);

            // Ask if the player wants to continue
            AsciiScreen.AskToPlayAgain();
        }


        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey(true);

    }
}