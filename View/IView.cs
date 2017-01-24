using PartnerMatcher.Controller;

namespace PartnerMatcher.View
{
    interface IView
    {

        void Start();
        void Output(params string[] output);
        void setcontroller(IController controller);
        void GetCommands();
    }
}
