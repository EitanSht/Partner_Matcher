using PartnerMatcher.Model;
using PartnerMatcher.View;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerMatcher.Controller
{
    class AddUserCommand : ACommand
    {
        private OleDbConnection connection;

        #region model methods
        public AddUserCommand(IModel model, IView view) : base(model, view)
        {

        }

        public bool addNewUser(string email, string fname, string lname, string password, string gender, string bday, string phoneNumber, string address, string AuthPass)
        {
            return m_model.addNewUser(email, fname, lname, password, gender, bday, phoneNumber, address, AuthPass);
        }



        public void addUserCV(string path, string email)
        {
            try
            {
                m_model.addUserCV(path, email);

            }
            catch
            {
                m_view.Output("There was problem to upload your CV please contact out customer service : 1-800-harta");
            }
        }


        /// <summary>
        /// check if user name exits on data base
        /// </summary>
        /// <param name="email">the user name email - ID</param>
        /// <returns>true if exists</returns>
        public bool checkIfUserExists(string email)
        {


            if (m_model.checkIfUserExists(email))
            {
                m_view.Output("User Name Already Exists", "Duplication Error");

                return false;
            }
            return true;

        }


        public override bool DoCommand(params string[] parameters)
        {
            if (checkIfUserExists(parameters[0]))
            {

                string pass = "";

                pass = GenerateRandomPass();
                //add new user
                if (!addNewUser(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5], parameters[6], parameters[7], pass))
                    return false;
                //add user cv if exists
                if (parameters[8] != "")
                    addUserCV(parameters[8], parameters[0]);
                //create random authentication pass for user

                m_view.Output("New user added \n You authentication password for actions on site  is : " + pass + "\n PLEASE WRITE IT DOWN FOR FUTURE USE", "Submitted Successfully");


                return true;

            }

            else
                return false;
        }






        public override string checkParams(string[] param)
        {
            throw new NotImplementedException();
        }

        public override string GetName()
        {
            return "AddUser";
        }
        #endregion



        #region controller implementes


        private static string GenerateRandomPass()
        {
            int length = 6;
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }




        #endregion
    }
}
