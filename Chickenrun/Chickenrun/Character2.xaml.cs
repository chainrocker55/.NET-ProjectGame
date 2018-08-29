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
    /// Interaction logic for Character2.xaml
    /// </summary>
    public partial class Character2 : Page
    {
        MySqlConnection con = new MySqlConnection("host=localhost;user=chain;password=chain555;database=tblogin");
        public Character2()
        {
            InitializeComponent();
        }
        Map set = new Map();
        int status = 1;
        DispatcherTimer timercharacter = new DispatcherTimer();
        Page1 hom = new Page1();
        private void Canvas_Loaded_1(object sender, RoutedEventArgs e)
        {
            timercharacter.Tick += new EventHandler(timerruncharacter);
            timercharacter.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timercharacter.Start();
            coin.Content = hom.getCoin();
            lv.Content = hom.getLv()/10;

            string sql = "SELECT * FROM detailcha INNER JOIN tblogin on detailcha.ID_DetailCha = tblogin.ID_DetailCha WHERE username='" + hom.getName() + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open(); 
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetBoolean("sasuke"))
                {
                    botton4.Content = "เลือก";
                }
                if (reader.GetBoolean("sonic"))
                {
                    botton5.Content = "เลือก";
                }
            }
            con.Close();
        }

        private void timerruncharacter(object sender, EventArgs e)

        {

            if (status == 1)
            {
                sasuke.Source = new BitmapImage(new Uri(@"\picture\character\sasuke2.png", UriKind.RelativeOrAbsolute));
                sonic.Source = new BitmapImage(new Uri(@"\picture\character\sonic2.png", UriKind.RelativeOrAbsolute));



                status = 2;
            }
            else if (status == 2)
            {
                sasuke.Source = new BitmapImage(new Uri(@"\picture\character\sasuke3.png", UriKind.RelativeOrAbsolute));
                sonic.Source = new BitmapImage(new Uri(@"\picture\character\sonic3.png", UriKind.RelativeOrAbsolute));


                status = 3;
            }
            else if (status == 3)
            {
                sasuke.Source = new BitmapImage(new Uri(@"\picture\character\sasuke4.png", UriKind.RelativeOrAbsolute));
                sonic.Source = new BitmapImage(new Uri(@"\picture\character\sonic4.png", UriKind.RelativeOrAbsolute));

                status = 4;
            }
            else if (status == 4)
            {
                sasuke.Source = new BitmapImage(new Uri(@"\picture\character\sasuke5.png", UriKind.RelativeOrAbsolute));
                sonic.Source = new BitmapImage(new Uri(@"\picture\character\sonic5.png", UriKind.RelativeOrAbsolute));


                status = 5;
            }
            else if (status == 5)
            {
                sasuke.Source = new BitmapImage(new Uri(@"\picture\character\sasuke6.png", UriKind.RelativeOrAbsolute));
                sonic.Source = new BitmapImage(new Uri(@"\picture\character\sonic6.png", UriKind.RelativeOrAbsolute));


                status = 6;
            }
            else if (status == 6)
            {
                sasuke.Source = new BitmapImage(new Uri(@"\picture\character\sasuke7.png", UriKind.RelativeOrAbsolute));
                sonic.Source = new BitmapImage(new Uri(@"\picture\character\sonic7.png", UriKind.RelativeOrAbsolute));


                status = 7;
            }
            else if (status == 7)
            {
                sasuke.Source = new BitmapImage(new Uri(@"\picture\character\sasuke8.png", UriKind.RelativeOrAbsolute));
                sonic.Source = new BitmapImage(new Uri(@"\picture\character\sonic8.png", UriKind.RelativeOrAbsolute));


                status = 8;
            }
            else if (status == 8)
            {
                sasuke.Source = new BitmapImage(new Uri(@"\picture\character\sasuke1.png", UriKind.RelativeOrAbsolute));
                sonic.Source = new BitmapImage(new Uri(@"\picture\character\sonic1.png", UriKind.RelativeOrAbsolute));


                status = 1;
            }





        }
        
        private void botton4_Click(object sender, RoutedEventArgs e)
        {
            if (hom.getCoin() >= 4900 && botton4.Content.Equals("4900"))
            {
                int conf = hom.getCoin() - 4900;
                string sql = "UPDATE tblogin SET coin = '" + conf + "' WHERE username='" + hom.getName() + "'";
                
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteReader();
                con.Close();
                sql = "UPDATE detailcha SET sasuke=TRUE WHERE ID_DetailCha=(SELECT ID_DetailCha FROM tblogin WHERE username = '" + hom.getName() + "')";
                MySqlCommand cmd2 = new MySqlCommand(sql, con);
                con.Open();
                cmd2.ExecuteReader();
                con.Close();
                botton4.Content = "เลือก";
                coin.Content = conf;
            }
            else if(botton4.Content.Equals("เลือก"))
            {
                set.setCharacter("sasuke");
            }
            else
            {

                MessageBox.Show("coin ไม่เพียงพอ");
            }
            
            
        }

        private void botton5_Click(object sender, RoutedEventArgs e)
        {
            if (hom.getCoin() >= 5900 && botton5.Content.Equals("5900"))
            {

                int conf = hom.getCoin() - 5900;
                string sql = "UPDATE tblogin SET coin = '" + conf + "' WHERE username='" + hom.getName() + "'";
              
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteReader();
                con.Close();
                sql = "UPDATE detailcha SET sonic=TRUE WHERE ID_DetailCha=(SELECT ID_DetailCha FROM tblogin WHERE username = '" + hom.getName() + "')";
                MySqlCommand cmd2 = new MySqlCommand(sql, con);
                con.Open();
                cmd2.ExecuteReader();
                con.Close();
                botton5.Content = "เลือก";
                coin.Content = conf;
                
            }
            else if (botton5.Content.Equals("เลือก"))
            {
                set.setCharacter("sonic");
            }
            else
            {

                MessageBox.Show("coin ไม่เพียงพอ");
            }


        }

        private void return_Click(object sender, RoutedEventArgs e)

        {
            timercharacter.Stop();
            NavigationService.Navigate(new Uri("Character.xaml", UriKind.RelativeOrAbsolute));
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            timercharacter.Stop();
            NavigationService.Navigate(new Uri("Home.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
