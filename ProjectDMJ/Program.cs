using System;
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
            Layout layout = new Layout();
            Menus menu = new Menus();

            dataManager.CheckIfDataFileExists(gameLibrary, dataManager.pathDataFile);



        }

    }
}