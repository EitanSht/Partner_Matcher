using PartnerMatcher.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace PartnerMatcher.View
{
    /// <summary>
    /// Interaction logic for CriteriaSearchWindow.xaml
    /// </summary>
    public partial class CriteriaSearchWindow : Window
    {
        private DataTable dt;
        private string loggedUserID;
        private MyController m_controller;

        private string m_user;
        private List<string> m_fields;
        private Dictionary<Tuple<string, string>, string[]> m_criteriaDetails;

        public CriteriaSearchWindow(string loggedUser, List<string> fields, Dictionary<Tuple<string, string>, string[]> criteriaDetails, MyController controller)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            loggedUserID = loggedUser;
            m_fields = fields;
            m_criteriaDetails = criteriaDetails;
            m_user = loggedUser;
            m_controller = controller;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //show relevant fields
            foreach (string f in m_fields)
            {
                field_comboBox.Items.Add(f);
            }
        }

        //Display records in grid
        private void BindGrid()
        {
            object[] critDat = new object[] { lbl_0.Content, lbl_1.Content, lbl_2.Content, lbl_3.Content, criteria_0_box.Text, criteria_1_box.Text, criteria_2_box.Text, criteria_3_box.Text };

            //set tabke name - TRICK
            string tblName = field_comboBox.Text + "AdDetails";

            if ((dt = m_controller.getCriteriaSerachResults(tblName, critDat)) == null)
                return;

            dataGrid.ItemsSource = dt.AsDataView();
            if (dt.Rows.Count > 0)
            {
                lblCount.Visibility = Visibility.Hidden;
                results_groupbox.Visibility = Visibility.Visible;
                dataGrid.Visibility = Visibility.Visible;
            }
            else
            {
                lblCount.Visibility = Visibility.Visible;
                results_groupbox.Visibility = Visibility.Hidden;
                dataGrid.Visibility = Visibility.Hidden;
            }
        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            // clears content
            results_groupbox.Visibility = Visibility.Hidden;
            field_comboBox.Text = "Select Field";
            lblCount.Content = "";
            lbl_0.Content = "";
            lbl_1.Content = "";
            lbl_2.Content = "";
            lbl_3.Content = "";
            criteria_0_box.Items.Clear();
            criteria_1_box.Items.Clear();
            criteria_2_box.Items.Clear();
            criteria_3_box.Items.Clear();
            criteria_0_box.Visibility = Visibility.Hidden;
            criteria_1_box.Visibility = Visibility.Hidden;
            criteria_2_box.Visibility = Visibility.Hidden;
            criteria_3_box.Visibility = Visibility.Hidden;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            if (field_comboBox.Text.Equals("Select Field"))
                MessageBox.Show("Please select a field of interest", "Error");
            else if ((criteria_0_box.Text.Equals("")) || (criteria_1_box.Text.Equals("")) || (criteria_2_box.Text.Equals("")) || (criteria_3_box.Text.Equals("")))
                MessageBox.Show("Please select all sub catagories", "Input Missing");
            else
            {
                BindGrid();
            }
        }

        private void field_comboBox_DropDownClosed(object sender, EventArgs e)
        {
            if ((!field_comboBox.Text.Equals("")) && (!field_comboBox.Text.Equals("Select Field")))
            {
                lbl_0.Content = "";
                lbl_1.Content = "";
                lbl_2.Content = "";
                lbl_3.Content = "";
                criteria_0_box.Items.Clear();
                criteria_1_box.Items.Clear();
                criteria_2_box.Items.Clear();
                criteria_3_box.Items.Clear();
                criteria_0_box.Visibility = Visibility.Visible;
                criteria_1_box.Visibility = Visibility.Visible;
                criteria_2_box.Visibility = Visibility.Visible;
                criteria_3_box.Visibility = Visibility.Visible;

                Tuple<string, string> t;
                string[] subC;
                int i = 0;

                foreach (var item in m_criteriaDetails)
                {
                    t = item.Key;
                    subC = item.Value;
                    if (t.Item1.Equals(field_comboBox.Text))
                    {
                        switch (i)
                        {
                            case 0:
                                lbl_0.Content = t.Item2;
                                foreach (var str in subC)
                                {
                                    criteria_0_box.Items.Add(str);
                                }
                                i++;
                                break;

                            case 1:
                                lbl_1.Content = t.Item2;
                                foreach (var str in subC)
                                {
                                    criteria_1_box.Items.Add(str);
                                }
                                i++;
                                break;

                            case 2:
                                lbl_2.Content = t.Item2;
                                foreach (var str in subC)
                                {
                                    criteria_2_box.Items.Add(str);
                                }
                                i++;
                                break;

                            case 3:
                                lbl_3.Content = t.Item2;
                                foreach (var str in subC)
                                {
                                    criteria_3_box.Items.Add(str);
                                }
                                i++;
                                break;
                        }
                    }
                }
            }
        }
    }
}