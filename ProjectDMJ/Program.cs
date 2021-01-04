using System;
using System.Collections.Generic;

namespace ProjectDMJ
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();
            List<Games> GameLibrary = new List<Games>();

            dataManager.ReadFile(GameLibrary);

            foreach(Games item in GameLibrary)
            {
                Console.WriteLine(item.Name);
            }
            
        }
    }
}