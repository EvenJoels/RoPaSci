using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;
using static System.Net.Mime.MediaTypeNames;

namespace RoPaSci
{
    public class AsciiScreen
    {

        // String for "rock" ascii art
        private const string RockArt = @"                                                 
                  @@@@@@@@@@@@@                  
              @@@               @@@              
           @@                       @@           
         @@                        @@ #@         
       @@                        @@     @@       
     -@               +@@@@@@@@@@         @@     
    @@          @@@@@%                     @@    
   .@         @@                            @@   
   @         @@                              @   
  @@         @  @                            @@  
  @          @  @                         %@@ @  
  @          @ @   @                    @@    @  
  @         @@ @  @                   @       @  
  @         @@ @  @  @     @ @@       @       @  
  @+          @  %@  @     @@  @@     @       @  
   @           @%@   @    @ @  @     @@      @#  
   @#            @  @*   @    +@    @@       @   
    @@            @@@       .@@    @@       @    
     @@              @@@@@@@  @@@@        @@     
      *@                  @@*            @@      
        @@                             @@        
          @@                         @@          
             @@=                  @@:            
                @@@@@@@@#@@@@@@@@                
                                                 ";

        private const string PaperArt = @"                                                 
                @@@@@@+...+@@@@@@                
             @@                   @@%            
          @@@@                       @@          
        @@    @@                       @@        
      @@         @@@#                    @@      
     @+              @@@@                 #@     
    @                    @@@                @    
   @*@@                     %@@              @   
  +@   @*                 @    @@            @-  
  @     *@                 @@    @            @  
  @       @              @@  =@@  #@          @  
  @       @           @@   @@   @@@@          @  
  @       @@            @@.   @@    @         @  
  @         @@     @@      @@    @@@          @  
  @@          @@    @@@@     @@    @         @@  
   @            @@   @  @@#    %@@@          @   
   -@            =@@@@     @@@@@            @.   
    @@                                     @@    
     .@                                   @      
       @@                               @@       
         @@                           @@         
           @@                       @@           
              @@@.             :@@@              
                  *@@@@@@@@@@@+                  
                                                 ";

        private const string ScissorArt = @"                                                 
                 @@@@@@@@@@@@@@@@                
             @@@                  @@@            
          @@@                        @@          
        @@                             @@        
       @                                 @@      
     @@                                    @     
    @@     @@                 @@@@@         @    
    @    @*   @@@@@-       @@*      @@#      @   
   @      @@        @@@@@-@            @@@@@@@@  
  %@         @@@         @     @@             @  
  @              @@@     @=   @ @             @  
  @                  @@@  @   @ @             @@ 
  @         @@@@@@@@@      @@@  @@            @- 
  @*   @.                         @@@         @  
   @   @              :@@@@@@@@@              @  
   @    @@@@@@@@@@@@          @@@            @@  
    @              @      =@@@   @      @@  =@   
     @              @@@@@@      @     @@    @    
      @               @      *@@@@@@@@    @@     
       @@               @@@@@            @       
         @@                            @@        
           @@.                      @@*          
              @@@               *@@@             
                  +@@@@@@@@@@@@                  
                                                 ";

        private const string LizardArt = @"                                                 
                *@@@@@@@@@@@@@@@%                
             @@#                 +@@             
          @@                         @@          
        @@              =              @@        
      +@            @@@   *@@#           @%      
     @@         @@@    #@@@@   @@@        @@     
    @-       @@@  =@@@@      @@@   @@@      @    
   @       -@                    @@@  @@     @   
   @       @           .%=           @@      @:  
  @        @        @@       :@@@@@@@@        @  
  @       @@         @     @@@    @           @  
  @       @            @@.       @@           @  
  @       @                    @@             @  
  @      @=                  @@               @  
  @@     @                @@                 @@  
   @     @              @@                   @   
   =@    #@           @@                    @#   
    @@    @           @                    @@    
     -@   @           @                   @#     
       @@ %@          @                 @@       
         @@@          @               =@         
           @@         @             @@           
             .@@@     @         @@@:             
                  @@@@@@@@@@@@@                  
                                                 ";

