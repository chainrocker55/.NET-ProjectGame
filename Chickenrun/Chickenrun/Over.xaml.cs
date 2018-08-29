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
    /// Interaction logic for Over.xaml
    /// </summary>
    public partial class Over : Page
    {
        public Over()
        {
            InitializeComponent();
        }
        Map map = new Map();
        Page1 hom = new Page1();
        int conf;
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
           
            showscore.Content = map.getScore()-10;
            int exp;
            showcoin.Content = map.getCoin();
            exp = ((map.getScore() - 10) + map.getCoin()) / 15;
            showexp.Content = exp;
            conf = map.getCoin() + hom.getCoin();
           
            string sql = "UPDATE tblogin SET coin = '"+conf+"' WHERE username='"+hom.getName()+"'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=chain;password=chain555;database=tblogin");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
            exp = exp + hom.getLv();
            sql = "UPDATE tblogin SET exp = '" + exp + "' WHERE username='" + hom.getName() + "'"; 
            MySqlCommand cmd2 = new MySqlCommand(sql, con);
            con.Open();
            cmd2.ExecuteReader();
            con.Close();

           
            
           
               if (map.getScore() - 10 > hom.getScore())
                {
                int scoreset = map.getScore() - 10;
                sql = "UPDATE tblogin SET score = '" + scoreset + "' WHERE username='" + hom.getName() + "'";
                MySqlCommand cmd3 = new MySqlCommand(sql, con);
                con.Open();
                cmd3.ExecuteReader();
                con.Close();
                }
            
            

        }


        private void home_Click(object sender, RoutedEventArgs e)
        {
            
                NavigationService.Navigate(new Uri("Home.xaml", UriKind.RelativeOrAbsolute));
            
        }
    }
}
