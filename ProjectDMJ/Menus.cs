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
                Console.WriteLine("Press enter to return to main menu");
                Console.ReadLine();
                ShowMenu(gameLibrary);
            }
            else if (option.Key == ConsoleKey.NumPad2)
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
                DateTime gameReleaseDate = Convert.ToDateTime(Console.ReadLine());
                games.AddNewgameToLibrary(gameLibrary, gameName, gameDeveloper, gameGenre, gameReleaseDate,dataManager.pathGamesDataFile);
                Console.WriteLine($"The game {gameName} is added to the library");
                Thread.Sleep(2000);
                ShowMenu(gameLibrary);
            }
            else if (option.Key == ConsoleKey.NumPad3)
            {
                SelectDeleteGame(gameLibrary);
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

        public void PrintAdvancedInfo(List<Games> gameLibrary)
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

        public void PrintListTitles(List<Games> gameLibrary)
        {
            foreach (var game in gameLibrary)
            {
                Console.WriteLine($"{game.ID}.{game.Name}");
            }
        }

        public List<Games> SortList(List<Games> gameLibrary)
        {
            return gameLibrary.OrderBy(a => a.Name).ToList();
        }

        public void SelectDeleteGame(List<Games> gameLibrary)
        {
            Console.Clear();
            MenuLogo();
            Console.WriteLine("Choose game you wish to delete:");
            PrintListTitles(gameLibrary);
            int deletedId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Are you sure? (y/n)");
            DeleteGameConfirmation(gameLibrary, deletedId);
            Console.WriteLine("Delete another game? (y/n)");
            SelectDeleteMoreGames(gameLibrary);
        }

        public void SelectDeleteMoreGames(List<Games> gameLibrary)
        {
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);
            if (option.Key == ConsoleKey.Y)
            {
                SelectDeleteGame(gameLibrary);
            }
            else if (option.Key == ConsoleKey.N)
            {
                Console.WriteLine("Returning to main menu");
                Thread.Sleep(2000);
                ShowMenu(gameLibrary);
            }
            else
            {
                Console.WriteLine("Please choose y or n");
                Thread.Sleep(1000);
                SelectDeleteMoreGames(gameLibrary);
            }
        }

        public void DeleteGameConfirmation(List<Games> gameLibrary, int deletedId)
        {
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);
            if (option.Key == ConsoleKey.Y)
            {
                games.DeleteGame(gameLibrary, deletedId,dataManager.pathGamesDataFile);
            }
            else if (option.Key == ConsoleKey.N)
            {
                Console.WriteLine("Delete canceled");
            }
            else
            {
                Console.WriteLine("Please choose y or n");
                Thread.Sleep(1000);
                DeleteGameConfirmation(gameLibrary, deletedId);
            }
        }
    }
}