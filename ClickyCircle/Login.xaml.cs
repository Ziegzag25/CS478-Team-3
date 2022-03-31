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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BTNConfirm_Click(object sender, RoutedEventArgs e)
        {
            //need login process first
            if (TBUserName.Text == "" || PWDPassword.Password == "")
            {
                MessageBox.Show("Please enter your username/password");
            }
            else
            {
                this.Close();
            }
        }

        private void BTNCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
