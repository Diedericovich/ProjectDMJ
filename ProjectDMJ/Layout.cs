using System;

namespace ProjectDMJ
{
    internal class Layout
    {
        public string topBox = " ┌───────────────────────────────────────────┬───────────────────────────┬───────────────────────────┬─────────────────────────┐";
        public string header = string.Format(" │                 {0,-25} |           {1,-15} │         {2,-17} │       {3,-17} │", "Name", "Genre", "Developer", "Release Date");
        public string midBox = " |                                        |                           |                           |                         |";
        public string connector = " ├───────────────────────────────────────────┼───────────────────────────┼───────────────────────────┼─────────────────────────┤";
        public string bottomBox = " └───────────────────────────────────────────┴───────────────────────────┴───────────────────────────┴─────────────────────────┘";

        public string menuTitle = @"                                        ______        _       ____    ____  _______
                                        |_   _ `.     / \     |_   \  /   _||_   __ \
                                          | | `. \   / _ \      |   \/   |    | |__) |
                                          | |  | |  / ___ \     | |\  /| |    |  ___/
                                         _| |_.' /_/ /   \ \_  _| |_\/_| |_  _| |_
                                        |______.'|____| |____||_____||_____||_____|

";

        public string Button(string buttonTitle, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            string top = "                                              ┌──────────────────────────────┐\n";
            string mid = string.Format($"                                              |   {buttonTitle,-27}|\n");
            string bot = "                                              └──────────────────────────────┘ ";

            return top + mid + bot;
        }

        public string Button(string button, string button2, string button3, string button4)
        {
            string top = "┌────────────────────┬────────────────────┬────────────────────┬────────────────────┐\n";
            string mid = string.Format($"|   {button,-17}|   {button2,-17}|   {button3,-17}|   {button4,-17}|\n");
            string bottom = "└────────────────────┴────────────────────┴────────────────────┴────────────────────┘";
            return top + mid + bottom;
        }
        public string Button(string button, string button2, string button3, string button4, string button5, string button6)
        {
            string top = "┌────────────────────┬────────────────────┬────────────────────┬────────────────────┬────────────────────┬────────────────────┐\n";
            string mid = string.Format($"|   {button,-17}|   {button2,-17}|   {button3,-17}|   {button4,-17}|   {button5,-17}|   {button6,-17}|\n");
            string bottom = "└────────────────────┴────────────────────┴────────────────────┴────────────────────┴────────────────────┴────────────────────┘";
            return top + mid + bottom;
        }
    }
}