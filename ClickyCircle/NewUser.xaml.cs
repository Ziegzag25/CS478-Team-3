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
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        public NewUser()
        {
            InitializeComponent();
        }

        

        private void BTNConfirm_Click(object sender, RoutedEventArgs e)
        {
            //needs way to save user data


            //check to see if passwords match
            if (PWDPassword.Password != PWDPassword.Password)
            {
                MessageBox.Show("Password do not match");

            }
            //"" is not a perfect solution, it can be easily bypassed
            //goes for login page too 
            else if(PWDPassword.Password == "" || PWDPasswordCheck.Password =="")
                {
                MessageBox.Show("Please enter a Username/Password");

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
