using System;
using System.Data.OleDb;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.IO;

namespace PartnerMatcher.View
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class W_AddUser : Window
    {
        private OleDbConnection connection;
        private string filePath;

        public W_AddUser()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

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
        }

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

        private void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            string errorMsg = "";
            if (firstName_txt.Text.Equals(""))
                errorMsg += "Please enter a first name";
            if (lastName_txt.Text.Equals(""))
                errorMsg += "Please enter a last name";
            if (email_txt.Text.Equals(""))
                errorMsg += "\nPlease enter an E-Mail address";
            if (password_txt.Password.ToString().Equals(""))
                errorMsg += "\nPlease enter a password";
            if (gender_box.Text.Equals("Select Gender"))
                errorMsg += "\nPlease select a gender";
            if (date_btn.Text.Equals(""))
                errorMsg += "\nPlease select a birth date";
            if (phoneNumber_txt.Text.Equals(""))
                errorMsg += "\nPlease enter a phone number";
            if (address_txt.Text.Equals(""))
                errorMsg += "\nPlease enter an address";
            if (errorMsg.Length > 0)
            {
                System.Windows.MessageBox.Show(errorMsg, "Missing Details");
            }
            else
            {
                try
                {
                    connection.Open();
                    bool exists = false;

                    // create a command to check if the username exists
                    OleDbCommand checkCommand = new OleDbCommand();
                    checkCommand.Connection = connection;
                    checkCommand.CommandText = "select count(*) from RegularUsers where Email='" + email_txt.Text + "'";
                    exists = (int)checkCommand.ExecuteScalar() > 0;

                    if (exists)
                        System.Windows.MessageBox.Show("User Name Already Exists", "Duplication Error");
                    else
                    {
                        string authenticationPass = RandomString(6);

                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        command.CommandText = "insert into RegularUsers (FirstName,LastName,[Password],Gender,BirthDate,PhoneNumber,Address,AuthenticationPassword,Email) " +
                            "values ('" + firstName_txt.Text + "','" + lastName_txt.Text + "','" + password_txt.Password.ToString() + "','" + gender_box.Text + "'," +
                            "'" + date_btn.Text + "','" + phoneNumber_txt.Text + "','" + address_txt.Text + "','" + authenticationPass + "','" + email_txt.Text + "')";
                        command.ExecuteNonQuery();
                        if (File.Exists(filePath))
                        {
                            File.Copy(filePath, ".\\CV\\" + email_txt.Text + ".doc");
                        }
                        System.Windows.MessageBox.Show("New user added", "Submitted Successfully");
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error: \n" + ex.ToString(), "Error Message");
                    connection.Close();
                }
            }
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