using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectDMJ
{
    internal class DataManager
    {
        public string pathGamesDataFile = "Games.csv";
        public string pathUsersDataFile = "Users.csv";

        public string pathUsersLibraryDataFile(string username)
        { return $"UserLibraries/Library_{username}.csv"; }

        public void CheckIfFolderExists()
        {
            if (!Directory.Exists("UserLibraries"))
            {
                Directory.CreateDirectory("UserLibraries");
            }
        }

        public void CheckIfDataFileExists(List<Games> gameLibrary, string path, string properties)
        {
            if (!File.Exists(path))
            {
                DownloadOnlineDataFile(gameLibrary);
                WriteDataFile(gameLibrary, path, properties);
            }
            else
            {
                ReadGameLibraryFile(gameLibrary, path);
            }
        }

        public void CheckIfDataFileExists(List<Users> users, string path, string properties)
        {
            if (!File.Exists(path))
            {
                DownloadOnlineDataFile(users);
                WriteDataFile(users, path, properties);
            }
            else
            {
                ReadUsersFile(users, path);
            }
        }

        private void DownloadOnlineDataFile(List<Games> gameLibrary)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string download = wc.DownloadString("https://raw.githubusercontent.com/JensVanGelder/ProjectDMJ/master/Games.csv");
            string[] gameLines = download.Split('\n');
            HandleGame(gameLines, gameLibrary, 1);
        }

        private void DownloadOnlineDataFile(List<Users> userList)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string download = wc.DownloadString("https://raw.githubusercontent.com/JensVanGelder/ProjectDMJ/master/Users.csv");
            string[] userLines = download.Split('\n');
            HandleUser(userLines, userList, 1);
        }

        private void ReadGameLibraryFile(List<Games> gameLibrary, string path)
        {
            string[] lines = File.ReadAllLines(path);
            HandleGame(lines, gameLibrary);
        }

        private void ReadUsersFile(List<Users> userList, string path)
        {
            string[] lines = File.ReadAllLines(path);
            HandleUser(lines, userList);
        }

        public void WriteDataFile(List<Games> gameLibrary, string path, string properties)
        {
            using StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine(properties);
            for (int i = 0; i < gameLibrary.Count; i++)
            {
                writer.WriteLine(gameLibrary[i].Info());
            }
        }

        public void WriteDataFile(List<Users> userList, string path, string properties)
        {
            using StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine(properties);
            for (int i = 0; i < userList.Count; i++)
            {
                writer.WriteLine(userList[i].Info());
            }
        }

        private void HandleGame(string[] lines, List<Games> gameLibrary, int index = 0)
        {
            for (int i = 1; i < lines.Length - index; i++)
            {
                string gameLine = lines[i];
                string[] data = gameLine.Split(',');
                Games game = new Games(data[0], data[1], data[2], Convert.ToDateTime(data[3]), Convert.ToInt32(data[4]));
                gameLibrary.Add(game);
            }
        }

        private void HandleUser(string[] lines, List<Users> userList, int index = 0)
        {
            for (int i = 1; i < lines.Length - index; i++)
            {
                string userLine = lines[i];
                string[] data = userLine.Split(',');
                List<Games> library = new List<Games>();
                ReadGameLibraryFile(library, pathUsersLibraryDataFile(data[0]));
                Users user = new Users(data[0], data[1], data[2], data[3], Convert.ToInt32(data[4]), library, data[5]);
                userList.Add(user);
            }
        }
    }
}