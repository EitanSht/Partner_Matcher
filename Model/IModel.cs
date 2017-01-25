using PartnerMatcher.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/// <summary>
///
/// </summary>

namespace PartnerMatcher.Model
{
    public interface IModel
    {



        bool checkIfUserExists(string email);
        bool addNewUser(string email, string fname, string lname, string password, string gender, string bday, string phoneNumber, string address, string AuthPass);
        void addUserCV(string path, string email);
        bool UserLogin(string userName, string password);
        List<string> AdRequests(string userId);
        List<string> AdRecommend(string userId, string field);
        //put methods names
        void exit();
        List<string> getFields();
        DataTable AdSearch(string field);
        Dictionary<Tuple<string, string>, string[]> GetCriteria();
        DataTable getCriteriaSerachResults(string tblName, object[] critDat);

    }
}
