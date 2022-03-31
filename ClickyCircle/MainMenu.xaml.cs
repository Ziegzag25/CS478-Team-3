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
using System.Windows.Shapes;

namespace ClickyCircle
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        //smiple main menu to add other features
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
          
                // just plays the demo
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();

            

            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //enable buttons after selcting a song   
           

                BtnStart.IsEnabled = true;
                BTNLeaderBoard.IsEnabled = true;
            
            
        }

        private void BTNLeaderBoard_Click(object sender, RoutedEventArgs e)
        {
            //opens leader board for a song
            Window1 window = new Window1();
            window.ShowDialog();
           

        }

        private void BTNLogin_Click(object sender, RoutedEventArgs e)
        {
            Login lg = new Login();
            lg.Show();
        }

        private void BTNNew_User_Click(object sender, RoutedEventArgs e)
        {
            NewUser nu = new NewUser();
            nu.Show();
        }
    }
}
