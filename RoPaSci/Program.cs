using RoPaSci;
using System;

public class Program
{

    public enum Move
    {
        Rock,
        Paper,
        Scissors,
        Lizard,
        Spock,
        None
    }

    public static readonly Dictionary<Move, List<Move>> WinningMoves = new()
    {
        { Move.Rock, [Move.Scissors, Move.Lizard] },
        { Move.Paper, [Move.Rock, Move.Spock] },
        { Move.Scissors, [Move.Paper, Move.Lizard] },
        { Move.Lizard, [Move.Spock, Move.Paper] },
        { Move.Spock, [Move.Scissors, Move.Rock] }
    };

    public static readonly Dictionary<Move, List<Move>> LosingMoves;

    private static List<Move>? AllowedMoves;
    private static RandAI? SelectedAI;

 
    static Program()
    {
        LosingMoves = [];
        foreach (Move move in WinningMoves.Keys)
        {
            LosingMoves[move] = WinningMoves.Where(
                kv => kv.Value.Contains(move)
                ).Select(kv => kv.Key).ToList();
        }
    }

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
            AsciiScreen.PrintMoves(playerMove, aiMove);

            if (playerMove == aiMove)
            {
                AsciiScreen.ShowOutcome("It's a tie!");
            }
            else if (WinningMoves[playerMove].Contains(aiMove))
            {
                AsciiScreen.ShowOutcome("You win!!");

            }
            else if (WinningMoves[aiMove].Contains(playerMove))
            {
                AsciiScreen.ShowOutcome("AI wins!");

            }
            else
            {
                // Something went wrong, perhaps invalid move
                continue;
            }

            // Update AI knowledge with player move
            SelectedAI.UpdateKnowledge(playerMove);

            // Ask if the player wants to continue
            AsciiScreen.AskToPlayAgain();
        }


        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey(true);

    }
}