using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjectDMJ
{
    class DataManager
    {
        public void ReadFile(List<Games> GameLibrary)
        {
            string[] lines = File.ReadAllLines("Games.csv");
            for (int i = 1; i < lines.Length; i++)
            {
                string gameLine = lines[i];
                string[] data = gameLine.Split(',');
                Games game = new Games()
                {
                    Name =  data[0],
                    Developer = data[1],
                    Genre = data[2],
                    ReleaseDate = Convert.ToInt32(data[3])
                };
                GameLibrary.Add(game);
            }
        }


    }
}
