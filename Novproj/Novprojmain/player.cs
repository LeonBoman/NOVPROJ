using System;
using System.Collections.Generic;

namespace Novprojmain
{
    class player
    {
        Random generator = new Random();
        public int health = 100;
        public int damage;
        public float armour = 0;
        //skapar HP och Armour och damage
        public List<itemMain> inventory = new List<itemMain>();
        //skapar inventory

        public player()
        {
            //attack
            damage = generator.Next(16)+10;
        }

    }

}
