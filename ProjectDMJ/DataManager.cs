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

        public void CheckIfDataFileExists(List<Games> gameLibrary, string path, string properties)
        {
            if (!File.Exists(path))
            {
                DownloadOnlineDataFile(gameLibrary);
                WriteDataFile(gameLibrary, path,properties);
            }
            else
            {
                ReadGameLibraryFile(gameLibrary, path);
            }
        }

        public void DownloadOnlineDataFile(List<Games> gameLibrary)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string download = wc.DownloadString("https://raw.githubusercontent.com/JensVanGelder/ProjectDMJ/master/Games.csv");
            string[] gameLines = download.Split('\n');
            for (int i = 1; i < gameLines.Length - 1; i++)
            {
                string gameLine = gameLines[i];
                string[] data = gameLine.Split(',');
                Games game = new Games(data[0], data[1], data[2], Convert.ToDateTime(data[3]), Convert.ToInt32(data[4]));
                gameLibrary.Add(game);
            }
        }

        public void ReadGameLibraryFile(List<Games> gameLibrary, string path)
        {
            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
                string gameLine = lines[i];
                string[] data = gameLine.Split(',');
                Games game = new Games(data[0], data[1], data[2], Convert.ToDateTime(data[3]), Convert.ToInt32(data[4]));
                gameLibrary.Add(game);
            }
        }
        public void ReadUsersFile(List<Users> userLibrary, string path)
        {
            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
                string userLine = lines[i];
                string[] data = userLine.Split(',');
                List<Games> library = new List<Games>();
                ReadGameLibraryFile(library, pathUsersLibraryDataFile(data[0]));
                Users user = new Users(data[0], data[3], data[1], data[2], Convert.ToInt32(data[4]),library);
                userLibrary.Add(user);
            }
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
        public void WriteDataFile(List<Users> gameLibrary, string path, string properties)
        {
            using StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine(properties);
            for (int i = 0; i < gameLibrary.Count; i++)
            {
                writer.WriteLine(gameLibrary[i].Info());
            }
        }
    }
}