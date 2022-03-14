using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacyDavis_Project5_HumanVsOrc
{
    class Human
    {
        protected string name;
        protected string type;
        protected int baseHealth;
        protected int baseAttack;
        protected int currentHealth;
        private int medicine;
        public static Random rn = new Random();

        public string GetName()
        {
            return name;
        }

        public int GetCurrentHealth()
        {
            return currentHealth;
        }

        public Human(string n)
        {
            name = n;
            type = "Human";
            baseAttack = rn.Next(9, 16);
            baseHealth = rn.Next(45, 61);
            medicine = rn.Next(3, 9);
            currentHealth = baseHealth;
        }

        public void SetHealth(int damage)
        {
            if (damage < 0)
            {
                damage = 0;
            }
            currentHealth -= damage;

            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
        }

        public virtual int Attack()
        {
            int attackDamage = baseAttack + rn.Next(0, 6);

            if (attackDamage < 0)
            {
                attackDamage = 0;
            }

            return attackDamage;
        }

        public void Heal()
        {
            if (medicine > 0)
            {
                int recover = rn.Next(5, 11);
                currentHealth += recover;

                Console.WriteLine("\n" + name + " took 1 medicine and increased current health by " + recover);
                medicine -= 1;

                if (medicine == 0)
                {
                    Console.WriteLine("\n" + name + " is now out of medicine!");
                }                
            }
            else
            {
                Console.WriteLine("\n" + name 
                    + " has no more medicine left.");
            }
        }

        public void Defend(int damage)
        {
            if (damage < 0)
            {
                damage = 0;
            }
            currentHealth -= (damage / 2);
        }

        public virtual void Display()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("     Type: " + type);
            Console.WriteLine("     Base Attack: " + baseAttack);
            Console.WriteLine("     Base Health: " + baseHealth);
            Console.WriteLine("     Current Health: " + currentHealth);
            Console.WriteLine("     Medicine " + medicine);
        }
    }    
}
