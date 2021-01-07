using System.Collections.Generic;
using System;

namespace ProjectDMJ
{
    internal class Games
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string developer;

        public string Developer
        {
            get { return developer; }
            set { developer = value; }
        }

        private string genre;

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        private DateTime releaseDate;

        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }
        private int id;
        public int ID
        {
            get{ return id;}
            set{ id = value;}
        }

        public string Info()
        {
            string Info = $"{Name},{Developer},{Genre},{ReleaseDate}";
            return Info;
        }

        public string AdvancedInfo()
        {
            Layout layout = new Layout();
            string items = $"\n│ {name,-38} | {genre,-25} │ {developer,-25} │{releaseDate.ToString("dd MMMM yyyy"),-25}│";

            return layout.connector + items;
        }

        public void AddNewgame(List<Games> gameLibrary, string name, string developer, string genre, DateTime releasedate)
        {
            Games game = new Games();
            DataManager manager = new DataManager();
            game.Name = name;
            game.Developer = developer;
            game.Genre = genre;
            game.ReleaseDate = releasedate;
            gameLibrary.Add(game);
            manager.WriteDataFile(gameLibrary,  manager.pathDataFile);
        }

        public void DeleteGame(List<Games> gameLibrary, int id)
        {
            int index = id - 1;
            var item = gameLibrary.Find(x => x.ID == id);
            if (index <= gameLibrary.Count && index >= 0)
            {
                Console.WriteLine($"De game {item.Name} is verwijderd uit de lijst.");
                gameLibrary.RemoveAll(x => x.ID == id);
            }
            else
            {
                Console.WriteLine("ERROR: Game does not exist");
            }
        }
    }
}