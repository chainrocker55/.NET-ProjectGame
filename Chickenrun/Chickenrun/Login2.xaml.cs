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
using MySql.Data.MySqlClient;

namespace Chickenrun
{
    /// <summary>
    /// Interaction logic for Login2.xaml
    /// </summary>
    public partial class Login2 : Page
    {
        public Login2()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("host=localhost;user=chain;password=chain555;database=tblogin");
        private void login1_Click(object sender, RoutedEventArgs e)
            {
             string sql = "SELECT * FROM tblogin WHERE username ='"+txtusername.Text+"'AND password='"+txtpassword.Password+"'";
             
             MySqlCommand cmd = new MySqlCommand(sql, con);
             con.Open();
             MySqlDataReader reader = cmd.ExecuteReader();

             if (reader.Read())
                 {
                Page1 home = new Page1();
                home.setName(txtusername.Text); 

                NavigationService.Navigate(new Uri("Home.xaml", UriKind.RelativeOrAbsolute));
                con.Close();

                 }
            else
            {
                con.Close();
                MessageBox.Show("Username หรือ Password ผิด");
            }
           



        }

        private void exsit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Register.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            con.Close();
        }
    }
}
