using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacyDavis_Project5_HumanVsOrc
{
    class Orc
    {
        protected string name;
        protected string type;
        protected int baseHealth;
        protected int baseAttack;
        protected int currentHealth;
        public static Random rn = new Random();

        public string GetName()
        {
            return name;
        }

        public int GetCurrentHealth()
        {
            return currentHealth;
        }

        public Orc(string n)
        {
            name = n;
            type = "Orc";
            baseAttack = rn.Next(10, 16);
            baseHealth = rn.Next(45, 71);
            currentHealth = baseHealth;
        }

        public void SetHealth(int damage)
        {
            if(damage < 0)
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
            int attackDamage;
            
            if (currentHealth < (baseHealth * .5))
            {
                Console.WriteLine(name + " is enraged!\n");
                int rage = rn.Next(0, 11);
                attackDamage = baseAttack + rage;

                if (attackDamage < 0)
                {
                    attackDamage = 0;
                } 
                currentHealth -= rage;

                if (currentHealth < 0)
                {
                    currentHealth = 0;
                }

                //Console.WriteLine(name + "'s rage  has decreased his health by " + rage);
            }
            else
            {
                attackDamage = baseAttack + rn.Next(-3, 6);
            }
            return attackDamage;
        }

        public virtual void Display()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("     Type: " + type);
            Console.WriteLine("     Base Attack: " + baseAttack);
            Console.WriteLine("     Base Health: " + baseHealth);
            Console.WriteLine("     Current Health: " + currentHealth);
        }

    }
}
