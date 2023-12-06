namespace Par_Programering___03
{
    public class Pokemon
    {
        public string Name;
        public int Level;
        public int Health;
        public int MaxHealth;
        public int Attack;

        public Pokemon(string name, int level, int health, int attack)
        {
            Name = name;
            Level = level;
            Health = health;
            Attack = attack;
            MaxHealth = health;
        }

        public void Fight(Pokemon enemy, bool singleAttack)
        {
            enemy.Health -= this.Attack;
            Console.WriteLine($"{this.Name} deals {this.Attack} to {enemy.Health}");

            if (enemy.Health < 1)
            {
                enemy.Health = 0;
                Console.WriteLine($"{enemy.Name} Has fainted!");
                return;
            }
            if (!singleAttack)
            {
                this.Health -= enemy.Attack;
                Console.WriteLine($"{enemy.Name} deals {enemy.Attack} to {this.Health}");

                if (this.Health < 1)
                {
                    this.Health = 0;
                    Console.WriteLine($"{this.Name} Has fainted!");
                }
            }
        }

    }
}
