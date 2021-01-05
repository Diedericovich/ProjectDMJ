using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectDMJ
{
    internal class Menus
    {
        public void ShowMenu()
        {
            DataManager dataManager = new DataManager();
            Games games = new Games();
            List<Games> gameLibrary = new List<Games>();
            dataManager.CheckIfDataFileExists(gameLibrary, dataManager.pathDataFile);

            MenuLogo();

            Console.WriteLine("  MENU ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" 1. Show Game Libary ");
            Console.WriteLine();
            Console.WriteLine("2. Add New Game ");
            Console.WriteLine();
            Console.WriteLine("3. Delete Existing Game ");
            Console.WriteLine();
            Console.WriteLine("4. Exit ");
            Console.WriteLine();
            Console.WriteLine();

            SelectInMenu(gameLibrary);
            Console.ReadLine();
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
            int option = 1;

            Games games = new Games();

            switch (option)
            {
                case 1:
                    games.Info();
                    PrintAdvancedInfo(gameLibrary);
                    break;

                case 2:
                    games.AddNewgame(gameLibrary, "Zelda", "Nintendo", "Adventure", 1998);
                    break;

                case 3:
                    games.DeleteGame(gameLibrary, "Zelda");
                    break;

                case 4:
                    System.Environment.Exit(0);
                    break;
            }
        }

        private static void PrintAdvancedInfo(List<Games> gameLibrary)
        {
            Layout layout = new Layout();
            Console.WriteLine(layout.TopBox);
            Console.WriteLine(string.Format("│                 {0,-22} |           {1,-15} │         {2,-17} │", "Name", "Genre", "Developer"));

            foreach (var item in gameLibrary)
            {
                Console.WriteLine(item.AdvancedInfo());
            }
            Console.WriteLine(layout.BottomBox);
        }

        public List<Games> SortList(List<Games> gameLibrary)
        {
            return gameLibrary.OrderBy(a => a.Name).ToList();
        }
    }
}