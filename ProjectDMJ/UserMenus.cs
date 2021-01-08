using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace ProjectDMJ
{
    internal class UserMenus
    {
        public Layout layout = new Layout();

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

        public void AccountMenu(List<Games> userLibrary, List<Users>userList, Users user)
        {
            Console.Clear();
            Menus menus = new Menus();
            Layout layout = new Layout();
            Users users = new Users();
            menus.MenuLogo();
            Console.WriteLine(layout.Button("1.Library", "2.Store", "3.Profile", "4.Friends"));
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);
           

            if (option.Key == ConsoleKey.NumPad1)
            {
                ShowUserLibrary(user, userLibrary);
            }
            else if (option.Key == ConsoleKey.NumPad2)
            {
                Console.WriteLine("Open Store");

            }
            else if (option.Key == ConsoleKey.NumPad3)
            {
                ShowUserProfileInfo(user);
            }
            else if (option.Key == ConsoleKey.NumPad4)
            {
                Console.WriteLine("Show List Friends");
            }
            else
            {

            }
            AccountMenu(userLibrary, userList, user);

        }

        public void ShowUserProfileInfo(Users user)
        {
            Console.WriteLine(user.Info());

            EditProfileInfo(user);
        }


       public void EditProfileInfo(Users user)
        {
            Console.WriteLine(layout.Button("5. Edit Profile"));
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);

            if (option.Key == ConsoleKey.NumPad5)
            {
                Console.WriteLine($"Username is {user.Username}");
                
                Console.WriteLine($"Email is {user.Email}");
                
                Console.WriteLine($"Country is {user.Country}");
                
                Console.WriteLine($"Real Name is {user.RealName}");

                Console.WriteLine($"Age is {user.Age}");

                Console.WriteLine("Which component do you want to change:");
                Console.WriteLine("1. Username");
                Console.WriteLine("2. Email");
                Console.WriteLine("3. Country");
                Console.WriteLine("4. Real Name");
                Console.WriteLine("5. Age");

                int decision = Convert.ToInt32(Console.ReadLine());

                while (decision != 1 && decision != 2 && decision != 3 && decision != 4 && decision != 5)
                {
                    
                    Console.Write("Choose one of the 5 options");
                    decision = Convert.ToInt32(Console.ReadLine());
                }

                if (decision == 1)
                {
                    Console.Write("Username:");
                    string username = Console.ReadLine();
                    user.Username = username;     
                   
                }

                else if(decision == 2)
                {
                    Console.Write("Email:");
                    string email = Console.ReadLine();
                    user.Email = email;
                }

                else if (decision == 3)
                {
                    Console.Write("Country:");
                    string country = Console.ReadLine();
                    user.Country = country;
                }

                else if (decision == 4)
                {
                    Console.Write("Real Name:");
                    string realname = Console.ReadLine();
                    user.RealName = realname;
                }

                else if (decision == 5)
                {
                    Console.Write("Age:");
                    int age = Convert.ToInt32(Console.ReadLine());
                    user.Age = age;
                }
                ShowUserProfileInfo(user);

            }
           
        }

        //public void AreYouSure ()
        //{
        //    Console.WriteLine("Do you want to change this? (Y/N)" );
        //    Console.WriteLine();
        //    char descision = Convert.ToChar(Console.ReadLine());

        //    while (descision != 'Y' && descision != 'N')
        //    {
                
        //        Console.Write("Choose Y for Yes or N for No. Please try again.");
        //        descision = Convert.ToChar(Console.ReadLine());
        //    }

        //    if (descision == 'Y')
        //    {
                                
        //    }
        //    else if (descision == 'N')
        //    {

        //    }

        //}



        public void ShowUserLibrary(Users user, List<Games> userLibrary)
        {
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