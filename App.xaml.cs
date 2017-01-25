using PartnerMatcher.Controller;
using PartnerMatcher.Model;
using PartnerMatcher.View;
using System.Windows;

namespace PartnerMatcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IController c = new MyController();
            IModel m = new MyModel(c);
            IView v = new MainWindow(c);

            c.SetView(v);
            c.SetModel(m);
            Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            Current.MainWindow = (MainWindow)v;
            v.Start();

        }
    }
}