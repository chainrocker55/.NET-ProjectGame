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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void exsit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        
        private void register_Click(object sender, RoutedEventArgs e)
        {
            if (txtpassword.Password.Equals(txtpassword2.Password))
                {
               
                string sql = "SELECT * FROM tblogin WHERE username ='" + txtusername.Text + "'";
                MySqlConnection con = new MySqlConnection("host=localhost;user=chain;password=chain555;database=tblogin");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("มี Username นี้แล้ว");

                }
                else
                {
                    MySqlConnection con2 = new MySqlConnection("host=localhost;user=chain;password=chain555;database=tblogin");
                    sql = "INSERT INTO `detailcha` (`ID_DetailCha`, `luffy`, `naruto`, `sasuke`, `sonic`) VALUES (NULL, '0', '0', '0', '0');" +
                        "INSERT INTO detailpet VALUES (NULL,'0','0','0');INSERT INTO tblogin VALUES (NULL,'"+txtusername.Text+"','"+txtpassword.Password+"','2000','0','0',(SELECT LAST_INSERT_ID(ID_DetailCha) FROM detailcha ORDER BY ID_DetailCha DESC  LIMIT 1),(SELECT LAST_INSERT_ID(ID_DetailPet) FROM detailpet ORDER BY ID_DetailPet DESC  LIMIT 1))";


                    MySqlCommand cmd2 = new MySqlCommand(sql, con2);
                    con2.Open();
                    cmd2.ExecuteReader();
                    
                    con.Close();
                    MessageBox.Show("Success");
                    NavigationService.Navigate(new Uri("Login2.xaml", UriKind.RelativeOrAbsolute));
                }


                con.Close();
                 
                
            }
            else
            {
                MessageBox.Show("รหัสผ่านไม่ตรงกัน");
            }
        }

        private void login1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Login2.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
