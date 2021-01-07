using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProjectDMJ
{
    internal class Menus
    {    

        
        DataManager dataManager = new DataManager();
        Games games = new Games();
        Layout layout = new Layout();
        public void ShowMenu(List<Games> gameLibrary)
        {

            Console.Clear();
            MenuLogo();

            Console.WriteLine("  MENU ");
            Console.WriteLine();

            Console.WriteLine("1. Show Game Libary ");
            Console.WriteLine();
            Console.WriteLine("2. Add New Game ");
            Console.WriteLine();
            Console.WriteLine("3. Delete Existing Game ");
            Console.WriteLine();
            Console.WriteLine("4. Exit ");
            Console.WriteLine();
            Console.WriteLine();

            SelectInMenu(gameLibrary);

            
        }

        public void MenuLogo()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(layout.menuTitle);
            Console.ResetColor();
        }

        public void SelectInMenu(List<Games> gameLibrary)
        {
            Games games = new Games();
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);


            if (option.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                MenuLogo();
                PrintAdvancedInfo(gameLibrary);
                Console.WriteLine();
                Console.WriteLine("Press enter to return to main menu");
                Console.ReadLine();
                ShowMenu(gameLibrary);
            }
            else if(option.Key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                MenuLogo();
                AskInfoNewGame(gameLibrary);
                AddAnotherGame(gameLibrary);
                Thread.Sleep(2000);
                ShowMenu(gameLibrary);

            }
            else if (option.Key == ConsoleKey.NumPad3)
            {
                SelectDeleteGame(gameLibrary);

            }

            else if (option.Key == ConsoleKey.NumPad4)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Choose one of the 4 Options");
                SelectInMenu(gameLibrary);
            }
        }

        private static void PrintAdvancedInfo(List<Games> gameLibrary)
        {
            Layout layout = new Layout();
            Console.WriteLine(layout.topBox);
            Console.WriteLine(layout.header);

            foreach (var item in gameLibrary)
            {
                Console.WriteLine(item.AdvancedInfo());
            }
            Console.WriteLine(layout.bottomBox);
        }

        public List<Games> SortList(List<Games> gameLibrary)
        {
            return gameLibrary.OrderBy(a => a.Name).ToList();
        }

        public void AddAnotherGame(List<Games> gameLibrary)
        {

            Console.WriteLine("Do you want to add another game to your Library?");
            Console.WriteLine();
            Console.WriteLine("Y / N ");
            Console.WriteLine();
            char addAnotherGame = Convert.ToChar(Console.ReadLine());

            while (addAnotherGame != 'Y' && addAnotherGame != 'N')
            {
                Console.WriteLine("Choose Y for Yes or N for No. Please try again.");
                addAnotherGame = Convert.ToChar(Console.ReadLine());
            }

            if (addAnotherGame == 'Y')
            {
                Console.Clear();
                MenuLogo();
                AskInfoNewGame(gameLibrary);
                AddAnotherGame(gameLibrary);
            }

            else if (addAnotherGame == 'N')
            {
                Console.WriteLine("Go back to menu in 3 ");
                Console.Clear();
                Console.WriteLine("Go back to menu in 2 ");
                Console.Clear();
                Console.WriteLine("Go back to menu in 1 ");
                Thread.Sleep(2000);
                ShowMenu(gameLibrary);
            }
        }

        public void AskInfoNewGame(List<Games> gameLibrary)
            {
            Games games = new Games();

            Console.WriteLine("Enter the name of your game");
            string gameName = Console.ReadLine();
            Console.WriteLine("Who is the developer of the game");
            string gameDeveloper = Console.ReadLine();
            Console.WriteLine("Which genre is the game");
            string gameGenre = Console.ReadLine();
            Console.WriteLine("What is the releasedate of the game");
            DateTime gameReleaseDate = Convert.ToDateTime(Console.ReadLine());
            games.AddNewgame(gameLibrary, gameName, gameDeveloper, gameGenre, gameReleaseDate);
            Console.WriteLine($"The game {gameName} is added to the library");
            Console.WriteLine();
            }

        private static void PrintListTitles(List<Games> gameLibrary)
        {
            foreach (var game in gameLibrary)
            {
                Console.WriteLine($"{game.ID}.{game.Name}");
            }
        }
        public void SelectDeleteGame(List<Games> gameLibrary)
        {
            Console.Clear();
            MenuLogo();
            Console.WriteLine("Choose game you wish to delete:");
            PrintListTitles(gameLibrary);
            int deletedId = Convert.ToInt32(Console.ReadLine());
            games.DeleteGame(gameLibrary, deletedId);
            Console.WriteLine("Delete another game? (y/n)");
            SelectDeleteGameYesNo(gameLibrary);

        }
        public void SelectDeleteGameYesNo(List<Games> gameLibrary)
        {
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);
            if (option.Key == ConsoleKey.Y)
            {
                SelectDeleteGame(gameLibrary);
            }
            else if (option.Key == ConsoleKey.N)
            {
                Console.WriteLine("Returning to main menu");
                Thread.Sleep(2000);
                ShowMenu(gameLibrary);
            }
            else
            {
                Console.WriteLine("Please choose y or n");
                Thread.Sleep(2000);
                SelectDeleteGameYesNo(gameLibrary);
            }
        }

        public void CheckInputExists(string gameName, List<Games> gameLibrary)
        {
            for (int i = 0; i < gameLibrary.Count; i++)
            {
                if (gameName == gameLibrary[i].Name)
                {
                    Console.WriteLine("Deze game bestaat al in de library");
                }

                else if (gameName != gameLibrary[i].Name)

                {
                    Console.WriteLine("De game is toegevoegd");
                }
            }

        }
    }

        

    }
