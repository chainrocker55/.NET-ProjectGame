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
    /// Interaction logic for Map.xaml
    /// </summary>
   
    public partial class Map : Page
    {
       
        public Map()
        {
            InitializeComponent();
        }
        Random randomizer = new Random();

        int adtend1;
        int adtend2;
        int adtend3;
        private  static string player = "sanji";
        private  static string petset = "bot";
        private static int scoregame = 0;
        private static int coin = 0;

        bool jump;       
        int g = 20;
        int force;    
        

        int statusbot = 1;
        int statuschicken = 1;
        int statuscoin = 1;
        int statusbin = 1;
        int status = 1;
        bool set = true;

        int speed = 1;
        int speed1 = 1;
        int speed2 = 1;
        public void setCharacter(string name)
        {
            player = name;
        }
        public string getCharacter()
        {
            return player;
        }
        public void setPet(string name)
        {
            petset = name;
        }
        public string getPet()
        {
            return petset;
        }


        
       
        public void setCoin(int n)
        {
            coin = n;
        }
        public int getCoin()
        {
            return coin;
        }
       
        public int getScore()
        {
            return scoregame ;
        }


       
        // speedmap
        
        DispatcherTimer timercharacter = new DispatcherTimer();
        DispatcherTimer timerpet = new DispatcherTimer();
        DispatcherTimer timerscore = new DispatcherTimer();
        DispatcherTimer timermap = new DispatcherTimer();
        DispatcherTimer timerbot = new DispatcherTimer();
        DispatcherTimer timerrandom = new DispatcherTimer();
        private void Canvas_Loaded_1(object sender, RoutedEventArgs e)
        {         

            this.Focus();
            
           
            timercharacter.Tick += new EventHandler(timerruncharacter);
            timercharacter.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timercharacter.Start();



            
            timerpet.Tick += new EventHandler(timerrunpet);
            timerpet.Interval = new TimeSpan(0, 0, 0, 0, 180);
            timerpet.Start();

            
            timerscore.Tick += new EventHandler(timerrunscore);
            timerscore.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timerscore.Start();

            timermap.Tick += new EventHandler(timerrunmap);
            timermap.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timermap.Start();

            timerrandom.Tick += new EventHandler(timerrunrandom);
            timerrandom.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timerrandom.Start();

            timerbot.Tick += new EventHandler(timerrunbot);
            timerbot.Interval = new TimeSpan(0, 0, 0, 0, 15);
            timerbot.Start();

            scoregame = 0;

        }

        private void timerrunbot(object sender, EventArgs e)
        {
            //jump
          

            if (Canvas.GetTop(character) >= 290)
            {

                Canvas.SetTop(character, Canvas.GetTop(character) - 30);
                Canvas.SetTop(pet, Canvas.GetTop(pet) - 30);

                jump = false;
            }
            if (jump == true)
            {

                Canvas.SetTop(character, Canvas.GetTop(character) - force);
                Canvas.SetTop(pet, Canvas.GetTop(pet) - force);
                force -= 1;
            }
            //botrun
            Canvas.SetLeft(chicken1, Canvas.GetLeft(chicken1) - 5);
            Canvas.SetLeft(chicken3, Canvas.GetLeft(chicken3) - 5);
            Canvas.SetLeft(bin, Canvas.GetLeft(bin) - 13);

        }
        private void timerrunscore(object sender, EventArgs e)
        {


            scoremap.Content = scoregame;
            scoregame += 10;

            coinshow.Content = coin;
            
        }

        private void timerrunrandom(object sender, EventArgs e)
        {

            adtend1 = randomizer.Next(100) + 700;
            adtend2 = randomizer.Next(100) + 1300;
            adtend3 = randomizer.Next(700) + 7000;


        }
        
        
        //เวลาของแมพ
        private void timerrunmap(object sender, EventArgs e)
        {
            soundbackgound.Play();
            if (set == true && Canvas.GetLeft(character) <= 60)
            {
                Canvas.SetLeft(character, Canvas.GetLeft(character) + 2);
                Canvas.SetLeft(pet, Canvas.GetLeft(pet) + 2);

                //set = false;
            }
            
            //clonebot
            if(Canvas.GetLeft(chicken1) < -5)
            {
                
                Canvas.SetLeft(chicken1, Canvas.GetLeft(chicken1) + adtend1);
            }
          
            if (Canvas.GetLeft(chicken3) < -5 )
            {
               
                Canvas.SetLeft(chicken3, Canvas.GetLeft(chicken3) + adtend2);
            }
            if (Canvas.GetLeft(bin) < -5) 
                
            {

                Canvas.SetLeft(bin, Canvas.GetLeft(bin) + adtend3);
            }
            //coincoin&&silver

            if (Canvas.GetLeft(coin1) < -5)
            {
                
                Canvas.SetLeft(coin1, Canvas.GetLeft(coin1) + adtend1);
            }
            if (Canvas.GetLeft(coin2) < -5)
            {
                
                Canvas.SetLeft(coin2, Canvas.GetLeft(coin2) + adtend2);
            }
            if (Canvas.GetLeft(coin3) < -5)
            {
                
                Canvas.SetLeft(coin3, Canvas.GetLeft(coin3) + adtend1);
            }
            if (Canvas.GetLeft(silver1) < -5)
            {
               
                Canvas.SetLeft(silver1, Canvas.GetLeft(silver1) + adtend1);
            }
            if (Canvas.GetLeft(silver2) < -5)
            {
               
                Canvas.SetLeft(silver2, Canvas.GetLeft(silver2) + adtend2);
            }
            if (Canvas.GetLeft(silver3) < -5)
            {
                
                Canvas.SetLeft(silver3, Canvas.GetLeft(silver3) + adtend1);
            }
            if (Canvas.GetLeft(silver4) < -5)
            {
                
                Canvas.SetLeft(silver4, Canvas.GetLeft(silver4) + adtend2);
            }

            //maprun
            if (Canvas.GetLeft(im1) > -700)
            {
                speed = 1;
            }
            else if (Canvas.GetLeft(im1) < 0)
            {
                speed = 2;
            }


            if (speed == 1)
            {
                Canvas.SetLeft(im1, Canvas.GetLeft(im1) - 0.5);
                Canvas.SetLeft(im2, Canvas.GetLeft(im2) - 0.5);


            }
            else
            {
                Canvas.SetLeft(im1, Canvas.GetLeft(im1) + 700);
                Canvas.SetLeft(im2, Canvas.GetLeft(im2) + 700);


            }


            if (Canvas.GetLeft(im3) > -700)
            {
                speed1 = 1;
            }
            else if (Canvas.GetLeft(im3) < 0)
            {
                speed1 = 2;
            }


            if (speed1 == 1)
            {
                Canvas.SetLeft(im3, Canvas.GetLeft(im3) - 1);
                Canvas.SetLeft(im4, Canvas.GetLeft(im4) - 1);

            }
            else
            {

                Canvas.SetLeft(im3, Canvas.GetLeft(im3) + 698);
                Canvas.SetLeft(im4, Canvas.GetLeft(im4) + 698);


            }


            if (Canvas.GetLeft(im5) > -700)
            {
                speed2 = 1;
            }
            else if (Canvas.GetLeft(im1) < 0)
            {
                speed2 = 2;
            }


            if (speed2 == 1)
            {

                Canvas.SetLeft(im5, Canvas.GetLeft(im5) - 0.1);
                Canvas.SetLeft(im6, Canvas.GetLeft(im6) - 0.1);

            }
            else
            {

                Canvas.SetLeft(im5, Canvas.GetLeft(im5) + 700);
                Canvas.SetLeft(im6, Canvas.GetLeft(im6) + 700);

            }



            //coin&&silver run
            Canvas.SetLeft(coin1, Canvas.GetLeft(coin1) - 5);
            Canvas.SetLeft(coin2, Canvas.GetLeft(coin2) - 5);
            Canvas.SetLeft(coin3, Canvas.GetLeft(coin3) - 5);
            Canvas.SetLeft(silver1, Canvas.GetLeft(silver1) - 5);
            Canvas.SetLeft(silver2, Canvas.GetLeft(silver2) - 5);
            Canvas.SetLeft(silver3, Canvas.GetLeft(silver3) - 5);
            Canvas.SetLeft(silver4, Canvas.GetLeft(silver4) - 5);






        }

       

       
        private void timerrunpet(object sender, EventArgs e)
           
        {

            //jump

    

            if (statusbot == 1)
            {
                
                pet.Source = new BitmapImage(new Uri(@"\picture\picture2\"+petset+"2.png", UriKind.Relative));

                statusbot = 2;
            }
            else if (statusbot == 2)
            {
                
                 pet.Source = new BitmapImage(new Uri(@"\picture\picture2\" + petset + "3.png", UriKind.Relative));
                statusbot = 3;
            }
            else if (statusbot == 3)
            {
                
                  pet.Source = new BitmapImage(new Uri(@"\picture\picture2\" + petset + "1.png", UriKind.Relative));
                statusbot = 1;
            }

            

        }

        private void timerruncharacter(object sender, EventArgs e)

        {

      
            if (status == 1)
            {
                character.Source = new BitmapImage(new Uri(@"\picture\character\"+player+"2.png", UriKind.RelativeOrAbsolute));


                status = 2;
            }
            else if (status == 2)
            {
                character.Source = new BitmapImage(new Uri(@"\picture\character\" + player + "3.png", UriKind.RelativeOrAbsolute));

                status = 3;
            }
            else if (status == 3)
            {
                character.Source = new BitmapImage(new Uri(@"\picture\character\" + player + "4.png", UriKind.RelativeOrAbsolute));
                status = 4;
            }
            else if (status == 4)
            {
                character.Source = new BitmapImage(new Uri(@"\picture\character\" + player + "5.png", UriKind.RelativeOrAbsolute));

                status = 5;
            }
            else if (status == 5)
            {
                character.Source = new BitmapImage(new Uri(@"\picture\character\" + player + "6.png", UriKind.RelativeOrAbsolute));

                status = 6;
            }
            else if (status == 6)
            {
                character.Source = new BitmapImage(new Uri(@"\picture\character\" + player + "7.png", UriKind.RelativeOrAbsolute));

                status = 7;
            }
            else if (status == 7)
            {
                character.Source = new BitmapImage(new Uri(@"\picture\character\" + player + "8.png", UriKind.RelativeOrAbsolute));

                status = 8;
            }
            else if (status == 8)
            {
                character.Source = new BitmapImage(new Uri(@"\picture\character\" + player + "1.png", UriKind.RelativeOrAbsolute));

                status = 1;
            }

            // เมื่อตาย
            double dead1 = Math.Sqrt(Math.Pow(Canvas.GetTop(chicken1) - Canvas.GetTop(character), 2) + Math.Pow(Canvas.GetLeft(chicken1) - Canvas.GetLeft(character), 2));
            double dead2 = Math.Sqrt(Math.Pow(Canvas.GetTop(chicken3) - Canvas.GetTop(character), 2) + Math.Pow(Canvas.GetLeft(chicken3) - Canvas.GetLeft(character), 2));
            double dead3 = Math.Sqrt(Math.Pow(Canvas.GetTop(bin) - Canvas.GetTop(character), 2) + Math.Pow(Canvas.GetLeft(bin) - Canvas.GetLeft(character), 2));
            double c1 = Math.Sqrt(Math.Pow(Canvas.GetTop(coin1) - Canvas.GetTop(character), 2) + Math.Pow(Canvas.GetLeft(coin1) - Canvas.GetLeft(character), 2));
            double c2 = Math.Sqrt(Math.Pow(Canvas.GetTop(coin2) - Canvas.GetTop(character), 2) + Math.Pow(Canvas.GetLeft(coin2) - Canvas.GetLeft(character), 2));
            double c3 = Math.Sqrt(Math.Pow(Canvas.GetTop(coin3) - Canvas.GetTop(character), 2) + Math.Pow(Canvas.GetLeft(coin3) - Canvas.GetLeft(character), 2));
            double s1 = Math.Sqrt(Math.Pow(Canvas.GetTop(silver1) - Canvas.GetTop(character), 2) + Math.Pow(Canvas.GetLeft(silver1) - Canvas.GetLeft(character), 2));
            double s2 = Math.Sqrt(Math.Pow(Canvas.GetTop(silver2) - Canvas.GetTop(character), 2) + Math.Pow(Canvas.GetLeft(silver2) - Canvas.GetLeft(character), 2));
            double s3 = Math.Sqrt(Math.Pow(Canvas.GetTop(silver3) - Canvas.GetTop(character), 2) + Math.Pow(Canvas.GetLeft(silver3) - Canvas.GetLeft(character), 2));
            double s4 = Math.Sqrt(Math.Pow(Canvas.GetTop(silver4) - Canvas.GetTop(character), 2) + Math.Pow(Canvas.GetLeft(silver4) - Canvas.GetLeft(character), 2));



            if (dead1 < 41 || dead2 < 41||dead3<35)
            {
                timerscore.Stop();

                soundbackgound.Stop();
                sounddead.Play();
                
                timercharacter.Stop();
                timermap.Stop();
                timerpet.Stop();                
                timerrandom.Stop();
                timerbot.Stop();
                timerscore.Stop();
                character.Source = new BitmapImage(new Uri(@"\picture\character\" + player + "9.png", UriKind.RelativeOrAbsolute));
                MessageBox.Show("You Dead");
                NavigationService.Navigate(new Uri("Over.xaml", UriKind.RelativeOrAbsolute));
            }
            soundcoin.Stop();
            if (c1 < 50)
            {
                Canvas.SetLeft(coin1, Canvas.GetLeft(coin1) + adtend1);
                coin += 10;
                soundcoin.Play();
               
            }
            if (c2 < 50)
            {
                Canvas.SetLeft(coin2, Canvas.GetLeft(coin2) + adtend2);
                coin += 10;
                soundcoin.Play();
            }
            if (c3 < 50)
            {
                Canvas.SetLeft(coin3, Canvas.GetLeft(coin3) + adtend2);
                coin += 10;
                soundcoin.Play();
            }

            if (s1 < 50)
            {
                Canvas.SetLeft(silver1, Canvas.GetLeft(silver1) + adtend1);
                coin += 1;
                soundcoin.Play();
            }
            if (s2 < 50)
            {
                Canvas.SetLeft(silver2, Canvas.GetLeft(silver2) + adtend2);
                coin += 1;
                soundcoin.Play();

            }
            if (s3 < 50)
            {
                Canvas.SetLeft(silver3, Canvas.GetLeft(silver3) + adtend1);
                coin += 1;
                soundcoin.Play();

            }
            if (s4 < 50)
            {
                Canvas.SetLeft(silver4, Canvas.GetLeft(silver4) + adtend2);
                coin += 1;
                soundcoin.Play();
            }



            //chicken
            if (statuschicken == 1)
            {
                chicken1.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken2.png", UriKind.RelativeOrAbsolute));
                chicken3.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken2.png", UriKind.RelativeOrAbsolute));
                statuschicken = 2;
            }
            else if (statuschicken == 2)
            {
                chicken1.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken3.png", UriKind.RelativeOrAbsolute));
                chicken3.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken3.png", UriKind.RelativeOrAbsolute));


                statuschicken = 3;
            }
            else if (statuschicken == 3)
            {
                chicken1.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken4.png", UriKind.RelativeOrAbsolute));
                chicken3.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken4.png", UriKind.RelativeOrAbsolute));

                statuschicken = 4;
            }
            else if (statuschicken == 4)
            {
                chicken1.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken5.png", UriKind.RelativeOrAbsolute));
                chicken3.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken5.png", UriKind.RelativeOrAbsolute));

                statuschicken = 5;
            }
            else if (statuschicken == 5)
            {
                chicken1.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken6.png", UriKind.RelativeOrAbsolute));
                chicken3.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken6.png", UriKind.RelativeOrAbsolute));

                statuschicken = 6;
            }
            else if (statuschicken == 6)
            {
                chicken1.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken7.png", UriKind.RelativeOrAbsolute));
                chicken3.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken7.png", UriKind.RelativeOrAbsolute));

                statuschicken = 7;
            }
            else if (statuschicken == 7)
            {
                chicken1.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken8.png", UriKind.RelativeOrAbsolute));
                chicken3.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken8.png", UriKind.RelativeOrAbsolute));

                statuschicken = 8;
            }
            else if (statuschicken == 8)
            {
                chicken1.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken9.png", UriKind.RelativeOrAbsolute));
                chicken3.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken9.png", UriKind.RelativeOrAbsolute));
                statuschicken = 9;
            }
            else if (statuschicken == 9)
            {
                chicken1.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken1.png", UriKind.RelativeOrAbsolute));
                chicken3.Source = new BitmapImage(new Uri(@"\picture\Bot\chicken1.png", UriKind.RelativeOrAbsolute));
                statuschicken = 1;
            }
            //chickenbin
            if (statusbin == 1)
            {
                bin.Source = new BitmapImage(new Uri(@"\picture\Bot\bin2.png", UriKind.RelativeOrAbsolute));              
                statusbin = 2;
            }
            else if (statusbin == 2)
            {
                bin.Source = new BitmapImage(new Uri(@"\picture\Bot\bin3.png", UriKind.RelativeOrAbsolute));

                statusbin = 3;
            }
            else if (statusbin == 3)
            {
                bin.Source = new BitmapImage(new Uri(@"\picture\Bot\bin4.png", UriKind.RelativeOrAbsolute));

                statusbin = 4;
            }
            else if (statusbin == 4)
            {
                bin.Source = new BitmapImage(new Uri(@"\picture\Bot\bin5.png", UriKind.RelativeOrAbsolute));

                statusbin = 5;
            }
            else if (statusbin == 5)
            {
                bin.Source = new BitmapImage(new Uri(@"\picture\Bot\bin6.png", UriKind.RelativeOrAbsolute));

                statusbin = 6;
            }
            else if (statusbin == 6)
            {
                bin.Source = new BitmapImage(new Uri(@"\picture\Bot\bin1.png", UriKind.RelativeOrAbsolute));

                statusbin = 1;
            }

            //coin&&silver
            //
            //
            if (statuscoin == 1)
            {
                coin1.Source = new BitmapImage(new Uri(@"\picture\picture2\coin2.png", UriKind.RelativeOrAbsolute));
                coin2.Source = new BitmapImage(new Uri(@"\picture\picture2\coin2.png", UriKind.RelativeOrAbsolute));
                coin3.Source = new BitmapImage(new Uri(@"\picture\picture2\coin2.png", UriKind.RelativeOrAbsolute));
                
                silver1.Source = new BitmapImage(new Uri(@"\picture\picture2\silver2.png", UriKind.RelativeOrAbsolute));
                silver2.Source = new BitmapImage(new Uri(@"\picture\picture2\silver2.png", UriKind.RelativeOrAbsolute));
                silver3.Source = new BitmapImage(new Uri(@"\picture\picture2\silver2.png", UriKind.RelativeOrAbsolute));
                silver4.Source = new BitmapImage(new Uri(@"\picture\picture2\silver2.png", UriKind.RelativeOrAbsolute));
                statuscoin = 2;
            }
            else if (statuscoin == 2)
            {
                coin1.Source = new BitmapImage(new Uri(@"\picture\picture2\coin3.png", UriKind.RelativeOrAbsolute));
                coin2.Source = new BitmapImage(new Uri(@"\picture\picture2\coin3.png", UriKind.RelativeOrAbsolute));
                coin3.Source = new BitmapImage(new Uri(@"\picture\picture2\coin3.png", UriKind.RelativeOrAbsolute));

                silver1.Source = new BitmapImage(new Uri(@"\picture\picture2\silver3.png", UriKind.RelativeOrAbsolute));
                silver2.Source = new BitmapImage(new Uri(@"\picture\picture2\silver3.png", UriKind.RelativeOrAbsolute));
                silver3.Source = new BitmapImage(new Uri(@"\picture\picture2\silver3.png", UriKind.RelativeOrAbsolute));
                silver4.Source = new BitmapImage(new Uri(@"\picture\picture2\silver3.png", UriKind.RelativeOrAbsolute));
                statuscoin = 3;
            }
            else if (statuscoin == 3)
            {
                coin1.Source = new BitmapImage(new Uri(@"\picture\picture2\coin4.png", UriKind.RelativeOrAbsolute));
                coin2.Source = new BitmapImage(new Uri(@"\picture\picture2\coin4.png", UriKind.RelativeOrAbsolute));
                coin3.Source = new BitmapImage(new Uri(@"\picture\picture2\coin4.png", UriKind.RelativeOrAbsolute));

                silver1.Source = new BitmapImage(new Uri(@"\picture\picture2\silver4.png", UriKind.RelativeOrAbsolute));
                silver2.Source = new BitmapImage(new Uri(@"\picture\picture2\silver4.png", UriKind.RelativeOrAbsolute));
                silver3.Source = new BitmapImage(new Uri(@"\picture\picture2\silver4.png", UriKind.RelativeOrAbsolute));
                silver4.Source = new BitmapImage(new Uri(@"\picture\picture2\silver4.png", UriKind.RelativeOrAbsolute));
                statuscoin = 4;
            }
            else if (statuscoin == 4)
            {
                coin1.Source = new BitmapImage(new Uri(@"\picture\picture2\coin5.png", UriKind.RelativeOrAbsolute));
                coin2.Source = new BitmapImage(new Uri(@"\picture\picture2\coin5.png", UriKind.RelativeOrAbsolute));
                coin3.Source = new BitmapImage(new Uri(@"\picture\picture2\coin5.png", UriKind.RelativeOrAbsolute));

                silver1.Source = new BitmapImage(new Uri(@"\picture\picture2\silver5.png", UriKind.RelativeOrAbsolute));
                silver2.Source = new BitmapImage(new Uri(@"\picture\picture2\silver5.png", UriKind.RelativeOrAbsolute));
                silver3.Source = new BitmapImage(new Uri(@"\picture\picture2\silver5.png", UriKind.RelativeOrAbsolute));
                silver4.Source = new BitmapImage(new Uri(@"\picture\picture2\silver5.png", UriKind.RelativeOrAbsolute));

                statuscoin = 5;
            }
            else if (statuscoin == 5)
            {
                coin1.Source = new BitmapImage(new Uri(@"\picture\picture2\coin6.png", UriKind.RelativeOrAbsolute));
                coin2.Source = new BitmapImage(new Uri(@"\picture\picture2\coin6.png", UriKind.RelativeOrAbsolute));
                coin3.Source = new BitmapImage(new Uri(@"\picture\picture2\coin6.png", UriKind.RelativeOrAbsolute));

                silver1.Source = new BitmapImage(new Uri(@"\picture\picture2\silver6.png", UriKind.RelativeOrAbsolute));
                silver2.Source = new BitmapImage(new Uri(@"\picture\picture2\silver6.png", UriKind.RelativeOrAbsolute));
                silver3.Source = new BitmapImage(new Uri(@"\picture\picture2\silver6.png", UriKind.RelativeOrAbsolute));
                silver4.Source = new BitmapImage(new Uri(@"\picture\picture2\silver6.png", UriKind.RelativeOrAbsolute));
                statuscoin = 6;
            }
            else if (statuscoin == 6)
            {
                coin1.Source = new BitmapImage(new Uri(@"\picture\picture2\coin7.png", UriKind.RelativeOrAbsolute));
                coin2.Source = new BitmapImage(new Uri(@"\picture\picture2\coin7.png", UriKind.RelativeOrAbsolute));
                coin3.Source = new BitmapImage(new Uri(@"\picture\picture2\coin7.png", UriKind.RelativeOrAbsolute));

                silver1.Source = new BitmapImage(new Uri(@"\picture\picture2\silver7.png", UriKind.RelativeOrAbsolute));
                silver2.Source = new BitmapImage(new Uri(@"\picture\picture2\silver7.png", UriKind.RelativeOrAbsolute));
                silver3.Source = new BitmapImage(new Uri(@"\picture\picture2\silver7.png", UriKind.RelativeOrAbsolute));
                silver4.Source = new BitmapImage(new Uri(@"\picture\picture2\silver7.png", UriKind.RelativeOrAbsolute));

                statuscoin = 7;
            }
            else if (statuscoin == 7)
            {
                coin1.Source = new BitmapImage(new Uri(@"\picture\picture2\coin1.png", UriKind.RelativeOrAbsolute));
                coin2.Source = new BitmapImage(new Uri(@"\picture\picture2\coin1.png", UriKind.RelativeOrAbsolute));
                coin3.Source = new BitmapImage(new Uri(@"\picture\picture2\coin1.png", UriKind.RelativeOrAbsolute));

                silver1.Source = new BitmapImage(new Uri(@"\picture\picture2\silver1.png", UriKind.RelativeOrAbsolute));
                silver2.Source = new BitmapImage(new Uri(@"\picture\picture2\silver1.png", UriKind.RelativeOrAbsolute));
                silver3.Source = new BitmapImage(new Uri(@"\picture\picture2\silver1.png", UriKind.RelativeOrAbsolute));
                silver4.Source = new BitmapImage(new Uri(@"\picture\picture2\silver1.png", UriKind.RelativeOrAbsolute));

                statuscoin = 1;
            }



        }

       

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (jump != true)
            {
                
                if (e.Key == Key.Space)
                {
                   
                    soundjump.Play();
                    jump = true;
                    force = g;
                    
                }
            }

        }
       

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Space)
            {
                soundjump.Stop();               
            }
        }

       
    }
}
