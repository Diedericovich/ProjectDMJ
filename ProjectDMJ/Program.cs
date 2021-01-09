using System.Collections.Generic;
using System;

namespace ProjectDMJ
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();
            Games games = new Games();
            List<Games> gameLibrary = new List<Games>();
            dataManager.CheckIfDataFileExists(gameLibrary, dataManager.pathGamesDataFile, games.Properties());

            List<Users> userList = new List<Users>();
            Users user = new Users();
            dataManager.CheckIfDataFileExists(userList, dataManager.pathUsersDataFile, user.Properties());
            AdminMenus menus = new AdminMenus();

            //menus.ShowMenu(gameLibrary);


            //TESTING GROUND

            string colorName = "Blue";
            ConsoleColor color;

            if (Enum.TryParse(colorName, out color))
            {
                Console.ForegroundColor = color;
                Console.WriteLine("This is your favorite color!");
            }

            LoginMenu login = new LoginMenu();
            login.ShowLoginMenu(gameLibrary,userList);
            //Users user = new Users();
            //List<Users> users = new List<Users>();
            //dataManager.CheckIfDataFileExists(users, dataManager.pathUsersDataFile, user.Properties());

            //UserMenus usermenus = new UserMenus();
            //usermenus.AccountMenu(users[0].Library, users, users[0] );


            //Users user = new Users();
            //List<Users> users = new List<Users>();
            //List<Games> userLibrary = new List<Games>();
            //dataManager.CheckIfDataFileExists(users, dataManager.pathUsersDataFile,user.Properties());
            //UserMenus userMenus = new UserMenus();

            //userMenus.CreateUser(users, userLibrary);
            //userMenus.AddGameToLibrary(gameLibrary, users[3]);
            //userMenus.AddGameToLibrary(gameLibrary, users[3]);
            //foreach (var item in users)
            //{
            //    Console.WriteLine(item.Username);
            //    menus.PrintAdvancedInfo(item.Library);

            //}
            //userMenus.AddGameToLibrary(gameLibrary, users[2]);
            //foreach (var item in users)
            //{
            //    Console.WriteLine(item.Username);
            //    menus.PrintAdvancedInfo(item.Library);

            //}
            //userMenus.ShowUserLibrary(users[1], users[1].Library);
        }
    }
}