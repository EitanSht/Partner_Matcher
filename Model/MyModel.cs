using PartnerMatcher.Controller;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Data;

/// <summary>
/// This class implement Imodel interface
/// Notice: the maze name in the dictionary, saved in lower letters
/// </summary>
namespace PartnerMatcher.Model
{

    internal class MyModel : IModel
    {

        private OleDbConnection connection;

        private IController m_controller;


        public MyModel(IController cont)
        {

            m_controller = cont;

            connection = new OleDbConnection();
            connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=DataSource.accdb; Persist Security Info=False";



        }





        #region ADD USER
        public bool checkIfUserExists(string email)
        {
            bool ans;
            connection.Open();

            // create a command to check if the username exists
            OleDbCommand checkCommand = new OleDbCommand();
            checkCommand.Connection = connection;
            checkCommand.CommandText = "select count(*) from RegularUsers where Email='" + email + "'";
            ans = (int)checkCommand.ExecuteScalar() > 0;
            connection.Close();
            return ans;


        }



        public bool addNewUser(string email, string fname, string lname, string password, string gender, string bday, string phoneNumber, string address, string AuthPass)
        {
            try
            {

                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "insert into RegularUsers (FirstName,LastName,[Password],Gender,BirthDate,PhoneNumber,Address,AuthenticationPassword,Email) " +
                    "values ('" + fname + "','" + lname + "','" + password + "','" + gender + "'," +
                    "'" + bday + "','" + phoneNumber + "','" + address + "','" + AuthPass + "','" + email + "')";
                command.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch
            {
                connection.Close();
                m_controller.Output("Connection problem, try again later", "ERROR");
                return false;
            }
        }

        public void addUserCV(string path, string email)
        {

            if (File.Exists(path))
            {
                File.Copy(path, ".\\CV\\" + email + ".doc");
            }

        }

        #endregion




        public bool UserLogin(string userName, string password)
        {
            try
            {
                connection.Open();
                // create a command to check if the username exists
                bool found;
                OleDbCommand checkUserCommand = new OleDbCommand();
                OleDbCommand checkPassCommand = new OleDbCommand();
                checkUserCommand.Connection = connection;
                checkPassCommand.Connection = connection;
                //check is username exiata
                checkUserCommand.CommandText = "select count(*) from RegularUsers where Email='" + userName + "'";
                //check is password for user name xists
                checkPassCommand.CommandText = "select count(*) from RegularUsers where Email='" + userName + "' and [Password]='" + password + "'";
                found = (int)checkUserCommand.ExecuteScalar() != 0;


                if (!found)
                {
                    m_controller.Output("User Name Does Not Exists", "User Name Not Found");
                    return false;
                }
                else if ((int)checkPassCommand.ExecuteScalar() == 0)
                {
                    m_controller.Output("The password is incorrect", "Password Incorrect");
                    return false;
                }
                else // user connected
                {

                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                connection.Close();
                m_controller.Output("Connection problem, try again later", "ERROR");
                return false;
            }
        }



        /// <summary>
        /// an organized exit from program
        /// </summary>
        public void exit()
        {
            m_controller.Output("Initiating exit process, please wait for background process to end (; ");
            // foreach (Thread t in m_threads)
            //     t.Join();

            m_controller.Output("BYE BYE!!");


        }
        /// <summary>
        /// Return the fields that exsits in the db
        /// </summary>
        /// <returns> Return the fields that exsits in the db</returns>
        public List<string> getFields()
        {

            try
            {
                connection.Open();
                OleDbCommand cmd_fields = new OleDbCommand();
                cmd_fields.Connection = connection;
                cmd_fields.CommandText = "select * from Fields";

                OleDbDataReader reader = cmd_fields.ExecuteReader();
                List<string> fields = new List<string>();
                while (reader.Read())
                {
                    fields.Add(reader["FieldName"].ToString());
                }
                connection.Close();
                return fields;
            }
            catch (Exception ex)
            {
                connection.Close();
                m_controller.Output("Connection problem, try again later", "ERROR");
                return null;
            }
        }

        public Dictionary<Tuple<string, string>, string[]> GetCriteria()
        {
            try
            {
                connection.Open();
                OleDbCommand cmd_fields = new OleDbCommand();
                cmd_fields.Connection = connection;
                cmd_fields.CommandText = "select * from SubCriterias";

                OleDbDataReader reader = cmd_fields.ExecuteReader();
                Dictionary<Tuple<string, string>, string[]> criteriaDetails = new Dictionary<Tuple<string, string>, string[]>();
                while (reader.Read())
                {
                    string field = reader["Field"].ToString();
                    string criteria = reader["Criteria"].ToString();
                    string temp = reader["SubCriteria"].ToString();
                    string[] subCriterias = temp.Split(',');

                    criteriaDetails.Add(new Tuple<string, string>(field, criteria), subCriterias);
                }
                connection.Close();
                return criteriaDetails;
            }
            catch (Exception)
            {
                connection.Close();
                m_controller.Output("Connection problem, try again later", "ERROR");
                return null;
            }
        }
        /// <summary>
        /// This function retrive all the requests of specific user
        /// </summary>
        /// <param name="userId">the user id</param>
        /// <returns>List<string> of requested</returns>
        public List<string> AdRequests(string userMail)
        {
            List<string> request = new List<string>();
            try
            {
                connection.Open();
                OleDbCommand uID_fields = new OleDbCommand();
                OleDbCommand cmd_fields = new OleDbCommand();
                cmd_fields.Connection = connection;
                uID_fields.Connection = connection;
                uID_fields.CommandText = "select RegularUsers.ID from RegularUsers where RegularUsers.Email='" + userMail + "'";
                OleDbDataReader uID = uID_fields.ExecuteReader();
                if (uID.Read())
                    uID["ID"].ToString();

                cmd_fields.CommandText = "select UsersRequest.AdID,UsersRequest.Status from UsersRequest where (UsersRequest.UserID=" + uID["ID"].ToString() + ")";

                OleDbDataReader reader = cmd_fields.ExecuteReader();

                while (reader.Read())
                {
                    request.Add(reader["AdID"].ToString() + "  " + reader["Status"].ToString());
                }
                connection.Close();
                return request;

            }
            catch (Exception ex)
            {
                connection.Close();
                m_controller.Output("Connection problem, try again later", "ERROR");
                return null;
            }

        }

        /// <summary>
        /// Return the recommendList of user
        /// </summary>
        /// <param name="userMail">The user id</param>
        /// <returns>return list of relevan recomend from the db</returns>
        public List<string> AdRecommend(string userMail, string field)
        {
            List<string> recommend = new List<string>();
            try
            {
                connection.Open();


                OleDbCommand uID_fields = new OleDbCommand();
                uID_fields.Connection = connection;
                uID_fields.CommandText = "select RegularUsers.ID from RegularUsers where RegularUsers.Email='" + userMail + "'";
                OleDbDataReader uID = uID_fields.ExecuteReader();

                uID.Read();
                string uid = uID["ID"].ToString();

                OleDbCommand cmd_fields = new OleDbCommand();
                cmd_fields.Connection = connection;
                cmd_fields.CommandText = "select Ads.ID,Ads.Date_Published,Ads.Valid,Ads.FieldName,Ads.FreeDescription from (Ads inner join Recommend on Recommend.AdID = Ads.ID) where (  Recommend.Field='" + field + "'  and Recommend.UserId = " + uid + ")";


                OleDbDataReader reader = cmd_fields.ExecuteReader();
                while (reader.Read())
                {
                    recommend.Add(reader[0].ToString() + "  " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + "  " + reader[4].ToString());
                }

                connection.Close();
                return recommend;

            }
            catch (Exception ex)
            {
                connection.Close();
                m_controller.Output("Connection problem, try again later", "ERROR");
                return null;
            }
        }

        public DataTable getCriteriaSerachResults(string tblName, object[] critDat)
        {

            try
            {

                connection = new OleDbConnection();
                connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=DataSource.accdb; Persist Security Info=False";
                connection.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;

                cmd.CommandText = "select RegularUsers.FirstName,RegularUsers.LastName,Ads.ID," + tblName + ".* from (( Ads inner join " + tblName + " on Ads.ID = " + tblName + ".AdID) inner join UserPubAd on Ads.ID = UserPubAd.AdID) inner join RegularUsers on RegularUsers.ID = UserPubAd.UserID where ((" + tblName + "." + critDat[0] + " = '" + critDat[4] + "' and " + tblName + "." + critDat[1] + " = '" + critDat[5] + "') or (" + tblName + "." + critDat[0] + " = '" + critDat[4] + "' and " + tblName + "." + critDat[2] + " = '" + critDat[6] + "') or (" + tblName + "." + critDat[0] + " = '" + critDat[4] + "' and " + tblName + "." + critDat[3] + " = '" + critDat[7] + "') or (" + tblName + "." + critDat[1] + " = '" + critDat[5] + "' and " + tblName + "." + critDat[2] + " = '" + critDat[6] + "') or (" + tblName + "." + critDat[1] + " = '" + critDat[5] + "' and " + tblName + "." + critDat[3] + " = '" + critDat[7] + "') or (" + tblName + "." + critDat[2] + " = '" + critDat[6] + "' and " + tblName + "." + critDat[3] + " = '" + critDat[7] + "'))";


                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                connection.Close();
                return dt;
            }
            catch (Exception e)
            {
                connection.Close();

                m_controller.Output("Connection ERROR  :/ \n Please try again later");
            }

            return null;

        }

        public DataTable AdSearch(string field)
        {
            try
            {

                connection.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;


                string tblName = field + "AdDetails";
                cmd.CommandText = "select RegularUsers.FirstName,RegularUsers.LastName,Ads.ID," + tblName + ".* from (( Ads inner join " + tblName + " on Ads.ID = " + tblName + ".AdID) inner join UserPubAd on Ads.ID = UserPubAd.AdID) inner join RegularUsers on RegularUsers.ID = UserPubAd.UserID";

                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                da.Fill(dt);
                connection.Close();

                return dt;
            }
            catch (Exception e)
            {
                connection.Close();

                m_controller.Output("Connection ERROR  :/ \n Please try again later");
            }

            return null;

        }
    }
}













