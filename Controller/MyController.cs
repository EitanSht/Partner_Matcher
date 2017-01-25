using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartnerMatcher.Model;
using PartnerMatcher.View;
using PartnerMatcher.Controller.Commands;
using System.Data;

namespace PartnerMatcher.Controller
{
    public class MyController : IController
    {
        private IModel m_model;
        private IView m_view;
        private Dictionary<string, ICommand> dic_command;

        public MyController()
        {
            dic_command = new Dictionary<string, ICommand>();
        }




        /// <summary>
        /// Set model to the controller
        /// </summary>
        /// <param name="model">model to assign</param>
        public void SetModel(IModel model)
        {
            m_model = model;
        }

        /// <summary>
        /// Set view to the controller, set the view commands dictionary
        /// </summary>
        /// <param name="view"> view to assign</param>
        public void SetView(IView view)
        {
            m_view = view;
        }

        public DataTable AdSearch(string field)
        {
            return m_model.AdSearch(field);
        }



        /// <summary>
        /// Return the commands dictionary
        /// </summary>
        /// <returns>commands dictionary</returns>
        public Dictionary<string, ICommand> GetCommands()
        {
            #region commandsDeclaration
            AddUserCommand addUs = new AddUserCommand(m_model, m_view);
            UserLoginCommand logUs = new UserLoginCommand(m_model, m_view);
            AdSearchCommand searchAd = new AdSearchCommand(m_model, m_view);

            #endregion

            #region commandDicAddition
            dic_command.Add(addUs.GetName(), addUs);
            dic_command.Add(logUs.GetName(), logUs);
            dic_command.Add(searchAd.GetName(), searchAd);

            //  dic_command.Add(exit.GetName(), exit);
            #endregion

            return dic_command;
        }




        /// <summary>
        /// Call to the view, following a change in the model
        /// </summary>
        /// <param name="s"> this is the change in the model</param>
        void IController.Output(params string[] s)
        {
            m_view.Output(s);
        }

        public List<string> getFields()
        {
            return m_model.getFields();
        }

        public Dictionary<Tuple<string, string>, string[]> GetCriteria()
        {
            return m_model.GetCriteria();
        }

        public List<string> GetRecommend(string userid, string field)
        {
            return m_model.AdRecommend(userid, field);
        }


        public List<string> GetRequest(string userid)
        {
            return m_model.AdRequests(userid);
        }

        public DataTable getCriteriaSerachResults(string tblName, object[] critDat)
        {
            return m_model.getCriteriaSerachResults(tblName, critDat);
        }
    }
}
