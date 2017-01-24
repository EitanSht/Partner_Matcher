using PartnerMatcher.Model;
using PartnerMatcher.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerMatcher.Controller
{
    class AddUser : ACommand
    {

        public AddUser(IModel model, IView view) : base(model, view)
        {

        }

        public override string checkParams(string[] param)
        {
            throw new NotImplementedException();
        }

        public override void DoCommand(params string[] parameters)
        {
            throw new NotImplementedException();
        }

        public override string GetName()
        {
            return "AddUser";
        }
    }
}
