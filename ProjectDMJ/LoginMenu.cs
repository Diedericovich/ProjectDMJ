using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDMJ
{
    internal class LoginMenu
    {
        private Games games = new Games();
        private Layout layout = new Layout();
        public Users users = new Users();
        public UserMenus userMenus = new UserMenus();



        public void ShowLoginMenu(List<Games> gameLibrary)
        {
            Menus menuClass = new Menus();

            Console.Clear();
            menuClass.MenuLogo();

            Console.WriteLine();

            Console.WriteLine(layout.buttonOne("1.Login Account"));
            Console.WriteLine(layout.buttonOne("2.Create Account"));
            Console.WriteLine(layout.buttonOne("3.Exit"));

            SelectInLoginMenu(gameLibrary);

        }

        public void SelectInLoginMenu(List<Games> gameLibrary)
        {
            Menus menuClass = new Menus();
            Games games = new Games();
            ConsoleKeyInfo option;
            option = Console.ReadKey(true);

            if (option.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                menuClass.MenuLogo();
                LoginAccount();
                Console.WriteLine();
                Console.WriteLine("Press enter to return to main menu");
                Console.ReadLine();
                ShowLoginMenu(gameLibrary);
            }
            else if (option.Key == ConsoleKey.NumPad2)
            {
                
            }
            else if (option.Key == ConsoleKey.NumPad3)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Choose one of the 3 Options");
                SelectInLoginMenu(gameLibrary);
            }






            void LoginAccount()
            {                
                Console.Clear();
                menuClass.MenuLogo();
                Console.WriteLine();
                Console.WriteLine("Login as User(1) or Admin(2)?");
                Console.WriteLine();
                int loginChoice = Convert.ToInt32(Console.ReadLine());

                while (loginChoice != '1' && loginChoice != '2')
                {
                    Console.WriteLine("Choose one of the 2 options");
                    loginChoice = Convert.ToChar(Console.ReadLine());
                }

                if (loginChoice == '1')
                {
                    Users users = new Users();
                    UserMenus userMenus = new UserMenus();
                    Console.Clear();
                    menuClass.MenuLogo();
                    LoginAsUser(users);


                }
                else if (loginChoice == '2')
                {
                    LoginAsAdmin(users);
                }



                void LoginAsUser(List<Users>users)
                {
                    List<Users> userLibrary = new List<Users>();
                    Console.Clear();
                    menuClass.MenuLogo();                    
                    Console.WriteLine();
                    Console.WriteLine("Username:");
                    Console.WriteLine();
                    string username = Console.ReadLine();

                    for (int i = 0; i < userLibrary.Count; i++)
                    {
                        if (username == userLibrary[i].Username)
                        {
                            Console.WriteLine("Connecting to User Profile Menu");
                        }
                        else
                        {
                            Console.WriteLine("The name is not in use");
                            Console.WriteLine();
                            Console.WriteLine("A new account will be created");

                        }
                    }


                }

                void LoginAsAdmin(List<Users> users)
                {

                }



            }


        }
    }
}

