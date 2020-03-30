using System;
using System.Collections.Generic;
using System.Windows;

namespace RandomHeroes
{
    public partial class MainWindow : Window
    {
        static readonly List<Tuple<string, string[]>> content;
        private readonly List<Tuple<int, int>> playerPair = new List<Tuple<int, int>>();
        private int numbersOfPlayers;
        public MainWindow()
        {
            InitializeComponent();
        }
        static MainWindow()
        {
            content = GetContent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RandomButton.IsEnabled = false;
            numbersOfPlayers = Int32.Parse(NumberOfPlayers.Text);
            AdjustWindow();
            DisqualifyHeroes();
            GenerateNumbers();
            AssignNumbers();
            AssignCastleNames();
            AssignHeroesNames();
            RandomButton.IsEnabled = true;
        }
        private void AdjustWindow()
        {
            MainWindow1.Height = numbersOfPlayers * 50 + 190;
        }        
        private void GenerateNumbers()
        {
            playerPair.Clear();

            Random rnd = new Random();
            int numberOfCastles = 10;
            int numberOfHeroes = 16;

            int tempCastle;
            int tempHero;

            for(int i = 0; i <= numbersOfPlayers; i++ )
            {
                tempCastle = RandIntGenerator(numberOfCastles, rnd);
                tempHero = RandIntGenerator(numberOfHeroes, rnd);

                if (SameCastle.IsChecked == false)
                {
                    while(IsThisCastleAlreadyChosen(tempCastle)) tempCastle = RandIntGenerator(numberOfCastles, rnd);
                }
                else
                {
                    while(IsThisHeroAlreadyChosen(tempCastle, tempHero)) tempHero = RandIntGenerator(numberOfHeroes, rnd);
                }

                playerPair.Add(new Tuple<int, int>(tempCastle, tempHero));
            }

            for(int i = playerPair.Count - 1; i < 7; i++) playerPair.Add(new Tuple<int, int>(1, 1));
        }
        private void DisqualifyHeroes()
        {
            if (Navigation.IsChecked == true) SwitchHeroesForMapsWithoutWater();
        }
        private void SwitchHeroesForMapsWithoutWater()
        {
            content[0].Item2[3] = "Beatrice";
            content[7].Item2[10] = "Kinkeria";
            content[9].Item2[3] = "Derek";
        }
        private bool IsThisCastleAlreadyChosen(int castle)
        {
            for(int i = 0; i < playerPair.Count; i++)
            {
                if (playerPair[i].Item1 == castle) return true;
            }
            return false;
        }
        private bool IsThisHeroAlreadyChosen(int castle, int hero)
        {
            for (int i = 0; i < playerPair.Count; i++)
            {
                if (playerPair[i].Item1 == castle && playerPair[i].Item2 == hero) return true;
            }
            return false;
        }
        private void AssignNumbers()
        {
            Player1Castle.Content = playerPair[0].Item1;
            Player2Castle.Content = playerPair[1].Item1;
            Player3Castle.Content = playerPair[2].Item1;
            Player4Castle.Content = playerPair[3].Item1;
            Player5Castle.Content = playerPair[4].Item1;
            Player6Castle.Content = playerPair[5].Item1;
            Player7Castle.Content = playerPair[6].Item1;
            Player8Castle.Content = playerPair[7].Item1;

            Player1Hero.Content = playerPair[0].Item2;
            Player2Hero.Content = playerPair[1].Item2;
            Player3Hero.Content = playerPair[2].Item2;
            Player4Hero.Content = playerPair[3].Item2;
            Player5Hero.Content = playerPair[4].Item2;
            Player6Hero.Content = playerPair[5].Item2;
            Player7Hero.Content = playerPair[6].Item2;
            Player8Hero.Content = playerPair[7].Item2;
        }
        private void AssignCastleNames()
        {
            Player1CastleName.Content = content[playerPair[0].Item1 - 1].Item1;
            Player1CastleName.Visibility = Visibility.Visible;

            Player2CastleName.Content = content[playerPair[1].Item1 - 1].Item1;
            Player2CastleName.Visibility = Visibility.Visible;

            Player3CastleName.Content = content[playerPair[2].Item1 - 1].Item1;
            Player3CastleName.Visibility = Visibility.Visible;

            Player4CastleName.Content = content[playerPair[3].Item1 - 1].Item1;
            Player4CastleName.Visibility = Visibility.Visible;

            Player5CastleName.Content = content[playerPair[4].Item1 - 1].Item1;
            Player5CastleName.Visibility = Visibility.Visible;

            Player6CastleName.Content = content[playerPair[5].Item1 - 1].Item1;
            Player6CastleName.Visibility = Visibility.Visible;

            Player7CastleName.Content = content[playerPair[6].Item1 - 1].Item1;
            Player7CastleName.Visibility = Visibility.Visible;

            Player8CastleName.Content = content[playerPair[7].Item1 - 1].Item1;
            Player8CastleName.Visibility = Visibility.Visible;
        }
        private void AssignHeroesNames()
        {
            Player1HeroName.Content = content[playerPair[0].Item1 - 1].Item2[playerPair[0].Item2 - 1];
            Player1HeroName.Visibility = Visibility.Visible;

            Player2HeroName.Content = content[playerPair[1].Item1 - 1].Item2[playerPair[1].Item2 - 1];
            Player2HeroName.Visibility = Visibility.Visible;

            Player3HeroName.Content = content[playerPair[2].Item1 - 1].Item2[playerPair[2].Item2 - 1];
            Player3HeroName.Visibility = Visibility.Visible;

            Player4HeroName.Content = content[playerPair[3].Item1 - 1].Item2[playerPair[3].Item2 - 1];
            Player4HeroName.Visibility = Visibility.Visible;

            Player5HeroName.Content = content[playerPair[4].Item1 - 1].Item2[playerPair[4].Item2 - 1];
            Player5HeroName.Visibility = Visibility.Visible;

            Player6HeroName.Content = content[playerPair[5].Item1 - 1].Item2[playerPair[5].Item2 - 1];
            Player6HeroName.Visibility = Visibility.Visible;

            Player7HeroName.Content = content[playerPair[6].Item1 - 1].Item2[playerPair[6].Item2 - 1];
            Player7HeroName.Visibility = Visibility.Visible;

            Player8HeroName.Content = content[playerPair[7].Item1 - 1].Item2[playerPair[7].Item2 - 1];
            Player8HeroName.Visibility = Visibility.Visible;
        }
        private int RandIntGenerator(int limit, Random rnd)
        {
            return rnd.Next(1, limit + 1);
        }
        public static List<Tuple<string, string[]>> GetContent()
        {
            List<Tuple<string, string[]>> content = new List<Tuple<string, string[]>>();
            List<string> heroes = new List<string>();
            Tuple<string, string[]> castle_heroes;

            heroes.Add("Orrin");
            heroes.Add("Valeska");
            heroes.Add("Edric");
            heroes.Add("Sylvia");
            heroes.Add("Lord Haart");
            heroes.Add("Sorsha");
            heroes.Add("Christian");
            heroes.Add("Tyris");
            heroes.Add("Rion");
            heroes.Add("Adela");
            heroes.Add("Cuthbert");
            heroes.Add("Adelaide");
            heroes.Add("Ingham");
            heroes.Add("Sanya");
            heroes.Add("Loynis");
            heroes.Add("Caitlin");

            castle_heroes = new Tuple<string, string[]>("Castle", heroes.ToArray());
            content.Add(castle_heroes);
            heroes.Clear();

            heroes.Add("Mephala");
            heroes.Add("Ufretin");
            heroes.Add("Jenova");
            heroes.Add("Ryland");
            heroes.Add("Giselle");
            heroes.Add("Ivor");
            heroes.Add("Clancy");
            heroes.Add("Kyrre");
            heroes.Add("Coronius");
            heroes.Add("Uland");
            heroes.Add("Elleshar");
            heroes.Add("Gem");
            heroes.Add("Malcom");
            heroes.Add("Melodia");
            heroes.Add("Alagar");
            heroes.Add("Aeris");

            castle_heroes = new Tuple<string, string[]>("Rampart", heroes.ToArray());
            content.Add(castle_heroes);
            heroes.Clear();

            heroes.Add("Piquedram");
            heroes.Add("Thane");
            heroes.Add("Josephine");
            heroes.Add("Neela");
            heroes.Add("Torosar");
            heroes.Add("Fafner");
            heroes.Add("Rissa");
            heroes.Add("Iona");
            heroes.Add("Astral");
            heroes.Add("Halon");
            heroes.Add("Serena");
            heroes.Add("Daremyth");
            heroes.Add("Theodorus");
            heroes.Add("Solmyr");
            heroes.Add("Cyra");
            heroes.Add("Aine");

            castle_heroes = new Tuple<string, string[]>("Tower", heroes.ToArray());
            content.Add(castle_heroes);
            heroes.Clear();

            heroes.Add("Fiona");
            heroes.Add("Rashka");
            heroes.Add("Marius");
            heroes.Add("Ignatius");
            heroes.Add("Octavia");
            heroes.Add("Calh");
            heroes.Add("Pyre");
            heroes.Add("Nymus");
            heroes.Add("Ayden");
            heroes.Add("Xyron");
            heroes.Add("Axsis");
            heroes.Add("Olema");
            heroes.Add("Calid");
            heroes.Add("Ash");
            heroes.Add("Zydar");
            heroes.Add("Xarfax");

            castle_heroes = new Tuple<string, string[]>("Infermo", heroes.ToArray());
            content.Add(castle_heroes);
            heroes.Clear();

            heroes.Add("Straker");
            heroes.Add("Vokial");
            heroes.Add("Moandor");
            heroes.Add("Charna");
            heroes.Add("Tamika");
            heroes.Add("Isra");
            heroes.Add("Clavius");
            heroes.Add("Ranloo");
            heroes.Add("Septienna");
            heroes.Add("Aislinn");
            heroes.Add("Sandro");
            heroes.Add("Nimbus");
            heroes.Add("Thant");
            heroes.Add("Xsi");
            heroes.Add("Vidomina");
            heroes.Add("Nagash");

            castle_heroes = new Tuple<string, string[]>("Necropolis", heroes.ToArray());
            content.Add(castle_heroes);
            heroes.Clear();

            heroes.Add("Lorelei");
            heroes.Add("Arlach");
            heroes.Add("Dace");
            heroes.Add("Ajit");
            heroes.Add("Damacon");
            heroes.Add("Gunnar");
            heroes.Add("Synca");
            heroes.Add("Shakti");
            heroes.Add("Alamar");
            heroes.Add("Jaegar");
            heroes.Add("Malekith");
            heroes.Add("Jeddite");
            heroes.Add("Geon");
            heroes.Add("Deemer");
            heroes.Add("Sephinroth");
            heroes.Add("Darkstorm");

            castle_heroes = new Tuple<string, string[]>("Dungeon", heroes.ToArray());
            content.Add(castle_heroes);
            heroes.Clear();

            heroes.Add("Yog");
            heroes.Add("Gurnisson");
            heroes.Add("Jabarkas");
            heroes.Add("Shiva");
            heroes.Add("Gretchin");
            heroes.Add("Krellion");
            heroes.Add("Crag Hack");
            heroes.Add("Tyraxor");
            heroes.Add("Gird");
            heroes.Add("Vey");
            heroes.Add("Dessa");
            heroes.Add("Terek");
            heroes.Add("Zubin");
            heroes.Add("Gundula");
            heroes.Add("Oris");
            heroes.Add("Saurug");

            castle_heroes = new Tuple<string, string[]>("Stronghold", heroes.ToArray());
            content.Add(castle_heroes);
            heroes.Clear();

            heroes.Add("Bron");
            heroes.Add("Drakon");
            heroes.Add("Wystan");
            heroes.Add("Tazar");
            heroes.Add("Alkin");
            heroes.Add("Korbac");
            heroes.Add("Gerwulf");
            heroes.Add("Broghild");
            heroes.Add("Mirlanda");
            heroes.Add("Rosic");
            heroes.Add("Voy");
            heroes.Add("Verdish");
            heroes.Add("Merist");
            heroes.Add("Styg");
            heroes.Add("Andra");
            heroes.Add("Tiva");

            castle_heroes = new Tuple<string, string[]>("Fortress", heroes.ToArray());
            content.Add(castle_heroes);
            heroes.Clear();

            heroes.Add("Pasis");
            heroes.Add("Thunar");
            heroes.Add("Ignissa");
            heroes.Add("Lacus");
            heroes.Add("Monere");
            heroes.Add("Erdamon");
            heroes.Add("Fiur");
            heroes.Add("Kalt");
            heroes.Add("Luna");
            heroes.Add("Brissa");
            heroes.Add("Ciele");
            heroes.Add("Labetha");
            heroes.Add("Inteus");
            heroes.Add("Aenain");
            heroes.Add("Gelare");
            heroes.Add("Grindan");

            castle_heroes = new Tuple<string, string[]>("Conflux", heroes.ToArray());
            content.Add(castle_heroes);
            heroes.Clear();

            heroes.Add("Corkes");
            heroes.Add("Jeremy");
            heroes.Add("Illor");
            heroes.Add("Elmore");
            heroes.Add("Leena");
            heroes.Add("Anabel");
            heroes.Add("Cassiopeia");
            heroes.Add("Miriam");
            heroes.Add("Casmetra");
            heroes.Add("Eovacius");
            heroes.Add("Spint");
            heroes.Add("Andal");
            heroes.Add("Manfred");
            heroes.Add("Zilare");
            heroes.Add("Astra");
            heroes.Add("Dargem");

            castle_heroes = new Tuple<string, string[]>("Cove", heroes.ToArray());
            content.Add(castle_heroes);

            return content;
        }
    }
}

