using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProjectDMJ
{
    internal class UserMenus
    {
        public Layout layout = new Layout();
        private bool AddingGame = true;

        public void AccountMenu(List<Games> userLibrary, List<Users> userList, Users user, List<Games> gameLibrary)
        {
            Console.SetWindowSize(129, 51);
            SetConsoleColor(user);
            ShowUserLibrary(user, userLibrary, userList, gameLibrary);
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);
            MainMenuControls(userLibrary, userList, user, gameLibrary, option);
            AccountMenu(userLibrary, userList, user, gameLibrary);
        }

        public void MainMenuControls(List<Games> userLibrary, List<Users> userList, Users user, List<Games> gameLibrary, ConsoleKeyInfo option)
        {
            switch (option.Key)
            {
                case ConsoleKey.NumPad1:
                    ShowMainTopBar(user);
                    ShowUserLibrary(user, userLibrary, userList, gameLibrary);
                    break;

                case ConsoleKey.NumPad2:
                    Console.WriteLine("Open Store");
                    break;

                case ConsoleKey.NumPad3:
                    Console.WriteLine("Show List Friends");
                    break;

                case ConsoleKey.NumPad4:
                    ShowUserProfileInfo(userLibrary, userList, user, gameLibrary);
                    break;

                case ConsoleKey.NumPad5:
                    DataManager dataManager = new DataManager();
                    dataManager.WriteDataFile(userList, dataManager.pathUsersDataFile, user.Properties());
                    LoginMenu login = new LoginMenu();
                    login.ShowLoginMenu(gameLibrary, userList);
                    break;
            }
        }

        public void ShowMainTopBar(Users user)
        {
            Console.Clear();
            AdminMenus adminMenus = new AdminMenus();
            adminMenus.MenuLogo();
            Console.WriteLine(layout.Button("1.Library", "2.Store", "3.Friends", $"4.{user.Username}", "5.Logout"));
        }

        public void ShowUserLibrary(Users user, List<Games> userLibrary, List<Users> userList, List<Games> gameLibrary)
        {
            ShowMainTopBar(user);
            AdminMenus adminMenus = new AdminMenus();
            bool isEmpty = !userLibrary.Any();
            if (isEmpty)
            {
                Console.WriteLine(layout.topBox);
                Console.WriteLine(layout.header);
                Console.WriteLine(layout.bottomBox);
                Console.WriteLine();
                Console.WriteLine("    No games found\n");
            }
            else
            {
                adminMenus.PrintAdvancedInfo(userLibrary);
            }
            Console.WriteLine(layout.Button("n.SortName", "r.SortRelease", "d.SortDev", "g.SortGenre", "i.SortId"));
            Console.WriteLine();
            Console.WriteLine(layout.Button("a.Add Game", "q.Remove Game"));
            LibraryControls(user, userLibrary, userList, gameLibrary);
        }

        public void LibraryControls(Users user, List<Games> userLibrary, List<Users> userList, List<Games> gameLibrary)
        {
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);

            switch (option.Key)
            {
                case ConsoleKey.N:

                    userLibrary = userLibrary.OrderBy(a => a.Name).ToList();
                    ShowUserLibrary(user, userLibrary, userList, gameLibrary);
                    break;

                case ConsoleKey.R:
                    userLibrary = userLibrary.OrderBy(a => a.ReleaseDate).ToList();
                    ShowUserLibrary(user, userLibrary, userList, gameLibrary);
                    break;

                case ConsoleKey.D:
                    userLibrary = userLibrary.OrderBy(a => a.Developer).ToList();
                    ShowUserLibrary(user, userLibrary, userList, gameLibrary);
                    break;

                case ConsoleKey.G:
                    userLibrary = userLibrary.OrderBy(a => a.Genre).ToList();
                    ShowUserLibrary(user, userLibrary, userList, gameLibrary);
                    break;

                case ConsoleKey.I:
                    userLibrary = userLibrary.OrderBy(a => a.ID).ToList();
                    ShowUserLibrary(user, userLibrary, userList, gameLibrary);
                    break;

                case ConsoleKey.A:
                    AddingGame = true;
                    ChangeLibrary(gameLibrary, userList, user, AddingGame);
                    ShowUserLibrary(user, userLibrary, userList, gameLibrary);
                    break;

                case ConsoleKey.Q:
                    AddingGame = false;
                    ChangeLibrary(gameLibrary, userList, user, AddingGame);
                    ShowUserLibrary(user, userLibrary, userList, gameLibrary);
                    break;
            }
            MainMenuControls(userLibrary, userList, user, gameLibrary, option);
        }

        public void ShowUserProfileInfo(List<Games> userLibrary, List<Users> userList, Users user, List<Games> gameLibrary)
        {
            ShowMainTopBar(user);
            Console.WriteLine($"\n   Username: {user.Username}");
            Console.WriteLine($"   Email: {user.Email}");
            Console.WriteLine($"   Country: {user.Country}");
            Console.WriteLine($"   Real Name: {user.RealName}");
            Console.WriteLine($"   Age: {user.Age}");
            Console.WriteLine($"   Games owned: {user.Library.Count}\n");
            ProfileControls(userLibrary, userList, user, gameLibrary);
        }

        public void ProfileControls(List<Games> userLibrary, List<Users> userList, Users user, List<Games> gameLibrary)
        {
            Console.WriteLine(layout.Box("6. Edit Profile"));
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);
            EditProfileInfo(userLibrary, userList, user, gameLibrary, option);
            ShowUserProfileInfo(userLibrary, userList, user, gameLibrary);
        }

        public void EditProfileInfo(List<Games> userLibrary, List<Users> userList, Users user, List<Games> gameLibrary, ConsoleKeyInfo option)
        {
            if (option.Key == ConsoleKey.NumPad6)
            {
                Console.WriteLine("Which component do you want to change:");
                Console.WriteLine("1. Username");
                Console.WriteLine("2. Email");
                Console.WriteLine("3. Country");
                Console.WriteLine("4. Real Name");
                Console.WriteLine("5. Age");
                Console.WriteLine("6. Profile Color");

                int decision = Convert.ToInt32(Console.ReadLine());

                while (decision != 1 && decision != 2 && decision != 3 && decision != 4 && decision != 5 && decision != 6)
                {
                    Console.Write("Choose one of the 5 options");
                    decision = Convert.ToInt32(Console.ReadLine());
                }

                if (decision == 1)
                {
                    Console.Write("Username:");
                    string username = Console.ReadLine();
                    user.Username = username;
                }
                else if (decision == 2)
                {
                    Console.Write("Email:");
                    string email = Console.ReadLine();
                    user.Email = email;
                }
                else if (decision == 3)
                {
                    Console.Write("Country:");
                    string country = Console.ReadLine();
                    user.Country = country;
                }
                else if (decision == 4)
                {
                    Console.Write("Real Name:");
                    string realname = Console.ReadLine();
                    user.RealName = realname;
                }
                else if (decision == 5)
                {
                    Console.Write("Age:");
                    int age = Convert.ToInt32(Console.ReadLine());
                    user.Age = age;
                }
                else if (decision == 6)
                {
                    Console.WriteLine("\n1.Default" +
                        "\n2.Red" +
                        "\n3.Blue" +
                        "\n4.Green" +
                        "\n5.Yellow" +
                        "\n6.Magenta");
                    Console.Write("Color: ");
                    option = Console.ReadKey(true);
                    ChangeUserColor(userList, user, gameLibrary, option);
                }
            }
            else
            {
                MainMenuControls(userLibrary, userList, user, gameLibrary, option);
            }
            DataManager dataManager = new DataManager();
            dataManager.WriteDataFile(userList, dataManager.pathUsersDataFile, user.Properties());
        }

        public void ChangeUserColor(List<Users> userList, Users user, List<Games> gameLibrary, ConsoleKeyInfo option)
        {
            if (option.Key == ConsoleKey.NumPad1)
            {
                user.Color = "Gray";
                SetConsoleColor(user);
            }
            else if (option.Key == ConsoleKey.NumPad2)
            {
                user.Color = "Red";
                SetConsoleColor(user);
            }
            else if (option.Key == ConsoleKey.NumPad3)
            {
                user.Color = "Blue";
                SetConsoleColor(user);
            }
            else if (option.Key == ConsoleKey.NumPad4)
            {
                user.Color = "Green";
                SetConsoleColor(user);
            }
            else if (option.Key == ConsoleKey.NumPad5)
            {
                user.Color = "Yellow";
                SetConsoleColor(user);
            }
            else if (option.Key == ConsoleKey.NumPad6)
            {
                user.Color = "Magenta";
                SetConsoleColor(user);
            }
            ShowUserProfileInfo(user.Library, userList, user, gameLibrary);
        }

        public void ChangeLibrary(List<Games> gameLibrary, List<Users> userList, Users user, bool trueIfAdd)
        {
            if (AddingGame == false)
            {
                PrintListTitles(user.Library);
                AdminMenus menus = new AdminMenus();
                Console.WriteLine("Choose game to add to your library");
                int index = Convert.ToInt32(Console.ReadLine());
                var game = user.Library.Find(x => x.ID == index);
                UpdateUserLibrary(user, game);
            }
            else
            {
                PrintListTitles(gameLibrary);
                AdminMenus menus = new AdminMenus();
                Console.WriteLine("Choose game to add to your library");
                int index = Convert.ToInt32(Console.ReadLine());
                var game = gameLibrary.Find(x => x.ID == index);
                CheckIfGameAlreadyInLibrary(gameLibrary, user.Library, userList, user, game);
                UpdateUserLibrary(user, game);
            }
            ShowUserLibrary(user, user.Library, userList, gameLibrary);
        }

        public void PrintListTitles(List<Games> gameLibrary)
        {
            gameLibrary = gameLibrary.OrderBy(a => a.ID).ToList();
            foreach (var game in gameLibrary)
            {
                if (game.ID >= 10)
                {
                    Console.WriteLine($"{game.ID}.{game.Name}");
                }
                else
                {
                    Console.WriteLine($"{game.ID}.{game.Name}");
                }
            }
        }

        public void CheckIfGameAlreadyInLibrary(List<Games> gameLibrary, List<Games> userLibrary, List<Users> userList, Users user, Games game)
        {
            for (int i = 0; i < userLibrary.Count; i++)
            {
                if (game.Name == userLibrary[i].Name)
                {
                    Console.WriteLine("Game already in library");
                    Thread.Sleep(2000);
                    ShowUserLibrary(user, userLibrary, userList, gameLibrary);
                    break;
                }
            }
        }

        public void UpdateUserLibrary(Users user, Games game)
        {
            if (AddingGame == true)
            {
                user.Library.Add(game);
                DataManager dataManager = new DataManager();
                Games games = new Games();
                dataManager.WriteDataFile(user.Library, dataManager.pathUsersLibraryDataFile(user.Username), games.Properties());
            }
            else if (AddingGame == false)
            {
                user.Library.Remove(game);
                DataManager dataManager = new DataManager();
                Games games = new Games();
                dataManager.WriteDataFile(user.Library, dataManager.pathUsersLibraryDataFile(user.Username), games.Properties());
            }
        }

        public void SetConsoleColor(Users user)
        {
            string colorName = user.Color;

            if (Enum.TryParse(colorName, out ConsoleColor color))
            {
                Console.ForegroundColor = color;
            }
        }
    }
}