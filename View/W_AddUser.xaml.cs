using System;
using System.Data.OleDb;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using PartnerMatcher.Controller;
using System.Text.RegularExpressions;

namespace PartnerMatcher.View
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class W_AddUser : Window
    {
        private OleDbConnection connection;
        private string filePath;
        private ICommand m_comm_AddUser;

        public W_AddUser(ICommand comm_AddUser)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            m_comm_AddUser = comm_AddUser;

        }
        /*
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                connection = new OleDbConnection();
                connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=DataSource.accdb; Persist Security Info=False";
                connection.Open();
                checkConnection.Content = "- Connection to data base successful";
                connection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error: \n" + ex.ToString(), "Error Message");
            }
        }*/

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void userName_txt_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            // clears text boxes
            ClearFields();

        }

        private void ClearFields()
        {
            // clears text boxes
            firstName_txt.Text = String.Empty;
            lastName_txt.Text = String.Empty;
            email_txt.Text = String.Empty;
            password_txt.Clear();
            phoneNumber_txt.Text = String.Empty;
            address_txt.Text = String.Empty;
            gender_box.Text = "Select Gender";
            date_btn.Text = "";
            filePath = "";
        }




        /// <summary>
        /// checks user input leagality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            string errorMsg = "";
            if (firstName_txt.Text.Equals(""))
                errorMsg += "Please enter a first name";
            if (lastName_txt.Text.Equals(""))
                errorMsg += "Please enter a last name";
            if (email_txt.Text.Equals(""))
                errorMsg += "\nPlease enter an E-Mail address";
            if (!email_txt.Text.Contains('@'))
                errorMsg += "\nIllegal E-Mail address - format should be like \"name@domain.com\"";
            if (password_txt.Text.Equals(""))
                errorMsg += "\nPlease enter a password";
            if (gender_box.Text.Equals("Select Gender"))
                errorMsg += "\nPlease select a gender";
            if (date_btn.Text.Equals(""))
                errorMsg += "\nPlease select a birth date";
            if (phoneNumber_txt.Text.Equals(""))
                errorMsg += "\nPlease enter a phone number";
            if (!IsPhoneNumber(phoneNumber_txt.Text))
                errorMsg += "\nPlease enter a phone number";
            if (address_txt.Text.Equals(""))
                errorMsg += "\nPlease enter an address";
            if (errorMsg.Length > 0)
            {
                System.Windows.MessageBox.Show(errorMsg, "Missing Details");
            }
            //if the user input is llegal
            else
            {
                bool succ;
                succ = m_comm_AddUser.DoCommand(email_txt.Text, firstName_txt.Text, lastName_txt.Text, password_txt.Text, gender_box.Text, date_btn.Text, phoneNumber_txt.Text, address_txt.Text, filePath);
                if (succ)
                    ClearFields();








            }

        }





        public static bool IsPhoneNumber(string number)
        {
            return (Regex.Match(number, @"^(0\d-\d{7})$").Success || Regex.Match(number, @"^(0\d{2}-\d{7})$").Success);
        }

        // Creates a random authentication password
        private static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }








        private void uploadCV_btn_Click(object sender, RoutedEventArgs e)
        {
            if (email_txt.Text.Equals(""))
                System.Windows.MessageBox.Show("Please Enter An Email Address", "Error Saving");
            else
            {
                if (!Directory.Exists(".\\CV"))
                {
                    Directory.CreateDirectory("CV");
                }
                OpenFileDialog file = new OpenFileDialog();
                file.InitialDirectory = @"c:\";
                file.Filter = "doc files (*.doc)|*.doc|All files (*.*)|*.*";
                if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    filePath = file.FileName;
                }
            }
        }
    }
}