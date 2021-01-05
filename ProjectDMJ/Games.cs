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

        public void Newgame(string name, string genre, int releasedate)
        {

        }








        public void DeleteGame(List<Games>gameLibrary, string name)
        {
            for (int i = 0; i < gameLibrary.Length; i++)
            {
                if (gameLibrary[i].Name == name)
                {
                    gameLibrary.Remove(i);
                }
            }
        }









    }
}