using System;
using System.Collections.Generic;
using System.Threading;

namespace ProjectDMJ
{
    internal class LoginMenu
    {
        private Layout layout = new Layout();
        public Users users = new Users();
        public UserMenus userMenus = new UserMenus();

        public void ShowLoginMenu(List<Games> gameLibrary, List<Users> userList)
        {
            Console.SetWindowSize(129, 27);
            AdminMenus adminMenus = new AdminMenus();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            adminMenus.MenuLogo();

            Console.WriteLine();

            Console.WriteLine(layout.Button("1.Login Account"));
            Console.WriteLine(layout.Button("2.Create Account"));
            Console.WriteLine(layout.Button("3.Exit"));

            SelectInLoginMenu(gameLibrary, userList);
        }

        public void SelectInLoginMenu(List<Games> gameLibrary, List<Users> userList)
        {
            AdminMenus adminMenus = new AdminMenus();
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);

            if (option.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                adminMenus.MenuLogo();
                LoginAccount(gameLibrary, userList);
            }
            else if (option.Key == ConsoleKey.NumPad2)
            {
                CreateUser(userList);
                Console.WriteLine("Account creation succesful!");
                Thread.Sleep(1000);
                Console.Clear();
                ShowLoginMenu(gameLibrary, userList);
            }
            else if (option.Key == ConsoleKey.NumPad3)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Choose one of the 3 Options");
                SelectInLoginMenu(gameLibrary, userList);
            }
        }

        public void LoginAccount(List<Games> gameLibrary, List<Users> userList)
        {
            AdminMenus menuClass = new AdminMenus();
            UserMenus userMenu = new UserMenus();

            Console.Clear();
            menuClass.MenuLogo();
            Console.WriteLine();
            Console.WriteLine("Login name:");
            string username = Console.ReadLine();
            Console.WriteLine();

            if (username == "admin")
            {
                menuClass.ShowMenu(gameLibrary, userList);
            }
            else
            {
                CheckUserExists(username, userList, gameLibrary);
            }
        }

        public void CreateUser(List<Users> userList)
        {
            Console.Write("Username:");
            string username = Console.ReadLine();
            CheckUserExists(username, userList);
            Console.Write("Email:");
            string email = Console.ReadLine();
            Console.Write("Country:");
            string country = Console.ReadLine();
            Console.Write("Real Name:");
            string realname = Console.ReadLine();
            Console.Write("Age:");
            int age = Convert.ToInt32(Console.ReadLine());

            List<Games> userLibrary = new List<Games>();
            Users user = new Users(username, realname, email, country, age, userLibrary);
            userList.Add(user);
            DataManager dataManager = new DataManager();
            dataManager.WriteDataFile(userList, dataManager.pathUsersDataFile, user.Properties());
            Games games = new Games();
            dataManager.WriteDataFile(user.Library, dataManager.pathUsersLibraryDataFile(user.Username), games.Properties());
        }

        public void CheckUserExists(string username, List<Users> userList)
        {
            UserMenus userMenu = new UserMenus();
            for (int i = 0; i < userList.Count; i++)
            {
                if (username == userList[i].Username)
                {
                    Console.WriteLine("\nName already taken.");
                    Thread.Sleep(1000);
                    CreateUser(userList);
                }
            }
        }

        public void CheckUserExists(string username, List<Users> userList, List<Games> gameLibrary)
        {
            var user = userList.Find(x => x.Username == username);
            if (user is null)
            {
                Console.WriteLine("Account not found.");
                Thread.Sleep(1000);
                LoginAccount(gameLibrary, userList);
            }
            else
            {
                UserMenus userMenus = new UserMenus();
                List<Games> userLibrary = user.Library;
                userMenus.AccountMenu(userLibrary, userList, user, gameLibrary);
            }
        }
    }
}