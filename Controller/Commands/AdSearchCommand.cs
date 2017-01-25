using PartnerMatcher.Model;
using PartnerMatcher.View;
using System;

namespace PartnerMatcher.Controller.Commands
{
    internal class AdSearchCommand : ACommand
    {
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