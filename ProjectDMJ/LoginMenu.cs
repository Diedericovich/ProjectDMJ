using System;
using System.Collections.Generic;

namespace ProjectDMJ
{
    internal class LoginMenu
    {
        private Games games = new Games();
        private Layout layout = new Layout();
        public Users users = new Users();
        public UserMenus userMenus = new UserMenus();

        public void ShowLoginMenu(List<Games> gameLibrary, List<Users> userList)
        {
            Menus menuClass = new Menus();

            Console.Clear();
            menuClass.MenuLogo();

            Console.WriteLine();

            Console.WriteLine(layout.Button("1.Login Account"));
            Console.WriteLine(layout.Button("2.Create Account"));
            Console.WriteLine(layout.Button("3.Exit"));

            SelectInLoginMenu(gameLibrary, userList, userLibrary, user);
        }

        public void SelectInLoginMenu(List<Games> gameLibrary, List<Users> userList, List<Games> userLibrary, Users user)
        {
            Menus menuClass = new Menus();
            Games games = new Games();
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);

            if (option.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                menuClass.MenuLogo();
                LoginAccount(gameLibrary, userList);
                Console.WriteLine();
                Console.WriteLine("Press enter to return to main menu");
                Console.ReadLine();
                ShowLoginMenu(gameLibrary, userList, userLibrary, user);
            }
            else if (option.Key == ConsoleKey.NumPad2)
            {
            }
            else if (option.Key == ConsoleKey.NumPad3)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Choose one of the 3 Options");
                SelectInLoginMenu(gameLibrary, userList, userLibrary, user);
            }
        }

        public void LoginAccount(List<Games> gameLibrary, List<Users> userList)
        {
            Menus menuClass = new Menus();
            UserMenus userMenu = new UserMenus();

            Console.Clear();
            menuClass.MenuLogo();
            Console.WriteLine();
            Console.WriteLine("Login name:");
            string username = Console.ReadLine();
            Console.WriteLine();

            if (username == "admin")
            {
                menuClass.ShowMenu(gameLibrary);
            }
            else
            {
                for (int i = 0; i < userList.Count; i++)
                {
                    if (username == userList[i].Username)
                    {
                        List<Games> userLibrary = userList[i].Library;
                        userMenu.AccountMenu(userLibrary,userList,userList[i]);
                    }
                    else
                    {
                        Console.WriteLine("The name is not in use");
                        Console.WriteLine();
                        Console.WriteLine("A new account will be created");
                    }
                }

            }
        }
            

       
    }
}