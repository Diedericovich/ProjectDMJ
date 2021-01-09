using System.Collections.Generic;

namespace ProjectDMJ
{
    internal class Users
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        private string realName;

        public string RealName
        {
            get { return realName; }
            set { realName = value; }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private string color;

        public string Color
        {
            get { return color; }
            set
            {
                color = "Gray";
                color = value;
            }
        }

        private List<Games> library;

        public List<Games> Library
        {
            get { return library; }
            set { library = value; }
        }

        public Users(string username, string realname, string email, string country, int age, List<Games> library, string color)
        {
            Username = username;
            Email = email;
            Country = country;
            RealName = realname;
            Age = age;
            Library = library;
            Color = color;
        }

        public Users(string username, string realname, string email, string country, int age, List<Games> library)
        {
            Username = username;
            Email = email;
            Country = country;
            RealName = realname;
            Age = age;
            Library = library;
        }

        public Users()
        {
        }

        public string Info()
        {
            string Info = $"{Username},{RealName},{Email},{Country},{Age},{color}";
            return Info;
        }

        public string AdvancedInfo()
        {
            Layout layout = new Layout();
            string items = $"\n │ {username,-41} | {realName,-25} │ {email,-25} │ {country,-23} |";

            return layout.connector + items;
        }

        public string Properties()
        {
            return "Username,Real Name,Email,Country,Age";
        }
    }
}