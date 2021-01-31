using System.ComponentModel;
using System;

namespace Novprojmain
{
    class itemMain
    {
        Random generator = new Random();
        public string potion;
        public string armour;
        public string coins;
        public string food;
        public int itemType;

        //skapar alla item types
        public itemMain()
         {
            itemType = generator.Next(4);
            //randomizar item till loot kommandot i main
            
         }
         public string getType()
            { 
                if (itemType == 0) 
                {
                    return "potion";
                }
                else if (itemType == 1) 
                {
                    return "armour";
                }
                else if (itemType == 2) 
                {
                    return "coins";
                }
                else 
                {
                    return "food";
                }
            } //här kollar den bara det randomizade nummret
}
}