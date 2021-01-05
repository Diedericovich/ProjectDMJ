using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProjectDMJ
{
    internal class Menus
    {
        DataManager dataManager = new DataManager();
        Games games = new Games();
        public void ShowMenu(List<Games> gameLibrary)
        {

            Console.Clear();
            MenuLogo();

            Console.WriteLine("  MENU ");
            Console.WriteLine();

            Console.WriteLine("1. Show Game Libary ");
            Console.WriteLine();
            Console.WriteLine("2. Add New Game ");
            Console.WriteLine();
            Console.WriteLine("3. Delete Existing Game ");
            Console.WriteLine();
            Console.WriteLine("4. Exit ");
            Console.WriteLine();
            Console.WriteLine();

            SelectInMenu(gameLibrary);

            
        }

        public void MenuLogo()
        {
            string menuTitle = @" 
                                                                                                                                                                
                                                                                                                                                                
        
 ____                                      ____                                   
/\  _`\                                   /\  _`\                                 
\ \ \L\_\     __       ___ ___       __   \ \ \L\ \      __      _ __   __  __    
 \ \ \L_L   /'__`\   /' __` __`\   /'__`\  \ \ ,  /    /'__`\   /\`'__\/\ \/\ \   
  \ \ \/, \/\ \L\.\_ /\ \/\ \/\ \ /\  __/   \ \ \\ \  /\ \L\.\_ \ \ \/ \ \ \_\ \  
   \ \____/\ \__/.\_\\ \_\ \_\ \_\\ \____\   \ \_\ \_\\ \__/.\_\ \ \_\  \/`____ \ 
    \/___/  \/__/\/_/ \/_/\/_/\/_/ \/____/    \/_/\/ / \/__/\/_/  \/_/   `/___/> \
                                                                            /\___/
                                                                            \/__/ 
                                                                                    
                          
──────────────███████──███████
──────────████▓▓▓▓▓▓████░░░░░██
────────██▓▓▓▓▓▓▓▓▓▓▓▓██░░░░░░██
──────██▓▓▓▓▓▓████████████░░░░██
────██▓▓▓▓▓▓████████████████░██
────██▓▓████░░░░░░░░░░░░██████
──████████░░░░░░██░░██░░██▓▓▓▓██
──██░░████░░░░░░██░░██░░██▓▓▓▓██
██░░░░██████░░░░░░░░░░░░░░██▓▓██
██░░░░░░██░░░░██░░░░░░░░░░██▓▓██
──██░░░░░░░░░███████░░░░██████
────████░░░░░░░███████████▓▓██
──────██████░░░░░░░░░░██▓▓▓▓██
────██▓▓▓▓██████████████▓▓██
──██▓▓▓▓▓▓▓▓████░░░░░░████
████▓▓▓▓▓▓▓▓██░░░░░░░░░░██
████▓▓▓▓▓▓▓▓██░░░░░░░░░░██
██████▓▓▓▓▓▓▓▓██░░░░░░████████
──██████▓▓▓▓▓▓████████████████
────██████████████████████▓▓▓▓██
──██▓▓▓▓████████████████▓▓▓▓▓▓██
████▓▓██████████████████▓▓▓▓▓▓██
██▓▓▓▓██████████████████▓▓▓▓▓▓██
██▓▓▓▓██████████──────██▓▓▓▓████
██▓▓▓▓████──────────────██████
";

            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(menuTitle);
            Console.ResetColor();
        }

        public void SelectInMenu(List<Games> gameLibrary)
        {
            Games games = new Games();
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);


            if (option.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                MenuLogo();
                PrintAdvancedInfo(gameLibrary);
                Console.WriteLine();
                Console.WriteLine("Press enter to return to main menu");
                Console.ReadLine();
                ShowMenu(gameLibrary);
            }
            else if(option.Key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                MenuLogo();
                Console.WriteLine("Enter the name of your game");
                string gameName = Console.ReadLine();
                Console.WriteLine("Who is the developer of the game");
                string gameDeveloper = Console.ReadLine();
                Console.WriteLine("Which genre is the game");
                string gameGenre = Console.ReadLine();
                Console.WriteLine("What is the releasedate of the game");
                int gameReleaseDate = Convert.ToInt32(Console.ReadLine());
                games.AddNewgame(gameLibrary, gameName, gameDeveloper, gameGenre, gameReleaseDate);
                Console.WriteLine($"The game {gameName} is added to the library");
                Thread.Sleep(2000);
                ShowMenu(gameLibrary);

            }
            else if (option.Key == ConsoleKey.NumPad3)
            {
                Console.Clear();
                MenuLogo();
                Console.WriteLine("Welke gametitle wil je deleten?");
                string deletedName = Console.ReadLine();
                
                games.DeleteGame(gameLibrary, deletedName);
                Console.WriteLine($"De game {deletedName} is verwijderd uit de lijst.");
                Thread.Sleep(2000);
                ShowMenu(gameLibrary);

            }

            else if (option.Key == ConsoleKey.NumPad4)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Choose one of the 4 Options");
                SelectInMenu(gameLibrary);
            }
        }

        private static void PrintAdvancedInfo(List<Games> gameLibrary)
        {
            Layout layout = new Layout();
            Console.WriteLine(layout.topBox);
            Console.WriteLine(string.Format("│                 {0,-22} |           {1,-15} │         {2,-17} │", "Name", "Genre", "Developer"));

            foreach (var item in gameLibrary)
            {
                Console.WriteLine(item.AdvancedInfo());
            }
            Console.WriteLine(layout.bottomBox);
        }

        public List<Games> SortList(List<Games> gameLibrary)
        {
            return gameLibrary.OrderBy(a => a.Name).ToList();
        }
    }
}