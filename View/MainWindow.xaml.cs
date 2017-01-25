using PartnerMatcher.Controller;
using PartnerMatcher.View;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows;

namespace PartnerMatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        private OleDbConnection connection;
        private IController m_controller;
        private string m_curUser = "";

        private Dictionary<string, ICommand> m_CommandDic;//holds the controller commands
        //DataTable dataTable;

        public MainWindow(IController c)
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            m_controller = c;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                connection = new OleDbConnection();
                connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=DataSource.accdb; Persist Security Info=False";
                connection.Open();
                checkConnection.Content = "- Connection Established";
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n" + ex.ToString(), "Error Message");
            }
        }

        // When window is loading

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void userLogin_Btn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWin = new LoginWindow(m_CommandDic["UserLogin"]);
            this.Hide();
            loginWin.ShowDialog();

            if (m_curUser != "")
            {
                loginWin.Close();
                Menu mune = new Menu(m_CommandDic, (MyController)m_controller, m_curUser);
                mune.ShowDialog();
                m_curUser = "";
            }
            this.Show();
            //System.Windows.Application.Current.Shutdown();
        }

        private void addUserbtn_Click(object sender, RoutedEventArgs e)
        {
            W_AddUser addUser = new W_AddUser(m_CommandDic["AddUser"]);
            this.Hide();
            addUser.ShowDialog();
            this.ShowDialog();
        }

        void IView.Start()
        {
            GetCommands();
            this.ShowDialog();
        }

        /// <summary>
        /// shows messages for the user
        /// </summary>
        /// <param name="output">the ourut strings</param>
        void IView.Output(params string[] output)
        {
            if (output.Length == 1)
                MessageBox.Show(output[0]);
            else
                MessageBox.Show(output[0], output[1]);
        }

        //initiates the controller commands available to view
        private void GetCommands()
        {
            m_CommandDic = m_controller.GetCommands();
        }

        void IView.SetController(IController controller)
        {
            m_controller = controller;
        }

        void IView.setCurUser(string user)
        {
            m_curUser = user;
        }

        private void Startsearch_Btn(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("We really command you to sign in to our site! \n With sinning a new world of partner searching will open to you! (:");
            SearchWindow search = new SearchWindow(m_controller, m_controller.getFields());
            search.ShowDialog();
        }
    }
}