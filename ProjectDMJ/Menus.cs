using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDMJ
{
    class Menus
    {
     
        public void ShowMenu()
        {
            DataManager dataManager = new DataManager();
            Games games = new Games();
            List<Games> gameLibrary = new List<Games>();            
            dataManager.CheckIfDataFileExists(gameLibrary, dataManager.pathDataFile);


            Console.WriteLine("  MENU ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" 1. Show Game Libary ");
            Console.WriteLine();
            Console.WriteLine( "2. Add New Game " );
            Console.WriteLine();
            Console.WriteLine( "3. Delete Existing Game ");
            Console.WriteLine();
            Console.WriteLine( "4. Exit ");
            Console.WriteLine();
            Console.WriteLine();

            SelectInMenu(gameLibrary);

        }

        public void SelectInMenu(List<Games>gameLibrary)
        {
            int option = 1;

            Games games = new Games();

            switch (option)
            {
                case 1:
                    games.PrintInfo();
                    break;

                case 2:
                    games.AddNewgame(gameLibrary, "Zelda", "Nintendo", "Adventure", 1998);
                    break;

                case 3:
                    games.DeleteGame(gameLibrary, "Zelda");
                    break;

                case 4:
                    System.Environment.Exit(0);
                    break;

            }
        }




    }
}
