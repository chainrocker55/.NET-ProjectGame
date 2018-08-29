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
using System.Windows.Threading;
using MySql.Data.MySqlClient;

namespace Chickenrun
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
        Map map = new Map();
        private static string name;
        private static int coinget;
        private static int lvget;
        private static int scoreget;

        int status = 1;
        int statusbot = 1;
        int statuskick = 1;

        DispatcherTimer timerchara = new DispatcherTimer();

        DispatcherTimer timerpet = new DispatcherTimer();
        public int getScore()
        {
            return scoreget;

        }
        public void setName(string n)
        {
            name = n;
        
        }
        public string getName()
        {
            return name;

        }
        public int getCoin()
        {
            return coinget;

        }
        public int getLv()
        {
            return lvget;

        }
        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            
            timerchara.Tick += new EventHandler(timerrun);
            timerchara.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timerchara.Start();

            timerpet.Tick += new EventHandler(timerrunpet);
            timerpet.Interval = new TimeSpan(0, 0, 0, 0, 150);
            timerpet.Start();

            
            
            string sql = "SELECT * FROM tblogin WHERE username ='" + name + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=chain;password=chain555;database=tblogin");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
              
                username.Content = reader.GetString("username");
                coin.Content = reader.GetInt32("coin");
               
                coinget = reader.GetInt32("coin");
                lvget = reader.GetInt32("exp");
                lv.Content = lvget/10;
                score.Content= reader.GetInt32("score");
                scoreget = reader.GetInt32("score");
            }
            con.Close();

        }

        private void timerrunpet(object sender, EventArgs e)
        {
            soundchicken.Play();
            if (statusbot == 1)
            {

                pet1.Source = new BitmapImage(new Uri(@"\picture\picture2\" + map.getPet() + "2.png", UriKind.Relative));

                statusbot = 2;
            }
            else if (statusbot == 2)
            {

                pet1.Source = new BitmapImage(new Uri(@"\picture\picture2\" + map.getPet() + "3.png", UriKind.Relative));
                statusbot = 3;
            }
            else if (statusbot == 3)
            {

                pet1.Source = new BitmapImage(new Uri(@"\picture\picture2\" + map.getPet() + "1.png", UriKind.Relative));
                statusbot = 1;
            }


        }

        private void timerrun(object sender, EventArgs e)

        {
            if (statuskick == 1)
            {

                kick.Source = new BitmapImage(new Uri(@"\picture\picture2\kick2.png", UriKind.Relative));

                statuskick = 2;
            }
            else if (statuskick == 2)
            {

                kick.Source = new BitmapImage(new Uri(@"\picture\picture2\kick3.png", UriKind.Relative));
                statuskick = 3;
            }
            else if (statuskick == 3)
            {

                kick.Source = new BitmapImage(new Uri(@"\picture\picture2\kick4.png", UriKind.Relative));
                statuskick = 4;
            }
            else if (statuskick == 4)
            {

                kick.Source = new BitmapImage(new Uri(@"\picture\picture2\kick5.png", UriKind.Relative));
                statuskick = 5;
            }
            else if (statuskick == 5)
            {

                kick.Source = new BitmapImage(new Uri(@"\picture\picture2\kick6.png", UriKind.Relative));
                statuskick = 6;
            }
            else if (statuskick == 6)
            {

                kick.Source = new BitmapImage(new Uri(@"\picture\picture2\kick1.png", UriKind.Relative));
                statuskick = 1;
            }
            if (status == 1)
            {
                sanji.Source = new BitmapImage(new Uri(@"\picture\character\" + map.getCharacter() + "2.png", UriKind.RelativeOrAbsolute));
                //luffy.Source = new BitmapImage(new Uri(@"\picture\character\luffy2.png", UriKind.RelativeOrAbsolute));
                //naruto.Source = new BitmapImage(new Uri(@"\picture\character\naruto2.png", UriKind.RelativeOrAbsolute));


                status = 2;
            }
            else if (status == 2)
            {
                sanji.Source = new BitmapImage(new Uri(@"\picture\character\" + map.getCharacter() + "3.png", UriKind.RelativeOrAbsolute));
                //luffy.Source = new BitmapImage(new Uri(@"\picture\character\luffy3.png", UriKind.RelativeOrAbsolute));
                //naruto.Source = new BitmapImage(new Uri(@"\picture\character\naruto3.png", UriKind.RelativeOrAbsolute));

                status = 3;
            }
            else if (status == 3)
            {
                sanji.Source = new BitmapImage(new Uri(@"\picture\character\" + map.getCharacter() + "4.png", UriKind.RelativeOrAbsolute));
                //luffy.Source = new BitmapImage(new Uri(@"\picture\character\luffy4.png", UriKind.RelativeOrAbsolute));
                //naruto.Source = new BitmapImage(new Uri(@"\picture\character\naruto4.png", UriKind.RelativeOrAbsolute));
                status = 4;
            }
            else if (status == 4)
            {
                sanji.Source = new BitmapImage(new Uri(@"\picture\character\" + map.getCharacter() + "5.png", UriKind.RelativeOrAbsolute));
                //luffy.Source = new BitmapImage(new Uri(@"\picture\character\luffy5.png", UriKind.RelativeOrAbsolute));
                //naruto.Source = new BitmapImage(new Uri(@"\picture\character\naruto5.png", UriKind.RelativeOrAbsolute));

                status = 5;
            }
            else if (status == 5)
            {
                sanji.Source = new BitmapImage(new Uri(@"\picture\character\" + map.getCharacter() + "6.png", UriKind.RelativeOrAbsolute));
                //luffy.Source = new BitmapImage(new Uri(@"\picture\character\luffy6.png", UriKind.RelativeOrAbsolute));
                //naruto.Source = new BitmapImage(new Uri(@"\picture\character\naruto6.png", UriKind.RelativeOrAbsolute));

                status = 6;
            }
            else if (status == 6)
            {
                sanji.Source = new BitmapImage(new Uri(@"\picture\character\" + map.getCharacter() + "7.png", UriKind.RelativeOrAbsolute));
                //luffy.Source = new BitmapImage(new Uri(@"\picture\character\luffy7.png", UriKind.RelativeOrAbsolute));
                //naruto.Source = new BitmapImage(new Uri(@"\picture\character\naruto7.png", UriKind.RelativeOrAbsolute));

                status = 7;
            }
            else if (status == 7)
            {
                sanji.Source = new BitmapImage(new Uri(@"\picture\character\" + map.getCharacter() + "8.png", UriKind.RelativeOrAbsolute));
                //luffy.Source = new BitmapImage(new Uri(@"\picture\character\luffy8.png", UriKind.RelativeOrAbsolute));
                //naruto.Source = new BitmapImage(new Uri(@"\picture\character\naruto8.png", UriKind.RelativeOrAbsolute));

                status = 8;
            }
            else if (status == 8)
            {
                sanji.Source = new BitmapImage(new Uri(@"\picture\character\" + map.getCharacter() + "1.png", UriKind.RelativeOrAbsolute));
                //luffy.Source = new BitmapImage(new Uri(@"\picture\character\luffy1.png", UriKind.RelativeOrAbsolute));
                //naruto.Source = new BitmapImage(new Uri(@"\picture\character\naruto1.png", UriKind.RelativeOrAbsolute));

                status = 1;
            }
        }
    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            NavigationService.Navigate(new Uri("Map.xaml", UriKind.RelativeOrAbsolute));
        }

       


       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            timerpet.Stop();
            timerchara.Stop();
            NavigationService.Navigate(new Uri("Character.xaml", UriKind.RelativeOrAbsolute));
        }

        private void pet_Click(object sender, RoutedEventArgs e)
        {
            timerpet.Stop();
            timerchara.Stop();
            NavigationService.Navigate(new Uri("Pet.xaml", UriKind.RelativeOrAbsolute));
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void close_Copy_Click(object sender, RoutedEventArgs e)
        {
            timerpet.Stop();
            timerchara.Stop();
            NavigationService.Navigate(new Uri("Login2.xaml", UriKind.RelativeOrAbsolute));
        }
    }


}

