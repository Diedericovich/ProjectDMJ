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
    }
}
