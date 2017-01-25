using PartnerMatcher.Controller;
using System;
using System.Windows;

namespace PartnerMatcher.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private ICommand m_cmd;

        public LoginWindow(ICommand cmd)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            m_cmd = cmd;
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
            else if (m_cmd.DoCommand(userName_txt.Text, password_txt.Password.ToString()))//check if user at system
            {
                this.Close();
                return;
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