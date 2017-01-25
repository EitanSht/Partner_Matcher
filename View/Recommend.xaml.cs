using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PartnerMatcher.View
{
    /// <summary>
    /// Interaction logic for Recommend.xaml
    /// </summary>
    public partial class Recommend : Window
    {
        private string m_selcet_field = "";
        private string m_userEmail = "";
        private Controller.IController m_controller;

        public string SelectefField
        {
            get { return m_selcet_field; }
        }

        public Recommend(List<string> list, string userEmail, Controller.IController controller)
        {
            InitializeComponent();
            foreach (string s in list)
            {
                comboBox.Items.Add(s);
            }
            m_userEmail = userEmail;
            m_controller = controller;
        }

        /// <summary>
        /// When the user select the item from the combox list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m_selcet_field = comboBox.SelectedItem.ToString();
            button.IsEnabled = true;
        }

        /// <summary>
        /// When the user press ok then go to search in db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            listBox.Visibility = Visibility.Hidden;
            List<string> list = m_controller.GetRecommend(m_userEmail, m_selcet_field);
            if (list.Count == 0)
                MessageBox.Show("SORRY! \n no ads to shoe you for field: " + m_selcet_field);
            else
            {
                listBox.ItemsSource = list;
                listBox.Visibility = Visibility.Visible;
            }
        }
    }
}