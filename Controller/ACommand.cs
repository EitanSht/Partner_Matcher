using PartnerMatcher.Model;
using PartnerMatcher.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PartnerMatcher.Controller
{
    abstract class ACommand : ICommand
    {

        protected IModel m_model;
        protected IView m_view;


        public ACommand(IModel model, IView view)
        {
            m_model = model;
            m_view = view;
        }

        /// <summary>
        /// checks if the given params are leggal and satisfied the command
        /// </summary>
        /// <param name="param">params to be check</param>
        /// <returns>true if satsified false if not </returns>
        public abstract string checkParams(string[] param);//check the params recieved in Do command
        public abstract void DoCommand(params string[] parameters);
        public abstract string GetName();
    }
}
