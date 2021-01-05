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
            Games game = new Games();

            dataManager.CheckIfDataFileExists(gameLibrary, dataManager.pathDataFile);

            foreach (Games item in gameLibrary)
            {
                Console.WriteLine(item.Name);
            }


            game.DeleteGame(gameLibrary, "Dota2");

            foreach (Games item in gameLibrary)
            {
                Console.WriteLine(item.Name);
            }

        }
    }
}