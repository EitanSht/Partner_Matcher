namespace PartnerMatcher.Controller.Commands
{
    internal interface IUserLogin : ICommand
    {
        bool CheckUserName(string email);

        bool CheckUserPass(string email, string pass);
    }
}