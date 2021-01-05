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

            dataManager.CheckIfDataFileExists(gameLibrary, dataManager.pathDataFile);

            foreach (Games item in gameLibrary)
            {
                Console.WriteLine(item.Name);
            }
         




        }
    }
}