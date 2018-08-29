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
    /// Interaction logic for Pet.xaml
    /// </summary>
    public partial class Pet : Page
    {
        public Pet()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("host=localhost;user=chain;password=chain555;database=tblogin");
        Map map = new Map();
        Page1 hom = new Page1();
        DispatcherTimer timerpet = new DispatcherTimer();
        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {

            timerpet.Tick += new EventHandler(timerrunpet);
            timerpet.Interval = new TimeSpan(0, 0, 0, 0, 180);
            timerpet.Start();
            coin.Content = hom.getCoin();
            lv.Content = hom.getLv();

            string sql = "SELECT * FROM detailpet INNER JOIN tblogin on detailpet.ID_DetailPet = tblogin.ID_DetailPet WHERE username='" + hom.getName() + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetBoolean("diso"))
                {
                    botton2.Content = "เลือก";
                }
                if (reader.GetBoolean("duck"))
                {
                    botton3.Content = "เลือก";
                }
                if (reader.GetBoolean("monkey"))
                {
                    botton4.Content = "เลือก";
                }
            }
            con.Close();
        }
        int statusbot = 1;
        private void timerrunpet(object sender, EventArgs e)
        {
            if (statusbot == 1)
            {

                bot.Source = new BitmapImage(new Uri(@"\picture\picture2\bot2.png", UriKind.Relative));
                diso.Source = new BitmapImage(new Uri(@"\picture\picture2\diso2.png", UriKind.Relative));
                duck.Source = new BitmapImage(new Uri(@"\picture\picture2\duck2.png", UriKind.Relative));
                monkey.Source = new BitmapImage(new Uri(@"\picture\picture2\monkey2.png", UriKind.Relative));

                statusbot = 2;
            }
            else if (statusbot == 2)
            {

                bot.Source = new BitmapImage(new Uri(@"\picture\picture2\bot3.png", UriKind.Relative));
                diso.Source = new BitmapImage(new Uri(@"\picture\picture2\diso3.png", UriKind.Relative));
                duck.Source = new BitmapImage(new Uri(@"\picture\picture2\duck3.png", UriKind.Relative));
                monkey.Source = new BitmapImage(new Uri(@"\picture\picture2\monkey3.png", UriKind.Relative));
                statusbot = 3;
            }
            else if (statusbot == 3)
            {

                bot.Source = new BitmapImage(new Uri(@"\picture\picture2\bot1.png", UriKind.Relative));
                diso.Source = new BitmapImage(new Uri(@"\picture\picture2\diso1.png", UriKind.Relative));
                duck.Source = new BitmapImage(new Uri(@"\picture\picture2\duck1.png", UriKind.Relative));
                monkey.Source = new BitmapImage(new Uri(@"\picture\picture2\monkey1.png", UriKind.Relative));
                statusbot = 1;
            }
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            timerpet.Stop();
            NavigationService.Navigate(new Uri("Home.xaml", UriKind.RelativeOrAbsolute));
        }

        private void botton1_Click(object sender, RoutedEventArgs e)
        {
            map.setPet("bot");
        }

        private void botton2_Click(object sender, RoutedEventArgs e)
        {
            if (hom.getCoin() >= 1000 && botton2.Content.Equals("1000"))
            {

                int conf = hom.getCoin() - 1000;
                string sql = "UPDATE tblogin SET coin = '" + conf + "' WHERE username='" + hom.getName() + "'";
                
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteReader();
                con.Close();
                sql = "UPDATE detailpet SET diso=TRUE WHERE ID_DetailPet=(SELECT ID_DetailPet FROM tblogin WHERE username = '" + hom.getName() + "')";
                MySqlCommand cmd2 = new MySqlCommand(sql, con);
                con.Open();
                cmd2.ExecuteReader();
                con.Close();
                botton2.Content = "เลือก";
                coin.Content = conf;

            }
            else if (botton2.Content.Equals("เลือก"))
            {
                map.setPet("diso");
            }
            else
            {

                MessageBox.Show("coin ไม่เพียงพอ");
            }

        }

        private void botton3_Click(object sender, RoutedEventArgs e)
        {
            if (hom.getCoin() >= 2000 && botton3.Content.Equals("2000"))
            {

                int conf = hom.getCoin() - 2000;
                string sql = "UPDATE tblogin SET coin = '" + conf + "' WHERE username='" + hom.getName() + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteReader();
                con.Close();
                sql = "UPDATE detailpet SET duck=TRUE WHERE ID_DetailPet=(SELECT ID_DetailPet FROM tblogin WHERE username = '" + hom.getName() + "')";
                MySqlCommand cmd2 = new MySqlCommand(sql, con);
                con.Open();
                cmd2.ExecuteReader();
                con.Close();
                botton3.Content = "เลือก";
                coin.Content = conf;

            }
            else if (botton3.Content.Equals("เลือก"))
            {
                map.setPet("duck");
            }
            else
            {

                MessageBox.Show("coin ไม่เพียงพอ");
            }

        }

        private void botton4_Click(object sender, RoutedEventArgs e)
        {
            if (hom.getCoin() >= 3000 && botton4.Content.Equals("3000"))
            {

                int conf = hom.getCoin() - 3000;
                string sql = "UPDATE tblogin SET coin = '" + conf + "' WHERE username='" + hom.getName() + "'";
               
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteReader();
                con.Close();
                sql = "UPDATE detailpet SET monkey=TRUE WHERE ID_DetailPet=(SELECT ID_DetailPet FROM tblogin WHERE username = '" + hom.getName() + "')";
                MySqlCommand cmd2 = new MySqlCommand(sql, con);
                con.Open();
                cmd2.ExecuteReader();
                con.Close();
                botton4.Content = "เลือก";
                coin.Content = conf;

            }
            else if (botton4.Content.Equals("เลือก"))
            {
                map.setPet("monkey");
            }
            else
            {

                MessageBox.Show("coin ไม่เพียงพอ");
            }

        }
    }



}
