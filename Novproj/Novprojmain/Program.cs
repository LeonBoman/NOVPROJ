using System.Diagnostics.Contracts;
using System;

namespace Novprojmain
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int gameState = 1; //exit kommando osv
            string command;
            Console.WriteLine("Commands:");
            Console.WriteLine("  attack  - will attack an enemy, if there is one");
            Console.WriteLine("   heal   - will heal you if you have a potion");
            Console.WriteLine("   loot   - will let you loot a room if all enemies are dead");
            Console.WriteLine("  forward - will move you to the next room");
            Console.WriteLine("   exit   - will exit the game for you");
            player player = new player(); //kallar metoder 19-20
            enemyMain enemy = new enemyMain();              
            int lootCount = 0; //så att man inte kan loota mer än en gång per rum
            int enemyCount = 1; //en koll om det finns en fiende i rummet
            while (gameState == 1) //kör spelet
            {
                roomMain room = new roomMain(); //tillkallar metoder 25-26
                itemMain item = new itemMain();
                Random generator = new Random(); 
                

                int inventoryLength = player.inventory.Count; //kollar inventory

                

                command = Console.ReadLine();

                if(command == "attack" && enemyCount == 1)
                {
                    int playerDamage = player.damage + generator.Next(5);
                    Console.WriteLine("you dealt " + playerDamage + " damage!");
                    enemy.healthEnemy -=playerDamage;
                    Console.WriteLine("enemy HP is currently " + enemy.healthEnemy); //skadar fienden
                    if(enemy.healthEnemy > 0)
                    {
                        if(player.armour > 0)
                        {
                            Console.WriteLine("Your armour protects you but suffers " + enemy.damageEnemy + " points of damage");
                            player.armour -= enemy.damageEnemy;
                            Console.WriteLine("Your HP is currently " + player.health);
                        } //denna ifsats kollar om man har rustning och skadar den istället för HPn
                        else
                        {
                        Console.WriteLine("enemy dealt " + enemy.damageEnemy + " damage!");
                        player.health -= enemy.damageEnemy;
                        Console.WriteLine("Your HP is currently " + player.health);
                        } //skadar din hp efter enemy randomized damage output
                    }
                    else if(playerDamage > enemy.healthEnemy)
                    {
                        Console.WriteLine("Enemy died!");
                        enemyCount = 0;
                    } //dödar fienden om din skada är högre än dens HP
                    else if(player.health < 0)
                    {
                        Console.WriteLine("You died!");
                        gameState = 0;
                    } //dödar fienden om dens hp är lägre än 0
                    else
                    {
                        Console.WriteLine("Enemy died!");
                        enemyCount = 0;
                    } //annars dödar den fienden

                }
                else if(command == "heal" && player.health < 100)
                {
                    
                    for(int i = 0; i < inventoryLength; i++)
                    { //hår igenom inventory
                        if(player.inventory[i].itemType == 0) //kollar om den har potions (0)
                        {
                            player.health += 25;
                            player.inventory.Remove(item);
                            break;
                        } //healar och tar bort potion

                        else
                        {
                            Console.WriteLine("You do not have a potion");
                            Console.ReadLine();
                        } //om du inte har en potion och ska heala så säger den det
                    }
                }
                else if(command == "stats")
                {
                    Console.WriteLine("HP: " + player.health);
                    Console.WriteLine("AMR: " + player.armour);
                   
                } //kollar HP och rustning 

                else if (command == "loot" && lootCount == 0 && enemyCount == 0) 
                { //kollar om fienden är död och om du redan har lootat
                    
                    player.inventory.Add(item);//skapar ett item till invetory
                    if (item.itemType == 0)
                    {
                        Console.WriteLine("You picked up a potion");
                    } //gör detta item till en potion
                    else if (item.itemType == 1)
                    {
                        Console.WriteLine("You picked up armour");
                        player.armour += 25;
                        player.inventory.Remove(item);
                    } // get dig armour direkt och tar bort itemet vill läga till så att man kan byta armour till permanent som skyddar % damage
                    else if (item.itemType == 2)
                    {
                        Console.WriteLine("You picked up coins");
                    } //useless item atm
                    else if (item.itemType == 3)
                    {
                        Console.WriteLine("You picked up food");
                    } // också uselesss
                    lootCount = 1; // gör så att du inte kan loota
                }

                else if(command == "forward" && enemyCount == 0)
                {
                    lootCount = 0;
                    enemyCount = 1;
                    enemy = new enemyMain();
                    Console.WriteLine("You moved to the next room");
                } //byter rum, gör så att du kan loota och skapar en fiende

                else if(command == "exit")
                {
                    gameState = 0;
                } //avlsutar spelet

                else
                {
                    Console.WriteLine("Cant do that");
                } //om du skriver fel kommando ger den dig detta
            
            }
            Console.ReadLine();
        }
    }
}
