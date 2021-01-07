using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectDMJ
{
    internal class DataManager
    {
        public string pathDataFile = "Games.csv";

        public void CheckIfDataFileExists(List<Games> gameLibrary, string path)
        {
            if (!File.Exists(path))
            {
                DownloadOnlineDataFile(gameLibrary);
                WriteDataFile(gameLibrary, path);
            }
            else
            {
                ReadFile(gameLibrary, path);
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
                Games game = new Games()
                {
                    Name = data[0],
                    Developer = data[1],
                    Genre = data[2],
                    ReleaseDate = Convert.ToDateTime(data[3]),
                    ID = i
                };
                gameLibrary.Add(game);
            }
        }

        public void ReadFile(List<Games> gameLibrary, string path)
        {
            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
                string gameLine = lines[i];
                string[] data = gameLine.Split(',');
                Games game = new Games()
                {
                    Name = data[0],
                    Developer = data[1],
                    Genre = data[2],
                    ReleaseDate = Convert.ToDateTime(data[3]),
                    ID = i
                };
                gameLibrary.Add(game);
            }
        }

        public void WriteDataFile(List<Games> gameLibrary, string path)
        {
            using StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine("Name,Developer,Genre,ReleaseDate");
            for (int i = 0; i < gameLibrary.Count; i++)
            {
                writer.WriteLine(gameLibrary[i].Info());
            }
        }
    }
}