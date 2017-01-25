using PartnerMatcher.Controller;

namespace PartnerMatcher.View
{
    public interface IView
    {
        void Start();

        void Output(params string[] output);

        void SetController(IController controller);

        void setCurUser(string user);
    }
}