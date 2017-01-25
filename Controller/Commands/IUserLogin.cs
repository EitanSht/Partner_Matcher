using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerMatcher.Controller.Commands
{
    interface IUserLogin : ICommand
    {
        bool CheckUserName(string email);
        bool CheckUserPass(string email, string pass);




    }
}
