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
            string Info = $"{Name} - {Developer} - {Genre} - {ReleaseDate}";
            return Info;
        }


    }
}