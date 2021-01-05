using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProjectDMJ
{
    internal class Menus
    {
        private DataManager dataManager = new DataManager();
        private Games games = new Games();
        private Layout layout = new Layout();

        public void ShowMenu(List<Games> gameLibrary)
        {
            Console.Clear();
            MenuLogo();

            Console.WriteLine(layout.buttonOne("1.Show library",ConsoleColor.Red));
            Console.ResetColor();
            Console.WriteLine(layout.buttonOne("2. Add Game", ConsoleColor.White));
            Console.ResetColor();
            Console.WriteLine(layout.buttonOne("3. Delete Game"));
            Console.ResetColor();
            Console.WriteLine(layout.buttonOne("4. Exit", ConsoleColor.Blue));
            Console.ResetColor();

            Console.WriteLine(layout.buttonFour("1.Show library", "2. Add Game","3. Delete Game", "4. Exit"));
            SelectInMenu(gameLibrary);
        }

        public void MenuLogo()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(layout.menuTitle);
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(layout.buttonFour("Sort by name","Sort by devs","Sort by genre","Sort by release"));
                Console.ResetColor();
                while (true)
                {
                    PrintAdvancedInfo(SortList(gameLibrary));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(layout.buttonFour("Sort by name", "Sort by devs", "Sort by genre", "Sort by release"));
                    Console.ResetColor();
                }

            }
            else if (option.Key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                MenuLogo();
                Console.Write("Enter the name of your game: ");
                string gameName = Console.ReadLine();
                Console.Write("Who is the developer of the game: ");
                string gameDeveloper = Console.ReadLine();
                Console.Write("Which genre is the game: ");
                string gameGenre = Console.ReadLine();
                Console.Write("What is the releasedate of the game: ");
                DateTime gameReleaseDate = Convert.ToDateTime(Console.ReadLine());
                games.AddNewgame(gameLibrary, gameName, gameDeveloper, gameGenre, gameReleaseDate);
                Console.WriteLine($"The game {gameName} is added to the library");
                Thread.Sleep(2000);
                ShowMenu(gameLibrary);
            }
            else if (option.Key == ConsoleKey.NumPad3)
            {
                Console.Clear();
                MenuLogo();
                Console.Write("Choose game to Delete: ");
                string deletedName = Console.ReadLine();

                games.DeleteGame(gameLibrary, deletedName);
                Console.WriteLine($"Game {deletedName} has been removed.");
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
            Console.WriteLine(layout.header);

            foreach (var item in gameLibrary)
            {
                Console.WriteLine(item.AdvancedInfo());
            }
            Console.WriteLine(layout.bottomBox);
        }

        public List<Games> SortList(List<Games> gameLibrary)
        {
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);

            if (option.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                MenuLogo();
                return gameLibrary.OrderBy(a => a.Name).ToList();
            }
            else
            {
                ShowMenu(gameLibrary);
                return gameLibrary;
            }
        }
    }
}