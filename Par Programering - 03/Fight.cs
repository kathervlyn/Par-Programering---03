namespace Par_Programering___03
{
    public class Fight
    {
        public Trainer Trainer { get; set; }
        public Pokemon WildPokemon { get; set; }
        Pokemon myPKMN { get; set; }

        public Fight(Trainer trainer, Pokemon wildPokemon)
        {
            Trainer = trainer;
            WildPokemon = wildPokemon;
            myPKMN = trainer.SelectedPokemon;
        }

        public void SwitchPokemon()
        {
            Console.Clear();
            Console.WriteLine("Which pokemon do you wish to switch into?");
            for (var i = 0; i < Trainer.Party.Count; i++)
            {
                Pokemon PKMN = Trainer.Party[i];
                Console.WriteLine($"[{i + 1}] {PKMN.Name} HP: {PKMN.Health}");
            }
            Console.WriteLine("[0] Cancel");

            var input = Convert.ToInt32(Console.ReadLine());

            if (input == 0)
            {
                this.Idle();
            }
            else
            {
                if (input > 0 && input <= Trainer.Party.Count)
                {
                    Trainer.SelectedPokemon = Trainer.Party[input - 1];
                    this.Idle();
                }
                else
                {
                    this.Idle();
                }
            }
        }

        public void Idle()
        {
            Console.Clear();
            Console.WriteLine($"Your: {myPKMN.Name} HP: {myPKMN.Health}");
            Console.WriteLine($"Wild: {WildPokemon.Name} HP: {WildPokemon.Health}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("What do you wish to do?");
            if (myPKMN.Health > 0)
            {
                Console.WriteLine("[1] Attack");
            }
            else
            {
                Console.WriteLine("[1] Switch Pokemon");
            }
            Console.WriteLine("[2] Use Item");
            Console.WriteLine("[3] Run away");
            var input = Console.ReadLine();
            if (input == "1")
            {
                if (myPKMN.Health > 0)
                {
                    this.Attack();
                }
                else
                {
                    this.SwitchPokemon();
                }
            }
            else if (input == "2")
            {
                this.UseItem();
            }
            else if (input == "3")
            {
                this.PlayerRun();
            }
            else
            {
                this.Idle();
            }
        }

        public void Attack()
        {
            Console.Clear();
            Random atttackrng = new();
            int chance = atttackrng.Next(0, 1);

            if (chance == 0)
            {
                Console.WriteLine("You move first");
                myPKMN.Fight(WildPokemon, false);
            }
            else
            {
                Console.WriteLine("The wild pokemon moves first");
                WildPokemon.Fight(myPKMN, false);
            }
            if(WildPokemon.Health < 1)
            {
                Console.WriteLine($"You have defeated the {WildPokemon.Name}");
                Console.WriteLine($"You picked up ${WildPokemon.MaxHealth}");
                Trainer.Money += WildPokemon.MaxHealth;
                Console.ReadLine();
                Trainer.Idle();
            }
            else
            {
                Console.ReadLine();
                this.Idle();
            }
        }

        public void UseItem()
        {
            Console.Clear();
            Console.WriteLine("Which item do you wish to use?");
            Console.WriteLine("[1] Pokeball");
            Console.WriteLine("[2] Potion");
            Console.WriteLine("[3] Cancel");

            var input = Console.ReadLine();
            if (input == "1")
            {
                //Pokeball
                if (Trainer.Pokeballs > 0)
                {
                    Trainer.Pokeballs--;

                    Random catchrng = new();
                    int Chance = catchrng.Next(0, 100);
                    if (Chance >= 60)
                    {
                        Trainer.Party.Add(WildPokemon);
                        Console.Clear();
                        Console.WriteLine($"You have caught the {WildPokemon.Name}");
                        Console.ReadLine();
                        Trainer.Idle();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"{WildPokemon.Name} has broken out of the pokeball");
                        WildRun();
                    }
                }
                else
                {
                    Console.WriteLine($"You do not have any Pokeballs");
                    Console.ReadLine();
                    this.UseItem();
                }
            }
            else if (input == "2")
            {
                //Potion
                if (Trainer.Potions > 0)
                {
                    Console.WriteLine($"You use a potion on {myPKMN.Name}");
                    myPKMN.Health += 10;
                    Trainer.Potions--;
                    Console.WriteLine($"You have {Trainer.Potions} left ");
                    if (myPKMN.Health > myPKMN.MaxHealth)
                    {
                        myPKMN.Health = myPKMN.MaxHealth;
                    }
                    Console.WriteLine($"{myPKMN.Name} has recovered their hp to: {myPKMN.Health}");
                    Console.ReadLine();
                    this.Idle();
                }
                else
                {
                    Console.WriteLine($"You do not have any potions");
                    Console.ReadLine();
                    this.UseItem();
                }
            }
            else if (input == "3")
            {
                //Return til fight
                this.Idle();
            }
            else
            {
                UseItem();
            }
        }

        public void WildRun()
        {
            Console.Clear();
            Console.WriteLine($"{WildPokemon.Name} has run away!");
            Console.ReadLine();
            Trainer.Idle();
        }

        public void PlayerRun()
        {
            Console.Clear();
            Random runrng = new();
            int chance = runrng.Next(0, 1);
            if(myPKMN.Health == 0)
            {
                Console.WriteLine("You have fled the wild encounter");
                Console.ReadLine();
                Trainer.Idle();
            }
            else
            {
                if(chance == 1)
                {
                    Console.WriteLine("You have failed to run away");
                    WildPokemon.Fight(myPKMN, true);
                    this.Idle();
                }
                else
                {
                    Console.WriteLine("You have fled the wild encounter");
                    Console.ReadLine();
                    Trainer.Idle();
                }
            }
        }
    }
}