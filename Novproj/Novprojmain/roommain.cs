using System.CodeDom.Compiler;
using System;

namespace Novprojmain
{
    public class roomMain
    {
            Random generator = new Random();
            public string hallway;
            //hallway = 0
            public string lootRoom;
            //lootroom = 1
            public string enemyRoom;
            //enemyroom = 2
            public string bossRoom;
            //bossroom = 3
            public int roomType;

            public roomMain()
            {
                roomType = generator.Next(4);
            }
    } //denna metod har ingen användning just nu
}
