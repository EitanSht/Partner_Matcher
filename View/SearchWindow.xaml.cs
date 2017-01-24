using System;
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

        public SearchWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public SearchWindow(string loggedUser)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            loggedUserID = loggedUser;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                connection = new OleDbConnection();
                connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=DataSource.accdb; Persist Security Info=False";
                connection.Open();
                checkConnection.Content = "- Connection to data base successful";

                OleDbCommand cmd_fields = new OleDbCommand();
                cmd_fields.Connection = connection;
                cmd_fields.CommandText = "select * from Fields";

                OleDbDataReader reader = cmd_fields.ExecuteReader();
                while (reader.Read())
                {
                    field_comboBox.Items.Add(reader["FieldName"].ToString());
                }

                OleDbCommand cmd_location = new OleDbCommand();
                cmd_location.Connection = connection;
                cmd_location.CommandText = "select * from Areas";

                reader = cmd_location.ExecuteReader();
                while (reader.Read())
                {
                    location_box.Items.Add(reader["Location"].ToString());
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n" + ex.ToString(), "Error Message");
            }
        }

        //Display records in grid
        private void BindGrid()
        {
            try
            {
                connection.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;


                string tblName = field_comboBox.Text + "AdDetails";
                cmd.CommandText = "select RegularUsers.FirstName,RegularUsers.LastName,Ads.ID," + tblName + ".* from (( Ads inner join " + tblName + " on Ads.ID = " + tblName + ".AdID) inner join UserPubAd on Ads.ID = UserPubAd.AdID) inner join RegularUsers on RegularUsers.ID = UserPubAd.UserID where " + tblName + ".Area = '" + location_box.Text + "'";

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
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
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n" + ex.ToString(), "Error Message");
                connection.Close();
            }
        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            // clears content
            results_groupbox.Visibility = Visibility.Hidden;
            field_comboBox.Text = "Select Field";
            location_box.Text = "Select Location";
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            if (field_comboBox.Text.Equals("Select Field"))
                MessageBox.Show("Please select a field of interest", "Error");
            else if (location_box.Equals("Select Location"))
                MessageBox.Show("Please select a Location", "Error");
            else
            {
                BindGrid();
            }
        }
    }
}