        private const string SpockArt = @"                                                 
                  @@@@@@@@@@@@@@                 
             =@@%                @@@             
           @@                        @@          
         @@           @@@@             @@        
       @@         .@@@    @     @@@@     @@      
      @           @   @   @    @   @      -@     
    *@            @   @   @   @    @@@      @    
    @             @   @   @@ @@   @  @@      @   
   @              @    @   @ @   @   @       @@  
  -@              @    @   @@   %@  @#        @  
  @:              @    @   @    @   @         @  
  @               @   @@@@    @@@  @@         @@ 
  @     @@@@      @             @  @          @* 
  @:   @     @@   @                 @         @  
  .@   @:       @@@                 @         @  
   @     @@         .@@@           :@        @@  
    @      @@           @@         @         @   
    +@       @@           @        @        @    
      @       %@          %@      @       *@     
       @@       @@              @@       @@      
         @=       @@            @      @@        
           @@     @@            @    @@          
             @@@. @=            @+@@             
                  @@@@@@@@@@@@@@                 
                                                 ";


        public static void SetUpConsole()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "RoPaSci - A Rock Paper Scissors Game";
            Console.CursorVisible = false;

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

        public static Move ShowMoveChoice(List<Program.Move> allowedMoves)
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
                    //Console.WriteLine($"\nYou chose: {allowedMoves[choice - 1]}");
                    return allowedMoves[choice - 1];
                }
                else
                {
                    Console.Beep(); // Invalid input, beep sound
                }
            }

            return Move.None;
            
        }

        public static void ShowOutcome(string outcome)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteCentredText(outcome, Console.WindowHeight - 4);
            Console.ResetColor();
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

        public static string GetMoveArt(Move move)
        {
            return move switch
            {
                Move.Rock => RockArt,
                Move.Paper => PaperArt,
                Move.Scissors => ScissorArt,
                Move.Lizard => LizardArt,
                Move.Spock => SpockArt,
                _ => "Invalid Move"
            };
        }


        /// <summary>
        /// Prints the ASCII art for the player's move and the AI's move side by side.
        /// This was generated using GitHub Copilot.
        /// </summary>
        public static void PrintMoves(Move playerMove, Move aiMove)
        {
            Console.Clear();
            string playerLabel = "You:";
            string aiLabel = "AI:";

            string playerArt = GetMoveArt(playerMove);
            string aiArt = GetMoveArt(aiMove);
            string[] playerLines = playerArt.Split([Environment.NewLine], StringSplitOptions.None);
            string[] aiLines = aiArt.Split([Environment.NewLine], StringSplitOptions.None);

            int playerWidth = playerLines.Max(l => l.Length);
            int aiWidth = aiLines.Max(l => l.Length);
            int separation = 6; // Space between the two arts

            int totalWidth = playerWidth + separation + aiWidth;
            int leftPad = Math.Max(0, (Console.WindowWidth - totalWidth) / 2);

            // Print labels centered above each art
            Console.SetCursorPosition(leftPad + (playerWidth - playerLabel.Length) / 2, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(playerLabel);

            Console.SetCursorPosition(leftPad + playerWidth + separation + (aiWidth - aiLabel.Length) / 2, 0);
            Console.Write(aiLabel);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            int maxLines = Math.Max(playerLines.Length, aiLines.Length);
            for (int i = 0; i < maxLines; i++)
            {
                string playerLine = i < playerLines.Length ? playerLines[i].PadRight(playerWidth) : new string(' ', playerWidth);
                string aiLine = i < aiLines.Length ? aiLines[i].PadRight(aiWidth) : new string(' ', aiWidth);

                Console.SetCursorPosition(leftPad, i + 1);
                Console.Write(playerLine);

                Console.SetCursorPosition(leftPad + playerWidth + separation, i + 1);
                Console.Write(aiLine);
            }
            Console.ResetColor();
        }


        private static void WriteCentredText(string text, int row)
        {
            int leftPad = (Console.WindowWidth - text.Length) / 2;
            Console.SetCursorPosition(leftPad, row);
            Console.Write(text);
        }

    }
}
