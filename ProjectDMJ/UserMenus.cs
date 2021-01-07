using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDMJ
{
    class UserMenus
    {
        public void CreateUser(List<Users>users,List<Games>userLibrary)
        {
            Console.Write("Username:");
            string username = Console.ReadLine();
            Console.Write("Email:");
            string email = Console.ReadLine();
            Console.Write("Country:");
            string country = Console.ReadLine();
            Console.Write("Real Name:");
            string realname = Console.ReadLine();
            Console.Write("Age:");
            int age = Convert.ToInt32(Console.ReadLine());

            Users user = new Users(username, email, country, realname, age, userLibrary);
            users.Add(user);
            DataManager dataManager = new DataManager();
            dataManager.WriteDataFile(users, dataManager.pathUsersDataFile,user.Properties());
            Games games = new Games();
            dataManager.WriteDataFile(user.Library, dataManager.pathUsersLibraryDataFile(user.Username), games.Properties());
        }
        public void AddGameToLibrary(List<Games> gameLibrary, Users user)
        {
            Menus menus = new Menus();
            menus.PrintListTitles(gameLibrary);
            Console.WriteLine("Choose game to add to your library");
            int index = Convert.ToInt32( Console.ReadLine());
            var item = gameLibrary.Find(x => x.ID == index);
            user.Library.Add(item);
            DataManager dataManager = new DataManager();
            Games games = new Games();
            dataManager.WriteDataFile(user.Library, dataManager.pathUsersLibraryDataFile(user.Username), games.Properties());
        }


        
        public void AccountMenu (List<Games> userLibrary)
        {   Menus menus = new Menus(); 
            Layout layout = new Layout();
            Users users = new Users ();
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);
            menus.MenuLogo();

            Console.WriteLine(layout.buttonOne("1.Make a new user"));
            Console.WriteLine(layout.buttonOne("2.Login"));
            Console.WriteLine(layout.buttonOne("3.Delete User"));
            Console.WriteLine(layout.buttonOne("4.Exit"));

            if (option.Key == ConsoleKey.NumPad1)
            {

            }
            else if (option.Key == ConsoleKey.NumPad2)
            {
                
            }
            else if (option.Key == ConsoleKey.NumPad3)
            {
                
            }
            else if (option.Key == ConsoleKey.NumPad4)
            {
                Environment.Exit(0);
            }
            else
            {
                
               
            }
        }


        
        }
    }

