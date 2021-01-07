using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectDMJ
{
    internal class Games
    {
        private DataManager manager = new DataManager();
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


        public Games(string name, string developer, string genre, DateTime releasedate, int id)
        {
            Name = name;
            Developer = developer;
            Genre = genre;
            ReleaseDate = releasedate;
            ID = id;
        }

        public Games(string name, string developer, string genre, DateTime releasedate)
        {
            Name = name;
            Developer = developer;
            Genre = genre;
            ReleaseDate = releasedate;
        }

        public Games()
        {
        }

        public string Info()
        {
            string Info = $"{Name},{Developer},{Genre},{ReleaseDate.ToString("dd/MM/yyyy")},{ID}";
            return Info;
        }
        public string Properties()
        {
            return "Name,Developer,Genre,ReleaseDate";
        }

        public string AdvancedInfo()
        {
            Layout layout = new Layout();
            string items = $"\n│ {name,-38} | {genre,-25} │ {developer,-25} │ {ReleaseDate.ToString("dd/MM/yyyy"),-23} |";

            return layout.connector + items;
        }

        public List<Games> AddNewgameToLibrary(List<Games> gameLibrary, string name, string developer, string genre, DateTime releasedate, string path)
        {
            Games game = new Games(name, developer, genre, releasedate)
            {
                ID = gameLibrary[gameLibrary.Count-1].ID + 1
            };
            gameLibrary.Add(game);
            return gameLibrary;
        }

        public void DeleteGame(List<Games> gameLibrary, int id, string path)
        {
            var item = gameLibrary.Find(x => x.ID == id);

            if (item is null)
            {
                Console.WriteLine("ERROR: Game does not exist");
            }
            else
            {
                Console.WriteLine($"{item.Name} has been deleted from the library.");
                gameLibrary.RemoveAll(x => x.ID == id);
            }
        }
    }
}