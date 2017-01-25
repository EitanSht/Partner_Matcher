using System.Collections.Generic;
using System.Windows;

namespace PartnerMatcher.View
{
    /// <summary>
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        public Results(List<string> s)
        {
            InitializeComponent();
            if (s.Count == 0)
            {
                MessageBox.Show("No requests to show");
                this.Close();
            }
            else
            {
                List<string> col0 = new List<string>();

                List<string> col1 = new List<string>();
                foreach (string ss in s)
                {
                    string[] temp = ss.Split(' ');
                    col0.Add(temp[0]);
                    col1.Add(temp[2]);
                }

                lv0.ItemsSource = col0;
                lv1.ItemsSource = col1;
                lv0.Visibility = Visibility.Visible;
                lv1.Visibility = Visibility.Visible;
                ShowDialog();
            }
        }
    }
}