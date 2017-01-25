using PartnerMatcher.Model;
using PartnerMatcher.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerMatcher.Controller.Commands
{
    class AdSearchCommand : ACommand
    {





        //private DataTable searchResultsByField(string fieldName);
        //private DataTable searchResultsByCriteria(string fieldName, params string[] criterias);



        public AdSearchCommand(IModel model, IView view) : base(model, view)
        {

        }
        public override string checkParams(string[] param)
        {
            throw new NotImplementedException();
        }

        public override bool DoCommand(params string[] parameters)
        {
            throw new NotImplementedException();
        }

        public override string GetName()
        {
            return "AdSearch";
        }
    }
}
