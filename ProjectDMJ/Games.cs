using System.Collections.Generic;

namespace ProjectDMJ
{
    internal class Games
    {
        private string name;

        public string Name
        {
            get{return name;}
            set{name = value;}
        }

        private string developer;

        public string Developer
        {
            get { return developer;}
            set { developer = value;}
        }

        private string genre;

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        private int releaseDate;

        public int ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }

        public string PrintInfo()
        {
            string Info = $"{Name},{Developer},{Genre},{ReleaseDate}";
            return Info;
        }

        public void Newgame(List<Games> gameLibrary, string name, string developer, string genre, int releasedate)
        {   
            Games game = new Games();
            game.Name = name;
            game.Developer = developer;
            game.Genre = genre;
            game.ReleaseDate = releasedate;
            gameLibrary.Add(game);
        }








        public void DeleteGame(List<Games>gameLibrary, string name)
        {
            for (int i = 0; i < gameLibrary.Count; i++)
            {
                if (gameLibrary[i].Name == name)
                {
                    gameLibrary.RemoveAt(i);
                }
            }
        }









    }
}