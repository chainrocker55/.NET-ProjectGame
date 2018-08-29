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
    /// Interaction logic for Character.xaml
    /// </summary>
    public partial class Character : Page
    {
        MySqlConnection con = new MySqlConnection("host=localhost;user=chain;password=chain555;database=tblogin");
        public Character()
        {
            InitializeComponent();
        }
        int status = 1;
        Map map = new Map();
        Page1 hom = new Page1();
        DispatcherTimer timercharacter = new DispatcherTimer();
        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            
            timercharacter.Tick += new EventHandler(timerruncharacter);
            timercharacter.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timercharacter.Start();
            coin.Content = hom.getCoin();
            lv.Content = hom.getLv()/10;
            string sql = "SELECT * FROM tblogin INNER JOIN detailcha on detailcha.ID_DetailCha = tblogin.ID_DetailCha WHERE username='" + hom.getName() + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetBoolean("luffy"))
                {
                    botton2.Content = "เลือก";
                }
                if (reader.GetBoolean("naruto"))
                {
                    botton3.Content = "เลือก";
                }
            }



            con.Close();
           
        }
        private void timerruncharacter(object sender, EventArgs e)

        {

            if (status == 1)
            {
                sanji.Source = new BitmapImage(new Uri(@"\picture\character\sanji2.png", UriKind.RelativeOrAbsolute));
                luffy.Source = new BitmapImage(new Uri(@"\picture\character\luffy2.png", UriKind.RelativeOrAbsolute));
                naruto.Source = new BitmapImage(new Uri(@"\picture\character\naruto2.png", UriKind.RelativeOrAbsolute));


                status = 2;
            }
            else if (status == 2)
            {
                sanji.Source = new BitmapImage(new Uri(@"\picture\character\sanji3.png", UriKind.RelativeOrAbsolute));
                luffy.Source = new BitmapImage(new Uri(@"\picture\character\luffy3.png", UriKind.RelativeOrAbsolute));
                naruto.Source = new BitmapImage(new Uri(@"\picture\character\naruto3.png", UriKind.RelativeOrAbsolute));

                status = 3;
            }
            else if (status == 3)
            {
                sanji.Source = new BitmapImage(new Uri(@"\picture\character\sanji4.png", UriKind.RelativeOrAbsolute));
                luffy.Source = new BitmapImage(new Uri(@"\picture\character\luffy4.png", UriKind.RelativeOrAbsolute));
                naruto.Source = new BitmapImage(new Uri(@"\picture\character\naruto4.png", UriKind.RelativeOrAbsolute));
                status = 4;
            }
            else if (status == 4)
            {
                sanji.Source = new BitmapImage(new Uri(@"\picture\character\sanji5.png", UriKind.RelativeOrAbsolute));
                luffy.Source = new BitmapImage(new Uri(@"\picture\character\luffy5.png", UriKind.RelativeOrAbsolute));
                naruto.Source = new BitmapImage(new Uri(@"\picture\character\naruto5.png", UriKind.RelativeOrAbsolute));

                status = 5;
            }
            else if (status == 5)
            {
                sanji.Source = new BitmapImage(new Uri(@"\picture\character\sanji6.png", UriKind.RelativeOrAbsolute));
                luffy.Source = new BitmapImage(new Uri(@"\picture\character\luffy6.png", UriKind.RelativeOrAbsolute));
                naruto.Source = new BitmapImage(new Uri(@"\picture\character\naruto6.png", UriKind.RelativeOrAbsolute));

                status = 6;
            }
            else if (status == 6)
            {
                sanji.Source = new BitmapImage(new Uri(@"\picture\character\sanji7.png", UriKind.RelativeOrAbsolute));
                luffy.Source = new BitmapImage(new Uri(@"\picture\character\luffy7.png", UriKind.RelativeOrAbsolute));
                naruto.Source = new BitmapImage(new Uri(@"\picture\character\naruto7.png", UriKind.RelativeOrAbsolute));

                status = 7;
            }
            else if (status == 7)
            {
                sanji.Source = new BitmapImage(new Uri(@"\picture\character\sanji8.png", UriKind.RelativeOrAbsolute));
                luffy.Source = new BitmapImage(new Uri(@"\picture\character\luffy8.png", UriKind.RelativeOrAbsolute));
                naruto.Source = new BitmapImage(new Uri(@"\picture\character\naruto8.png", UriKind.RelativeOrAbsolute));

                status = 8;
            }
            else if (status == 8)
            {
                sanji.Source = new BitmapImage(new Uri(@"\picture\character\sanji1.png", UriKind.RelativeOrAbsolute));
                luffy.Source = new BitmapImage(new Uri(@"\picture\character\luffy1.png", UriKind.RelativeOrAbsolute));
                naruto.Source = new BitmapImage(new Uri(@"\picture\character\naruto1.png", UriKind.RelativeOrAbsolute));

                status = 1;
            }

        



        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            map.setCharacter("sanji");
         



        }

        private void botton2_Click(object sender, RoutedEventArgs e)
        {
            if (hom.getCoin() >= 2900 && botton2.Content.Equals("2900"))
            {

                int conf = hom.getCoin() - 2900;
                string sql = "UPDATE tblogin SET coin = '" + conf + "' WHERE username='" + hom.getName() + "'";               
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteReader();
                con.Close();
                sql = "UPDATE detailcha SET luffy=TRUE WHERE ID_DetailCha=(SELECT ID_DetailCha FROM tblogin WHERE username = '" + hom.getName() + "')";
                MySqlCommand cmd2 = new MySqlCommand(sql, con);
                con.Open();
                cmd2.ExecuteReader();
                con.Close();
                botton2.Content = "เลือก";
                coin.Content = conf;
            }
            else if (botton2.Content.Equals("เลือก"))
            {
                map.setCharacter("luffy");
            }
             else
            {

                MessageBox.Show("coin ไม่เพียงพอ");
            }


        }

        private void botton3_Click(object sender, RoutedEventArgs e)
        {
            if (hom.getCoin() >= 3900 && botton3.Content.Equals("3900"))
            {

                int conf = hom.getCoin() - 3900;
                string sql = "UPDATE tblogin SET coin = '" + conf + "' WHERE username='" + hom.getName() + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteReader();
                con.Close();
                sql = "UPDATE detailcha SET naruto=TRUE WHERE ID_DetailCha=(SELECT ID_DetailCha FROM tblogin WHERE username = '" + hom.getName() + "')";
                MySqlCommand cmd2 = new MySqlCommand(sql, con);
                con.Open();
                cmd2.ExecuteReader();
                con.Close();
                botton3.Content = "เลือก";
                coin.Content = conf;
            }
            else if (botton3.Content.Equals("เลือก"))
            {
                map.setCharacter("naruto");
            }
             else
            {

                MessageBox.Show("coin ไม่เพียงพอ");
            }


        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            timercharacter.Stop();
            NavigationService.Navigate(new Uri("Character2.xaml", UriKind.RelativeOrAbsolute));
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            timercharacter.Stop();
            NavigationService.Navigate(new Uri("Home.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
