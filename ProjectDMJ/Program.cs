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

            //Users user = new Users();
            //List<Users> users = new List<Users>();
            //List<Games> userLibrary = new List<Games>();
            //dataManager.ReadUsersFile(users, dataManager.pathUsersDataFile);
            //UserMenus userMenus = new UserMenus();

            ////userMenus.CreateUser(users, userLibrary);
            ////userMenus.AddGameToLibrary(gameLibrary, users[0]);
            //userMenus.AddGameToLibrary(gameLibrary, users[2]);

            //foreach (var item in users)
            //{
            //    System.Console.WriteLine($"{item.Username},{item.RealName}");
            //    menus.PrintAdvancedInfo(item.Library);
            //}


        }
    }
}