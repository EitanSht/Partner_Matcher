using PartnerMatcher.Controller;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

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
        }


        public void UserLogin(string userName, string password)
        {

            // create a command to check if the username exists
            bool found;
            OleDbCommand checkUserCommand = new OleDbCommand();
            OleDbCommand checkPassCommand = new OleDbCommand();
            checkUserCommand.Connection = connection;
            checkPassCommand.Connection = connection;
            checkUserCommand.CommandText = "select count(*) from RegularUsers where Email='" + userName + "'";
            checkPassCommand.CommandText = "select count(*) from RegularUsers where Email='" + userName + "' and [Password]='" + password + "'";
            found = (int)checkUserCommand.ExecuteScalar() == 0;
            if (!found)
                m_controller.Output("User Name Does Not Exists", "User Name Not Found");
            else if ((int)checkPassCommand.ExecuteScalar() == 0)
            {
                MessageBox.Show("The password is incorrect", "Password Incorrect");
            }
            else // user connected
            {
                SearchWindow searchWindow = new SearchWindow(userName_txt.Text);
                this.Hide();
                searchWindow.ShowDialog();
            }
            connection.Close();
        }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: \n" + ex.ToString(), "Error Message");
                    connection.Close();
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











    }
}
