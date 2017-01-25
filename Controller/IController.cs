using PartnerMatcher.Model;
using PartnerMatcher.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// This interface define the follow method:
/// 1. setModel - assign the relevant model for the controller
/// 2. setView - assign the relevant view for the controller.
/// 3. GetCommands - return the command dictionary
/// 4. Output -this function indicate change in the model

/// </summary>
namespace PartnerMatcher.Controller
{
    public interface IController
    {
        void SetModel(IModel model);
        void SetView(IView view);
        Dictionary<string, ICommand> GetCommands();
        void Output(params string[] output);
        List<string> getFields();
        Dictionary<Tuple<string, string>, string[]> GetCriteria();
        List<string> GetRequest(string userid); // get the user requests
        List<string> GetRecommend(string userid, string field);// get the recommend

    }
}
