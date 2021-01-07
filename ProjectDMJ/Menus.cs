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
            Console.WriteLine();

            Console.WriteLine(layout.buttonOne("1.Show library"));
            Console.WriteLine(layout.buttonOne("2.Add Game"));
            Console.WriteLine(layout.buttonOne("3.Delete Game"));
            Console.WriteLine(layout.buttonOne("4.Exit"));

            SelectInMenu(gameLibrary);
        }

        public void MenuLogo()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(layout.menuTitle);
        }

        public void SelectInMenu(List<Games> gameLibrary)
        {
            Games games = new Games();
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);

            switch (option.Key)
            {
                case ConsoleKey.NumPad1:
                    ShowLibrary(gameLibrary);
                    break;
                case ConsoleKey.NumPad2:
                    AddNewGame(gameLibrary);
                    break;
                case ConsoleKey.NumPad3:
                    SelectDeleteGame(gameLibrary);
                    break;
                case ConsoleKey.NumPad4:
                    dataManager.WriteDataFile(gameLibrary, dataManager.pathGamesDataFile, games.Properties());
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choose one of the 4 Options");
                    SelectInMenu(gameLibrary);
                    break;
            }
        }

        public void ShowLibrary(List<Games> gameLibrary)
        {
            Console.Clear();
            MenuLogo();
            PrintAdvancedInfo(gameLibrary);
            while (true)
                {
                    SortList(gameLibrary);
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
            gameLibrary = gameLibrary.OrderBy(a => a.ID).ToList();
            foreach (var game in gameLibrary)
            {
                Console.WriteLine($"{game.ID}.{game.Name}");
            }
        }

        public void SortList(List<Games> gameLibrary)
        {
            Console.WriteLine("1.SortName,2.SortRelease,3.SortDev,4.SortGenre,5.SortId,6.Back");
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);

            switch (option.Key)
            {
                case ConsoleKey.NumPad1:
                    {
                        gameLibrary = gameLibrary.OrderBy(a => a.Name).ToList();
                        break;
                    }

                case ConsoleKey.NumPad2:
                    {
                        gameLibrary = gameLibrary.OrderBy(a => a.ReleaseDate).ToList();
                        break;
                    }

                case ConsoleKey.NumPad3:
                    {
                        gameLibrary = gameLibrary.OrderBy(a => a.Developer).ToList();
                        break;
                    }

                case ConsoleKey.NumPad4:
                    {
                        gameLibrary = gameLibrary.OrderBy(a => a.Genre).ToList();
                        break;
                    }

                case ConsoleKey.NumPad5:
                    {
                        gameLibrary = gameLibrary.OrderBy(a => a.ID).ToList();
                        break;
                    }

                case ConsoleKey.NumPad6:
                    gameLibrary = gameLibrary = gameLibrary.OrderBy(a => a.ID).ToList();
                    ShowMenu(gameLibrary);
                    break;
                default:
                    Console.WriteLine("Error: Sort option not found");
                    Thread.Sleep(1500);
                    break;
            }
            ShowLibrary(gameLibrary);
        }

        public void AddAnotherGame(List<Games> gameLibrary)
        {
            Console.WriteLine("Do you want to add another game to your Library?");
            Console.WriteLine();
            Console.WriteLine("Y / N ");
            Console.WriteLine();
            char addAnotherGame = Convert.ToChar(Console.ReadLine());

            while (addAnotherGame != 'Y' && addAnotherGame != 'N')
            {
                Console.WriteLine("Choose Y for Yes or N for No. Please try again.");
                addAnotherGame = Convert.ToChar(Console.ReadLine());
            }

            if (addAnotherGame == 'Y')
            {
                Console.Clear();
                MenuLogo();
                AskInfoNewGame(gameLibrary);
                AddAnotherGame(gameLibrary);
            }
            else if (addAnotherGame == 'N')
            {
                Console.Write("Going back to menu in 3");
                Thread.Sleep(500);
                Console.Write(" 2");
                Thread.Sleep(500);
                Console.Write(" 1");
                Thread.Sleep(500);
                ShowMenu(gameLibrary);
            }
        }

        public void AddNewGame(List<Games> gameLibrary)
        {
            Console.Clear();
            MenuLogo();
            AskInfoNewGame(gameLibrary);
            AddAnotherGame(gameLibrary);
            Thread.Sleep(2000);
            ShowMenu(gameLibrary);
        }

        public void AskInfoNewGame(List<Games> gameLibrary)
        {
            Games games = new Games();

            Console.WriteLine("Enter the name of your game");
            string gameName = Console.ReadLine();
            CheckInputExists(gameName, gameLibrary);
            Console.WriteLine("Who is the developer of the game");
            string gameDeveloper = Console.ReadLine();
            Console.WriteLine("Which genre is the game");
            string gameGenre = Console.ReadLine();
            Console.WriteLine("What is the releasedate of the game");
            DateTime gameReleaseDate = Convert.ToDateTime(Console.ReadLine());
            gameLibrary = games.AddNewgameToLibrary(gameLibrary, gameName, gameDeveloper, gameGenre, gameReleaseDate, dataManager.pathGamesDataFile);
            Console.WriteLine($"The game {gameName} is added to the library");
            Console.WriteLine();
        }

        public void CheckInputExists(string gameName, List<Games> gameLibrary)
        {
            for (int i = 0; i < gameLibrary.Count; i++)
            {
                if (gameName == gameLibrary[i].Name)
                {
                    Console.WriteLine($"This game already exists. Enter new title.");
                    Thread.Sleep(1500);
                    AddNewGame(gameLibrary);
                    break;
                }
            }
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
                games.DeleteGame(gameLibrary, deletedId, dataManager.pathGamesDataFile);
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