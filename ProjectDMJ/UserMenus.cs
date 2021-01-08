using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace ProjectDMJ
{
    internal class UserMenus
    {
        public void CreateUser(List<Users> users, List<Games> userLibrary)
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
            dataManager.WriteDataFile(users, dataManager.pathUsersDataFile, user.Properties());
            Games games = new Games();
            dataManager.WriteDataFile(user.Library, dataManager.pathUsersLibraryDataFile(user.Username), games.Properties());
        }

        public void AddGameToLibrary(List<Games> gameLibrary, Users user)
        {
            Menus menus = new Menus();
            menus.PrintListTitles(gameLibrary);
            Console.WriteLine("Choose game to add to your library");
            int index = Convert.ToInt32(Console.ReadLine());
            var item = gameLibrary.Find(x => x.ID == index);
            user.Library.Add(item);
            DataManager dataManager = new DataManager();
            Games games = new Games();
            dataManager.WriteDataFile(user.Library, dataManager.pathUsersLibraryDataFile(user.Username), games.Properties());
        }

        public void AccountMenu(List<Games> userLibrary)
        {
            Menus menus = new Menus();
            Layout layout = new Layout();
            Users users = new Users();
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);
            menus.MenuLogo();

            Console.WriteLine(layout.Button("1.Make a new user"));
            Console.WriteLine(layout.Button("2.Login"));
            Console.WriteLine(layout.Button("3.Delete User"));
            Console.WriteLine(layout.Button("4.Exit"));

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

        public void ShowUserLibrary(Users user, List<Games> userLibrary)
        {
            Console.Clear();
            Menus menus = new Menus();
            Layout layout = new Layout();
            Console.WriteLine($"{user.Username},{user.RealName}");
            menus.PrintAdvancedInfo(userLibrary);

            //Console.WriteLine(layout.Button("1.SortName", "2.SortRelease","3.SortDev","4.SortGenre","5.SortId","6.Back"));
            //ConsoleKeyInfo option;
            //option = Console.ReadKey(true);

            //switch (option.Key)
            //{
            //    case ConsoleKey.NumPad1:
            //        {
            //            userLibrary = userLibrary.OrderBy(a => a.Name).ToList();
            //            break;
            //        }

            //    case ConsoleKey.NumPad2:
            //        {
            //            userLibrary = userLibrary.OrderBy(a => a.ReleaseDate).ToList();
            //            break;
            //        }

            //    case ConsoleKey.NumPad3:
            //        {
            //            userLibrary = userLibrary.OrderBy(a => a.Developer).ToList();
            //            break;
            //        }

            //    case ConsoleKey.NumPad4:
            //        {
            //            userLibrary = userLibrary.OrderBy(a => a.Genre).ToList();
            //            break;
            //        }

            //    case ConsoleKey.NumPad5:
            //        {
            //            userLibrary = userLibrary.OrderBy(a => a.ID).ToList();
            //            break;
            //        }

            //    case ConsoleKey.NumPad6:
            //        userLibrary = userLibrary.OrderBy(a => a.ID).ToList();

            //        break;

            //    default:
            //        Console.WriteLine("Error: Sort option not found");
            //        Thread.Sleep(1500);
            //        break;
            //}
            //ShowUserLibrary(user,userLibrary);
        }
    }
}