using System.Collections.Generic;

namespace ProjectDMJ
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();
            List<Games> gameLibrary = new List<Games>();
            Games games = new Games();
            dataManager.CheckIfDataFileExists(gameLibrary, dataManager.pathGamesDataFile,games.Properties());

            Menus menus = new Menus();
            menus.ShowMenu(gameLibrary);


            List<Games> userLibrary = new List<Games>();
            //dataManager.ReadUsersFile(users, dataManager.pathUsersDataFile);
            //UserMenus userMenus = new UserMenus();

            //userMenus.CreateUser(users, userLibrary);
            //userMenus.AddGameToLibrary(gameLibrary, users[3]);
            //userMenus.AddGameToLibrary(gameLibrary, users[3]);

            //foreach (var item in users)
            //{
            //    System.Console.WriteLine($"{item.Username},{item.RealName}");
            //    menus.PrintAdvancedInfo(item.Library);
            //}


        }
    }
}