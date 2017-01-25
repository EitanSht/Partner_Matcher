using PartnerMatcher.Model;
using PartnerMatcher.View;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerMatcher.Controller.Commands
{
    class UserLoginCommand : ACommand
    {
        private OleDbConnection connection;


        public UserLoginCommand(IModel model, IView view) : base(model, view)
        {

        }




        public override string checkParams(string[] param)
        {
            throw new NotImplementedException();
        }

        public override bool DoCommand(params string[] parameters)
        {
            if (CheckIfUserExists(parameters[0], parameters[1]))
            {
                m_view.setCurUser(parameters[0]);
                return true;


            }
            else
                return false;
        }

        private bool CheckIfUserExists(string uName, string pass)
        {
            return m_model.UserLogin(uName, pass);



        }

        public override string GetName()
        {
            return "UserLogin";
        }
    }
}
