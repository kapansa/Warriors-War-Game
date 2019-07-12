using System;
using WarriorWars.Enum;
using WarriorWars.Equipment;

namespace WarriorWars
{
    class Warrior
    {
        private const int GOOD_GUY_STARTING_HEALTH = 20;
        private const int BAD_GUY_STARTING_HEALTH = 20;
        
        private readonly Faction FACTION;    

        private int health;
        private string name;
        private bool isAlive;

        public bool IsAlive
        {
            get
            {
                return isAlive; 
            }
        }

        private Weapon weapon;
        private Armor armor;

        public Warrior(string name, Faction faction)
        {
            this.name = name;
            FACTION = faction;
            isAlive = true;

            switch (faction)
            {
                case Faction.BadGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;
                    break;
                case Faction.GoodGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = GOOD_GUY_STARTING_HEALTH;
                    break;
                default:
                    break;
            }
        }

        public void Attack(Warrior enermy)
        {
            int damage = weapon.Damage / enermy.armor.ArmorPoints;

            enermy.health -= damage;

            AttactResult(enermy, damage);
        }

        private void AttactResult(Warrior enermy, int damage)
        {
            if (enermy.health <= 0)
            {
                enermy.isAlive = false;
                Tools.ColorfulWriteLine($"{enermy.name} is dead", ConsoleColor.Red);
                Tools.ColorfulWriteLine($"{name} is now victoriuos!", ConsoleColor.Blue);
            }
            else
            {
                Console.WriteLine($"{name} attcked {enermy.name}. {damage} damage was inflacted to {enermy.name}. Health Remaining for {enermy.name} is {enermy.health}");
            }
        }
    }
}
