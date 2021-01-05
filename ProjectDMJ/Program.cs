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
            
            Menus menus = new Menus();

            
            dataManager.CheckIfDataFileExists(gameLibrary, dataManager.pathDataFile);
            menus.Menuname();
            menus.ShowMenu();



        }

    }
    
}