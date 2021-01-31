using System;

namespace Novprojmain
{
    class enemyMain
    {
        Random generator = new Random();
        public int healthEnemy = 30;
        public int damageEnemy;
        public string goblin;
        //skapar fiendens damage och HP

        public enemyMain()
        {
            damageEnemy = generator.Next(10)+5;
        }
        //randomizar damage
    }

}
