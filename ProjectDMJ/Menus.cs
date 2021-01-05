using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDMJ
{
    class Menus
    {
        private static string menuTitle = @" 
                                                                                                                                                                
                                                                                                                                                                
        GGGGGGGGGGGGG                                                            RRRRRRRRRRRRRRRRR                                                              
     GGG::::::::::::G                                                            R::::::::::::::::R                                                             
   GG:::::::::::::::G                                                            R::::::RRRRRR:::::R                                                            
  G:::::GGGGGGGG::::G                                                            RR:::::R     R:::::R                                                           
 G:::::G       GGGGGG  aaaaaaaaaaaaa      mmmmmmm    mmmmmmm       eeeeeeeeeeee    R::::R     R:::::R  aaaaaaaaaaaaa  rrrrr   rrrrrrrrryyyyyyy           yyyyyyy
G:::::G                a::::::::::::a   mm:::::::m  m:::::::mm   ee::::::::::::ee  R::::R     R:::::R  a::::::::::::a r::::rrr:::::::::ry:::::y         y:::::y 
G:::::G                aaaaaaaaa:::::a m::::::::::mm::::::::::m e::::::eeeee:::::eeR::::RRRRRR:::::R   aaaaaaaaa:::::ar:::::::::::::::::ry:::::y       y:::::y  
G:::::G    GGGGGGGGGG           a::::a m::::::::::::::::::::::me::::::e     e:::::eR:::::::::::::RR             a::::arr::::::rrrrr::::::ry:::::y     y:::::y   
G:::::G    G::::::::G    aaaaaaa:::::a m:::::mmm::::::mmm:::::me:::::::eeeee::::::eR::::RRRRRR:::::R     aaaaaaa:::::a r:::::r     r:::::r y:::::y   y:::::y    
G:::::G    GGGGG::::G  aa::::::::::::a m::::m   m::::m   m::::me:::::::::::::::::e R::::R     R:::::R  aa::::::::::::a r:::::r     rrrrrrr  y:::::y y:::::y     
G:::::G        G::::G a::::aaaa::::::a m::::m   m::::m   m::::me::::::eeeeeeeeeee  R::::R     R:::::R a::::aaaa::::::a r:::::r               y:::::y:::::y      
 G:::::G       G::::Ga::::a    a:::::a m::::m   m::::m   m::::me:::::::e           R::::R     R:::::Ra::::a    a:::::a r:::::r                y:::::::::y       
  G:::::GGGGGGGG::::Ga::::a    a:::::a m::::m   m::::m   m::::me::::::::e        RR:::::R     R:::::Ra::::a    a:::::a r:::::r                 y:::::::y        
   GG:::::::::::::::Ga:::::aaaa::::::a m::::m   m::::m   m::::m e::::::::eeeeeeeeR::::::R     R:::::Ra:::::aaaa::::::a r:::::r                  y:::::y         
     GGG::::::GGG:::G a::::::::::aa:::am::::m   m::::m   m::::m  ee:::::::::::::eR::::::R     R:::::R a::::::::::aa:::ar:::::r                 y:::::y          
        GGGGGG   GGGG  aaaaaaaaaa  aaaammmmmm   mmmmmm   mmmmmm    eeeeeeeeeeeeeeRRRRRRRR     RRRRRRR  aaaaaaaaaa  aaaarrrrrrr                y:::::y           
                                                                                                                                             y:::::y                                                                                                                                                            
                          
──────────────███████──███████
──────────████▓▓▓▓▓▓████░░░░░██
────────██▓▓▓▓▓▓▓▓▓▓▓▓██░░░░░░██
──────██▓▓▓▓▓▓████████████░░░░██
────██▓▓▓▓▓▓████████████████░██
────██▓▓████░░░░░░░░░░░░██████
──████████░░░░░░██░░██░░██▓▓▓▓██
──██░░████░░░░░░██░░██░░██▓▓▓▓██
██░░░░██████░░░░░░░░░░░░░░██▓▓██
██░░░░░░██░░░░██░░░░░░░░░░██▓▓██
──██░░░░░░░░░███████░░░░██████
────████░░░░░░░███████████▓▓██
──────██████░░░░░░░░░░██▓▓▓▓██
────██▓▓▓▓██████████████▓▓██
──██▓▓▓▓▓▓▓▓████░░░░░░████
████▓▓▓▓▓▓▓▓██░░░░░░░░░░██
████▓▓▓▓▓▓▓▓██░░░░░░░░░░██
██████▓▓▓▓▓▓▓▓██░░░░░░████████
──██████▓▓▓▓▓▓████████████████
────██████████████████████▓▓▓▓██
──██▓▓▓▓████████████████▓▓▓▓▓▓██
████▓▓██████████████████▓▓▓▓▓▓██
██▓▓▓▓██████████████████▓▓▓▓▓▓██
██▓▓▓▓██████████──────██▓▓▓▓████
██▓▓▓▓████──────────────██████                                                                                                                                                
";

        public void Menuname()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(menuTitle);
            Console.ResetColor();

        }

    }
}
