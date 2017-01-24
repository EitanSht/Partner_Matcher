using System;
using System.Data.OleDb;
using System.Windows;

namespace PartnerMatcher.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private OleDbConnection connection;

        public LoginWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // TODO: למה לא להתחבר לשרת ברגע שמעלים את התכנית??


            try
            {
                connection = new OleDbConnection();
                connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=DataSource.accdb; Persist Security Info=False";
                connection.Open();
                checkConnection.Content = "- Connection to data base successful";
                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Please download the Microsoft.ACE.OLEDB.12.0 support package", "DataBase Version Error");
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            string errorMsg = "";
            if (userName_txt.Text.Equals(""))
                errorMsg += "Please enter a user name";
            if (password_txt.Password.ToString().Equals(""))
                errorMsg += "\nPlease enter a password";
            if (errorMsg.Length > 0)
            {
                MessageBox.Show(errorMsg, "Missing Details");
            }
            else
            {
                try
                {
                    connection.Open();
                    bool notfound = false;

                    // create a command to check if the username exists
                    OleDbCommand checkUserCommand = new OleDbCommand();
                    OleDbCommand checkPassCommand = new OleDbCommand();
                    checkUserCommand.Connection = connection;
                    checkPassCommand.Connection = connection;
                    checkUserCommand.CommandText = "select count(*) from RegularUsers where Email='" + userName_txt.Text + "'";
                    checkPassCommand.CommandText = "select count(*) from RegularUsers where Email='" + userName_txt.Text + "' and [Password]='" + password_txt.Password.ToString() + "'";
                    notfound = (int)checkUserCommand.ExecuteScalar() == 0;
                    if (notfound)
                        MessageBox.Show("User Name Does Not Exists", "User Name Not Found");
                    else if ((int)checkPassCommand.ExecuteScalar() == 0)
                    {
                        MessageBox.Show("The password is incorrect", "Password Incorrect");
                    }
                    else // user connected
                    {
                        SearchWindow searchWindow = new SearchWindow(userName_txt.Text);
                        this.Hide();
                        searchWindow.ShowDialog();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: \n" + ex.ToString(), "Error Message");
                    connection.Close();
                }
            }
        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            // clears text boxes
            userName_txt.Text = String.Empty;
            password_txt.Clear();
        }
    }
}