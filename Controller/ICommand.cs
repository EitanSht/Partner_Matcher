namespace PartnerMatcher.Controller
{
    /// <summary>
    /// This interface define two functions:
    /// 1. DoCommand - gets list of params commands from the user
    /// 2. GetName- return the name of the command
    /// </summary>
    interface ICommand
    {

        void DoCommand(params string[] parameters);

        string checkParams(string[] param);
        string GetName();

    }
}
