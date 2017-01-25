using PartnerMatcher.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PartnerMatcher.Controller.Commands;

namespace PartnerMatcher.View
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        Dictionary<string, Controller.ICommand> m_CommandDic = new Dictionary<string, Controller.ICommand>();
        MyController m_controller;
        string m_userId = "";

        public Menu(Dictionary<string, Controller.ICommand> CommandDic, MyController controller, string userId)
        {
            InitializeComponent();
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

            List<string> requests = m_controller.GetRequest(m_userId);
            Results r = new Results(requests);


        }

        /// <summary>
        /// Recommend list s
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecommendList_Click(object sender, RoutedEventArgs e)
        {
            List<string> field = m_controller.getFields();
            Recommend rc = new Recommend(field, m_userId, m_controller);
            rc.ShowDialog();
        }

        private void CSearch_Click(object sender, RoutedEventArgs e)
        {

            CriteriaSearchWindow search = new CriteriaSearchWindow(m_userId, m_controller.getFields(), m_controller.GetCriteria(), m_controller);
            search.ShowDialog();
        }

        private void GSearch_Click(object sender, RoutedEventArgs e)
        {
            List<string> field = m_controller.getFields();
            SearchWindow genSer = new SearchWindow(m_controller, m_controller.getFields());
            genSer.ShowDialog();

        }
    }
}
