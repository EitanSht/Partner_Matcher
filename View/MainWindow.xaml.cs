using PartnerMatcher.View;
using System;
using System.Data.OleDb;
using System.Windows;
using PartnerMatcher.Controller;
using System.Collections.Generic;

namespace PartnerMatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        private OleDbConnection connection;
        IController m_controller;
        Dictionary<string, ICommand> m_CommandDic;//holds the controller commands
        //DataTable dataTable;

        public MainWindow()
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
            LoginWindow loginWin = new LoginWindow();
            this.Hide();
            loginWin.ShowDialog();
            this.ShowDialog();
        }

        private void addUserbtn_Click(object sender, RoutedEventArgs e)
        {
            W_AddUser addUser = new W_AddUser();
            this.Hide();
            addUser.ShowDialog();
            this.ShowDialog();
        }

        void IView.Start()
        {
            throw new NotImplementedException();
        }


        //TODO: להעביר הודעות חלון (מסג' בוקס) לכן , קונטרולר שולח את ההודעות מהמודל למשתמש דרך המתודה הזו)
        /// <summary>
        /// shows messages for the user
        /// </summary>
        /// <param name="output">the ourut strings</param>
        void IView.Output(params string[] output)
        {
            MessageBox.Show(output[0], output[1]);
        }



        /// <summary>
        /// initates the  MVC - view controller connection
        /// </summary>
        /// <param name="controller">the current program controller</param>
        void IView.setcontroller(IController controller)
        {
            m_controller = controller;
        }


        //initiates the controller commands available to view
        void IView.GetCommands()
        {
            m_CommandDic = m_controller.GetCommands();
        }
    }
}