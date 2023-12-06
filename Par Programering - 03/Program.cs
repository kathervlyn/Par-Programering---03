namespace Par_Programering___03
{
    public class Program
    {
        public static List<Pokemon> GrassList = new List<Pokemon>();
        public static List<Pokemon> WaterList = new List<Pokemon>();

        static void Main()
        {
            List<Pokemon> StarterParty = new List<Pokemon>();
            Pokemon Pikachu = new Pokemon("Pikachu", 1, 15, 2);
            StarterParty.Add(Pikachu);
            Trainer Ash = new Trainer("Ash", 10, 10, 10000, StarterParty);

            
            GrassList.Add(new Pokemon("Bulbasaur", 1, 17, 2));
            GrassList.Add(new Pokemon("Oddish", 1, 18, 1));
            GrassList.Add(new Pokemon("Chikorita", 1, 12, 3));
            GrassList.Add(new Pokemon("Treecko", 1, 17, 2));
            GrassList.Add(new Pokemon("Snivy", 1, 23, 2));
            GrassList.Add(new Pokemon("Leafeon", 1, 15, 2));
            GrassList.Add(new Pokemon("Ferrothorn", 1, 16, 2));
            GrassList.Add(new Pokemon("Decidueye", 1, 19, 2));
            GrassList.Add(new Pokemon("Ludicolo", 1, 20, 2));
            GrassList.Add(new Pokemon("Breloom", 1, 30, 1));

            WaterList.Add(new Pokemon("Squirtle", 1, 16, 2));
            WaterList.Add(new Pokemon("Gyarados", 1, 32, 7));
            WaterList.Add(new Pokemon("Vaporeon", 1, 22, 3));
            WaterList.Add(new Pokemon("Blastoise", 1, 27, 4));
            WaterList.Add(new Pokemon("Lapras", 1, 30, 2));
            WaterList.Add(new Pokemon("Milotic", 1, 28, 2));
            WaterList.Add(new Pokemon("Sharpedo", 1, 18, 5));
            WaterList.Add(new Pokemon("Swampert", 1, 30, 4));
            WaterList.Add(new Pokemon("Kyogre", 1, 40, 10));
            WaterList.Add(new Pokemon("Greninja", 1, 27, 6));

            Ash.Idle();
        }
    }
}
//Pokemon
// Appen du skal lage må ha en pokemontrener.
// Brukeren skal få velge navn og startpokemon.
// Treneren skal ha mulighet til å gå i forskjellig terreng (grass, vann) der vilkårlige pokemen kan dukke opp.
// Man kan fange eller kjempe mot de ville pokemenna som dukker opp (det kan hende de også stikker av).
// Treneren kan også gå inn i pokeshop for å skaffe seg flere pokeballer eller health potions som kan brukes i combat.
// Man skal ha mulighet til å se hvilke pokemen treneren har, og også annen inventory som pokeballer/potions.
