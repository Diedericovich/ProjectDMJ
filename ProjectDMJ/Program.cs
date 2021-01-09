using System.Collections.Generic;
using System;

namespace ProjectDMJ
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();
            dataManager.CheckIfFolderExists();
            Games games = new Games();
            List<Games> gameLibrary = new List<Games>();
            dataManager.CheckIfDataFileExists(gameLibrary, dataManager.pathGamesDataFile, games.Properties());

            List<Users> userList = new List<Users>();
            Users user = new Users();
            dataManager.CheckIfDataFileExists(userList, dataManager.pathUsersDataFile, user.Properties());
            AdminMenus menus = new AdminMenus();



            LoginMenu login = new LoginMenu();
            login.ShowLoginMenu(gameLibrary,userList);

        }
    }
}