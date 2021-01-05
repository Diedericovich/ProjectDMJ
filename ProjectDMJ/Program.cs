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
            dataManager.CheckIfDataFileExists(gameLibrary, dataManager.pathDataFile);

            Menus menus = new Menus();
            menus.ShowMenu(gameLibrary);
        }
    }
}