using PartnerMatcher.Controller;
using System.Collections.Generic;
using System.Windows;

namespace PartnerMatcher.View
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private Dictionary<string, Controller.ICommand> m_CommandDic = new Dictionary<string, Controller.ICommand>();
        private MyController m_controller;
        private string m_userId = "";

        public Menu(Dictionary<string, Controller.ICommand> CommandDic, MyController controller, string userId)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            m_CommandDic = CommandDic;
            m_controller = controller;
            m_userId = userId;
        }

        /// <summary>
        /// Handle the Request button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdRequests_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            List<string> requests = m_controller.GetRequest(m_userId);
            Results r = new Results(requests);
            this.ShowDialog();
        }

        /// <summary>
        /// Recommend list s
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecommendList_Click(object sender, RoutedEventArgs e)
        {
            List<string> field = m_controller.getFields();
            this.Hide();
            Recommend rc = new Recommend(field, m_userId, m_controller);
            rc.ShowDialog();
            this.ShowDialog();
        }

        private void CSearch_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CriteriaSearchWindow search = new CriteriaSearchWindow(m_userId, m_controller.getFields(), m_controller.GetCriteria(), m_controller);
            search.ShowDialog();
            this.ShowDialog();
        }

        private void GSearch_Click(object sender, RoutedEventArgs e)
        {
            List<string> field = m_controller.getFields();
            this.Hide();
            SearchWindow genSer = new SearchWindow(m_controller, m_controller.getFields());
            genSer.ShowDialog();
            this.ShowDialog();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}