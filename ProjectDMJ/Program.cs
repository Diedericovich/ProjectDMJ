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

            dataManager.CheckIfDataFileExists(gameLibrary, dataManager.pathDataFile);

            foreach (Games item in gameLibrary)
            {
                Console.WriteLine(item.Name);
            }


            games.AddNewgame(gameLibrary,"Zelda", "Nintendo", "Adventure", 1998);
            Console.WriteLine();
            foreach (Games item in gameLibrary)
            {
                Console.WriteLine(item.Name);
            }

            games.DeleteGame(gameLibrary, "Zelda");
            Console.WriteLine();
            foreach (Games item in gameLibrary)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}