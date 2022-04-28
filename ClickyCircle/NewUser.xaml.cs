using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        DataTable dt = new DataTable();
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
            else if (PWDPassword.Password == "" || PWDPasswordCheck.Password == "")
            {
                MessageBox.Show("Please enter a Username/Password");

            }
            else
            {
                //create a data table with desired columns

                dt.TableName = "Userstable";
                dt.Columns.Add("User_Name");
                dt.Columns.Add("Password");
                dt.Columns.Add("Score");

                //add the rows needed
                DataRow dr;
                dr = dt.NewRow();
                dr["User_Name"] = TBUserName.Text;//gets user name and passowrd from tbs
                dr["Password"] = PWDPassword.Password;
                dr["Score"] = 0;


                dt.Rows.Add(dr);
                string Users_Scores = @"User_Scores.xmal";
                if (!File.Exists(Users_Scores))
                {
                    File.Create(Users_Scores);
                }
                else
                    dt.WriteXml("User_Scores.xmal");
                MainMenu mm = new MainMenu();
               
             
                mm.Show();

                this.Close();

            }
        }

        private void BTNCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

