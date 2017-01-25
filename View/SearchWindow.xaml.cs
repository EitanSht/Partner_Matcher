using PartnerMatcher.Controller;
using PartnerMatcher.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows;

namespace PartnerMatcher.View
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private OleDbConnection connection;
        private DataTable dt;
        private string loggedUserID;
        private MyController m_cont;
        private List<string> m_fields;

        public SearchWindow(IController cont, List<string> fields)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            m_cont = (MyController)cont;
            m_fields = fields;
        }

        public SearchWindow(string loggedUser)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            loggedUserID = loggedUser;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            foreach (string field in m_fields)
            {


                field_comboBox.Items.Add(field);
            }





        }

        //Display records in grid
        private void BindGrid()
        {
            try
            {
                dt = m_cont.AdSearch(field_comboBox.Text);

                dataGrid.ItemsSource = dt.AsDataView();
                results_groupbox.Visibility = Visibility.Visible;

                if (dt.Rows.Count > 0)
                {
                    lblCount.Visibility = Visibility.Hidden;
                    dataGrid.Visibility = Visibility.Visible;
                }
                else
                {
                    lblCount.Visibility = Visibility.Visible;
                    dataGrid.Visibility = Visibility.Hidden;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n" + ex.ToString(), "Error Message");

            }
        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            // clears content
            results_groupbox.Visibility = Visibility.Hidden;
            field_comboBox.Text = "Select Field";
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            if (field_comboBox.Text.Equals("Select Field"))
                MessageBox.Show("Please select a field of interest", "Error");
            else
            {
                BindGrid();
            }
        }


    }
}

