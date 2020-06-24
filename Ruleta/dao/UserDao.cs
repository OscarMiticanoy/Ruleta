using Ruleta.Model;
using Ruleta.contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Ruleta.dao
{
    public class UserDao
    {
        private Connection conn;
        private SqlCommand command;

        public UserDao()
        {
        }

        public bool create(User user)
        {
            string create = "insert into user(id_user,cash,bet,id_ruleta)values('" + user.id_user + "','" + user.cash + "','" + user.bet + "','" + user.id_ruleta + "')";
            try
            {
                command = new SqlCommand(create, conn.getCon());
                conn.getCon().Open();
                return command.ExecuteNonQuery()>0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.getCon().Close();
                conn.closeConnection();
            }
        }
    }
}
