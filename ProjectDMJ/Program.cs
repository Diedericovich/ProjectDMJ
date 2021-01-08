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
            
            Menus menus = new Menus();

            //menus.ShowMenu(gameLibrary);


            //TESTING GROUND
            Users user = new Users();
            List<Users> users = new List<Users>();
            dataManager.CheckIfDataFileExists(users, dataManager.pathUsersDataFile, user.Properties());

            UserMenus usermenus = new UserMenus();
            usermenus.AccountMenu(users[0].Library, users, users[0] );

            
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