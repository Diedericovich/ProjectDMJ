using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProjectDMJ
{
    internal class AdminMenus
    {
        private DataManager dataManager = new DataManager();
        private Games games = new Games();
        private Layout layout = new Layout();

        public void ShowMenu(List<Games> gameLibrary, List<Users> userList)
        {
            Console.Clear();
            Console.SetWindowSize(129, 27);
            MenuLogo();
            Console.WriteLine();

            Console.WriteLine(layout.Button("1.Show Library"));
            Console.WriteLine(layout.Button("2.Add Game"));
            Console.WriteLine(layout.Button("3.Delete Game"));
            Console.WriteLine(layout.Button("4.Show Users"));
            Console.WriteLine(layout.Button("5.Exit"));

            SelectInMenu(gameLibrary, userList);
        }

        public void MenuLogo()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", layout.menuTitle));
        }

        public void SelectInMenu(List<Games> gameLibrary, List<Users> userList)
        {
            Games games = new Games();
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);

            switch (option.Key)
            {
                case ConsoleKey.NumPad1:

                    ShowLibrary(gameLibrary, userList);
                    break;

                case ConsoleKey.NumPad2:
                    AddNewGame(gameLibrary, userList);
                    break;

                case ConsoleKey.NumPad3:
                    SelectDeleteGame(gameLibrary, userList);
                    break;

                case ConsoleKey.NumPad4:
                    ShowUsersMenu(gameLibrary, userList);
                    break;

                case ConsoleKey.NumPad5:
                    dataManager.WriteDataFile(gameLibrary, dataManager.pathGamesDataFile, games.Properties());
                    LoginMenu login = new LoginMenu();
                    login.ShowLoginMenu(gameLibrary, userList);
                    break;

                default:
                    Console.WriteLine("Choose one of the Options");
                    SelectInMenu(gameLibrary, userList);
                    break;
            }
        }

        public void ShowLibrary(List<Games> gameLibrary, List<Users> userList)
        {
            Console.Clear();
            Console.SetWindowSize(129, 51);
            MenuLogo();
            Console.WriteLine();
            Console.WriteLine(layout.Button("      Game Library"));
            PrintAdvancedInfo(gameLibrary);
            while (true)
            {
                SortList(gameLibrary, userList);
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
                if (game.ID >= 10)
                {
                    Console.WriteLine($"{game.ID,43}.{game.Name}");
                }
                else
                {
                    Console.WriteLine($"{game.ID,42}.{game.Name}");
                }
            }
        }

        public void SortList(List<Games> gameLibrary, List<Users> userList)
        {
            Console.WriteLine();
            Console.WriteLine(layout.Button("1.SortName", "2.SortRelease", "3.SortDev", "4.SortGenre", "5.SortId", "6.Back"));
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);

            switch (option.Key)
            {
                case ConsoleKey.NumPad1:
                    gameLibrary = gameLibrary.OrderBy(a => a.Name).ToList();
                    break;

                case ConsoleKey.NumPad2:
                    gameLibrary = gameLibrary.OrderBy(a => a.ReleaseDate).ToList();
                    break;

                case ConsoleKey.NumPad3:
                    gameLibrary = gameLibrary.OrderBy(a => a.Developer).ToList();
                    break;

                case ConsoleKey.NumPad4:
                    gameLibrary = gameLibrary.OrderBy(a => a.Genre).ToList();
                    break;

                case ConsoleKey.NumPad5:
                    gameLibrary = gameLibrary.OrderBy(a => a.ID).ToList();
                    break;

                case ConsoleKey.NumPad6:
                    gameLibrary = gameLibrary = gameLibrary.OrderBy(a => a.ID).ToList();
                    ShowMenu(gameLibrary, userList);
                    break;

                default:
                    Console.WriteLine("Error: Sort option not found");
                    Thread.Sleep(1500);
                    break;
            }
            ShowLibrary(gameLibrary, userList);
        }

        public void AddAnotherGame(List<Games> gameLibrary, List<Users> userList)
        {
            Console.WriteLine();
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) + 34) + "}", "Do you want to add another game to your Library? (Y / N) "));
            char addAnotherGame = Convert.ToChar(Console.ReadLine());

            while (addAnotherGame != 'Y' && addAnotherGame != 'N')
            {
                Console.WriteLine();
                Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) + 24) + "}", "Choose Y for Yes or N for No. Please try again."));
                addAnotherGame = Convert.ToChar(Console.ReadLine());
            }

            if (addAnotherGame == 'Y')
            {
                Console.Clear();
                MenuLogo();
                AskInfoNewGame(gameLibrary, userList);
                AddAnotherGame(gameLibrary, userList);
            }
            else if (addAnotherGame == 'N')
            {
                CountdownToMainMenu(gameLibrary, userList);
            }
        }

        public void AddNewGame(List<Games> gameLibrary, List<Users> userList)
        {
            Console.Clear();
            MenuLogo();
            AskInfoNewGame(gameLibrary, userList);
            AddAnotherGame(gameLibrary, userList);
            Thread.Sleep(2000);
            ShowMenu(gameLibrary, userList);
        }

        public void AskInfoNewGame(List<Games> gameLibrary, List<Users> userList)
        {
            Games games = new Games();

            string name = "Game name: ";
            string dev = "Game developer: ";
            string genre = "Genre: ";
            string date = "Release date (dd/mm/yyyy): ";
            Console.WriteLine();
            Console.WriteLine(layout.Button("      Adding Game"));
            Console.WriteLine("");
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) - 12) + "}", name));
            string gameName = Console.ReadLine();
            CheckInputExists(gameName, gameLibrary, userList);
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) - 7) + "}", dev));
            string gameDeveloper = Console.ReadLine();
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) - 16) + "}", genre));
            string gameGenre = Console.ReadLine();
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) + 4) + "}", date));
            DateTime gameReleaseDate = Convert.ToDateTime(Console.ReadLine());
            gameLibrary = games.AddNewgameToLibrary(gameLibrary, gameName, gameDeveloper, gameGenre, gameReleaseDate, dataManager.pathGamesDataFile);
            string added = "Game has been added to the library";
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) + 11) + "}", added));
            Console.WriteLine();
        }

        public void CheckInputExists(string gameName, List<Games> gameLibrary, List<Users> userList)
        {
            for (int i = 0; i < gameLibrary.Count; i++)
            {
                if (gameName == gameLibrary[i].Name)
                {
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + 19) + "}", "This game already exists. Enter new title."));
                    Thread.Sleep(1500);
                    AddNewGame(gameLibrary, userList);
                    break;
                }
            }
        }

        public void SelectDeleteGame(List<Games> gameLibrary, List<Users> userList)
        {
            Console.Clear();
            MenuLogo();
            Console.WriteLine();
            Console.WriteLine(layout.Button("      Deleting Game"));
            Console.WriteLine();
            PrintListTitles(gameLibrary);
            Console.WriteLine();
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) - 2) + "}", "Select Id to remove: "));
            int deletedId = Convert.ToInt32(Console.ReadLine());
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) - 4) + "}", $"Are you sure? (y/n)"));
            Console.WriteLine();
            DeleteGameConfirmation(gameLibrary, deletedId);
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) + 3) + "}", "Delete another game? (y/n)"));
            SelectDeleteMoreGames(gameLibrary, userList);
        }

        public void SelectDeleteMoreGames(List<Games> gameLibrary, List<Users> userList)
        {
            ConsoleKeyInfo option;
            Console.WriteLine();
            option = Console.ReadKey(true);
            if (option.Key == ConsoleKey.Y)
            {
                SelectDeleteGame(gameLibrary, userList);
            }
            else if (option.Key == ConsoleKey.N)
            {
                CountdownToMainMenu(gameLibrary, userList);
            }
            else
            {
                Console.Write("  Please choose y or n");
                Thread.Sleep(1000);
                SelectDeleteMoreGames(gameLibrary, userList);
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
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) - 8) + "}", "Delete canceled"));
            }
            else
            {
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + 12) + "}", "Please choose y or n"));
                Thread.Sleep(1000);
                DeleteGameConfirmation(gameLibrary, deletedId);
            }
        }

        public void ShowUsers(List<Users> userList)
        {
            Layout layout = new Layout();
            Console.WriteLine(layout.topBox);
            Console.WriteLine(layout.headerU);

            foreach (var item in userList)
            {
                Console.WriteLine(item.AdvancedInfo());
            }
            Console.WriteLine(layout.bottomBox);
        }

        public void ShowUsersMenu(List<Games> gameLibrary, List<Users> userList)
        {
            Console.SetWindowSize(129, 51);
            Console.Clear();
            MenuLogo();
            Console.WriteLine();
            Console.WriteLine(layout.Button("Users"));
            ShowUsers(userList);
            Console.WriteLine();
            Console.WriteLine(layout.Button("1.Return to Main Menu"));
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);
            if (option.Key == ConsoleKey.NumPad1)
            {
                ShowMenu(gameLibrary, userList);
            }
        }

        public void CountdownToMainMenu(List<Games> gameLibrary, List<Users> userList)
        {
            Console.WriteLine();
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2)) + "}", "Going back to menu in 3"));
            Thread.Sleep(750);
            Console.Write(" 2");
            Thread.Sleep(750);
            Console.Write(" 1");
            Thread.Sleep(750);
            ShowMenu(gameLibrary, userList);
        }
    }
}