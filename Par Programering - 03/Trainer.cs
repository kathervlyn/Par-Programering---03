namespace Par_Programering___03
{
    public class Trainer
    {
        public string Name { get; set; }
        public int Potions { get; set; }
        public int Pokeballs { get; set; }
        public int Money { get; set; }
        public List<Pokemon> Party { get; set; }
        public Pokemon SelectedPokemon { get; set; }


        public Trainer(string name, int potions, int pokeballs, int money, List<Pokemon> party)
        {
            Name = name;
            Potions = potions;
            Pokeballs = pokeballs;
            Money = money;
            Party = party;

            SelectedPokemon = party.First();
        }

        public void SwitchPKMN()
        {
            Console.Clear();
            Console.WriteLine("Which pokemon do you wish to switch into?");
            for (var i = 0; i < Party.Count; i++)
            {
                Pokemon PKMN = Party[i];
                Console.WriteLine($"[{i + 1}] {PKMN.Name} HP: {PKMN.Health}");
            }
            Console.WriteLine("[0] Exit");

            var input = Convert.ToInt32(Console.ReadLine());

            if (input == 0)
            {
                Idle();
            }
            else
            {
                if (input > 0 && input <= Party.Count)
                {
                    SelectedPokemon = Party[input - 1];
                    Idle();
                }
                else
                {
                    Idle();
                }
            }
        }

        public void MeetWildPKMN(string Terrain)
        {
            Random rng = new();
            if (Terrain == "grass")
            {
                int RandomPKMN = rng.Next(0, (Program.GrassList.Count - 1));
                Pokemon WildEncounter = Program.GrassList[RandomPKMN];
                Fight WildFight = new Fight(this, WildEncounter);
                WildFight.Idle();
            }
            else if (Terrain == "water")
            {
                int RandomPKMN = rng.Next(0, (Program.WaterList.Count - 1));
                Pokemon WildEncounter = Program.WaterList[RandomPKMN];
                Fight WildFight = new Fight(this, WildEncounter);
                WildFight.Idle();
            }
        }
        public void GoPokemart()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the pokemart, what can I help you with?");
            Console.WriteLine($"Your money: {this.Money}");
            Console.WriteLine($"[1] Buy Pokeball for $5       Owned: {this.Pokeballs}");
            Console.WriteLine($"[2] Buy Potion for $10        Owned: {this.Potions}");
            Console.WriteLine("[3] Exit");

            var input = Console.ReadLine();
            if (input == "1")
            {
                if (this.Money >= 5)
                {
                    this.Pokeballs++;
                    this.Money -= 5;
                    GoPokemart();
                }
                else
                {
                    Console.WriteLine("Not enough money");
                    Console.ReadLine();
                    GoPokemart();
                }
            }
            else if (input == "2")
            {
                if (this.Money >= 10)
                {
                    this.Potions++;
                    this.Money -= 10;
                    GoPokemart();
                }
                else
                {
                    Console.WriteLine("Not enough money");
                    Console.ReadLine();
                    GoPokemart();
                }
            }
            else if (input == "3")
            {
                Idle();
            }
            else
            {
                Console.WriteLine("Invalid input");
                Console.ReadLine();
                GoPokemart();
            }
        }

        public void Idle()
        {
            Console.Clear();
            Console.WriteLine("What do you wish to do?");
            Console.WriteLine($"Current Pokemon: {SelectedPokemon.Name}");
            Console.WriteLine("[1] Visit Pokemart");
            Console.WriteLine("[2] Find wild pokemon");
            Console.WriteLine("[3] Switch Pokemon");

            var input = Console.ReadLine();
            if (input == "1")
            {
                GoPokemart();
            }
            else if (input == "2")
            {
                WildTerrain();
            }
            else if (input == "3")
            {
                SwitchPKMN();
            }
            else
            {
                Idle();
            }
        }

        void WildTerrain()
        {
            Console.Clear();
            Console.WriteLine("Which terrain do you want to find a wild pokemon?");
            Console.WriteLine("[1] Grass");
            Console.WriteLine("[2] Water");
            var terrainInput = Console.ReadLine();

            if (terrainInput == "1")
            {
                MeetWildPKMN("grass");
            }
            else if (terrainInput == "2")
            {
                MeetWildPKMN("water");
            }
            else
            {
                WildTerrain();
            }
        }
    }
}
