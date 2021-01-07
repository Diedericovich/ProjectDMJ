using System;

namespace ProjectDMJ
{
    internal class Layout
    {
        public string topBox = "┌────────────────────────────────────────┬───────────────────────────┬───────────────────────────┬─────────────────────────┐";
        public string header = string.Format("│                 {0,-22} |           {1,-15} │         {2,-17} │       {3,-17} │", "Name", "Genre", "Developer", "Release Date");
        public string midBox = "|                                        |                           |                           |                         |";
        public string connector = "├────────────────────────────────────────┼───────────────────────────┼───────────────────────────┼─────────────────────────┤";
        public string bottomBox = "└────────────────────────────────────────┴───────────────────────────┴───────────────────────────┴─────────────────────────┘";

        public string menuTitle = @"
 ____                                      ____
/\  _`\                                   /\  _`\
\ \ \L\_\     __       ___ ___       __   \ \ \L\ \      __      _ __   __  __
 \ \ \L_L   /'__`\   /' __` __`\   /'__`\  \ \ ,  /    /'__`\   /\`'__\/\ \/\ \
  \ \ \/, \/\ \L\.\_ /\ \/\ \/\ \ /\  __/   \ \ \\ \  /\ \L\.\_ \ \ \/ \ \ \_\ \
   \ \____/\ \__/.\_\\ \_\ \_\ \_\\ \____\   \ \_\ \_\\ \__/.\_\ \ \_\  \/`____ \
    \/___/  \/__/\/_/ \/_/\/_/\/_/ \/____/    \/_/\/ / \/__/\/_/  \/_/   `/___/> \
                                                                            /\___/
                                                                            \/__/
";

        public string buttonOne(string buttonTitle, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            string top = "┌────────────────────┐\n";
            string mid = string.Format($"|   {buttonTitle,-17}|\n");
            string bot = "└────────────────────┘";

            return top + mid + bot;
        }

        public string buttonFour(string button, string button2, string button3, string button4)
        {
            string top = "┌────────────────────┬────────────────────┬────────────────────┬────────────────────┐\n";
            string mid = string.Format($"|   {button,-17}|   {button2,-17}|   {button3,-17}|   {button4,-17}|\n");
            string bottom = "└────────────────────┴────────────────────┴────────────────────┴────────────────────┘";
            return top + mid + bottom;
        }
    }
}