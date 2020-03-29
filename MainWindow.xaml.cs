using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RandomHeroes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly List<Tuple<string, string[]>> content;
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
            GenerateNumbers();
            AssignCastleNames();
            AssignHeroesNames();
            RandomButton.IsEnabled = true;
        }
        private void GenerateNumbers()
        {
            Random rnd = new Random();
            int numberOfCastles = 10;
            int numberOfHeroes = 16;
            string tmp;

            Player1Castle.Content = RandGenerator(numberOfCastles, rnd);
            tmp = RandGenerator(numberOfCastles, rnd);
            if (SameCastle.IsChecked == false)
            {
                while (tmp == Player1Castle.Content.ToString()) tmp = RandGenerator(numberOfCastles, rnd);
            }
            Player2Castle.Content = tmp;

            tmp = RandGenerator(numberOfHeroes, rnd);
            if (Navigation.IsChecked == false && IsNavigationInThisCastle(Player1Castle.Content.ToString()))
            {
                while (tmp == HeroWithNavigation(Player1Castle.Content.ToString())) tmp = RandGenerator(numberOfHeroes, rnd);
            }
            Player1Hero.Content = tmp;

            tmp = RandGenerator(numberOfHeroes, rnd);
            if (Player2Castle.Content == Player1Castle.Content)
            {
                while (tmp == Player1Hero.Content.ToString())
                {
                    tmp = RandGenerator(numberOfHeroes, rnd);
                    if(Navigation.IsChecked == false && IsNavigationInThisCastle(Player2Castle.Content.ToString()))
                    {
                        while (tmp == HeroWithNavigation(Player2Castle.Content.ToString())) tmp = RandGenerator(numberOfHeroes, rnd);
                    }
                }
            }
            Player2Hero.Content = tmp;
        }
        private void AssignCastleNames()
        {
            int temp = Int32.Parse(Player1Castle.Content.ToString());
            Player1CastleName.Content = GetCastleName(temp);
            Player1CastleName.Visibility = Visibility.Visible;

            temp = Int32.Parse(Player2Castle.Content.ToString());
            Player2CastleName.Content = GetCastleName(temp);
            Player2CastleName.Visibility = Visibility.Visible;
        }
        private void AssignHeroesNames()
        {
            int castleTmp = Int32.Parse(Player1Castle.Content.ToString());
            int heroTmp = Int32.Parse(Player1Hero.Content.ToString());

            Player1HeroName.Content = GetHeroName(castleTmp, heroTmp);
            Player1HeroName.Visibility = Visibility.Visible;

            castleTmp = Int32.Parse(Player2Castle.Content.ToString());
            heroTmp = Int32.Parse(Player2Hero.Content.ToString());

            Player2HeroName.Content = GetHeroName(castleTmp, heroTmp);
            Player2HeroName.Visibility = Visibility.Visible;
        }
        private string RandGenerator(int limit, Random rnd)
        {
            return rnd.Next(1, limit + 1).ToString();
        }
        private bool IsNavigationInThisCastle(string castle)
        {
            if(castle == "1" || castle == "8" || castle == "10") return true;
            return false;
        }
        private string HeroWithNavigation(string castle)
        {
            switch(castle)
            {
                case "1":
                    return "4";
                case "8":
                    return "11";
                case "10":
                    return "4";
                default:
                    return "";
            }
        }
        private string GetCastleName(int number)
        {
            try
            {
                return content[number - 1].Item1;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string GetHeroName(int castleNumber, int heroNumber)
        {
            try
            {
                return content[castleNumber - 1].Item2[heroNumber - 1];
            }
            catch (Exception)
            {
                return "";
            }
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

