using Microsoft.Data.SqlClient;
using Ruleta.contexts;
using Ruleta.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ruleta.dao
{
    public class RuletasDAO
    {
        private Connection conn;
        private SqlCommand command;

        public RuletasDAO()
        {
        }

        public int createRuleta(Ruletas ruleta)
        {
            var number = Enumerable.Range(0, 30);
            var color = Enumerable.Range(0, 1);
            try
            {
                command = new SqlCommand("dbo.insertRuleta", conn.getCon());
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", SqlDbType.Int);
                SqlParameter paramState = new SqlParameter("@state", SqlDbType.Int);
                SqlParameter paramNumber = new SqlParameter("@number", SqlDbType.Int);
                SqlParameter paramColor = new SqlParameter("@color", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramId);
                paramState.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramState);
                paramNumber.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramNumber);
                paramColor.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramColor);
                command.Parameters.AddWithValue("state", 0);
                command.Parameters.AddWithValue("number", number);
                command.Parameters.AddWithValue("color", color);
                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.closeConnection();
            }
        }
        public bool activateRuleta(int id)
        {
            bool isHere;
            string sql = "SELECT * FROM Ruletas WHERE id_ruleta=" + id;
            string sql2 = "UPDATE Ruletas SET state=1 WHERE id_ruleta=" + id;
            try
            {
                command = new SqlCommand(sql, conn.getCon());
                conn.getCon().Open();
                isHere = command.ExecuteNonQuery() > 0;
                if (isHere)
                {
                    command = new SqlCommand(sql2, conn.getCon());
                    command.ExecuteNonQuery();
                }
                return isHere;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.closeConnection();
            }
        }
        public void setBet(string id, int bet)
        {
            string sql = "SELECT cash, SUM(bet), id_ruleta FROM users WHERE id_user = " + id;
            try
            {
                command = new SqlCommand(sql, conn.getCon());
                conn.getCon().Open();
                SqlDataReader read = command.ExecuteReader();
                read.Read();
                
                User bettor = new User();
                bettor.cash = Convert.ToInt32(read[1].ToString());
                bettor.bet = Convert.ToInt32(read[2].ToString());
                bettor.id_ruleta = Convert.ToInt32(read[3].ToString());

                string sql2 = "insert into user(id_user,cash,bet,id_ruleta)values('" + id + "','" + bettor.cash + "','" + bettor.bet + "','" + bettor.id_ruleta + "')";
                if (bettor.cash>bettor.bet)
                {
                    command = new SqlCommand(sql2, conn.getCon());
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.closeConnection();
            }
        }
        public List<User> CloseBetList(int id)
        {
            List<User> bets = new List<User>();

            string findAll = "SELECT u.id_user,u.cash, u.bet FROM user WHERE user.id_user = "+id;
            string sql2 = "UPDATE Ruletas SET state=O WHERE id_ruleta=" + id;
            try
            {
                command = new SqlCommand(findAll, conn.getCon());
                conn.getCon().Open();
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    User bettor = new User();
                    bettor.cash = Convert.ToInt32(read[1].ToString());
                    bettor.bet = Convert.ToInt32(read[2].ToString());
                    bets.Add(bettor);
                }
                command = new SqlCommand(sql2, conn.getCon());
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.closeConnection();
            }
            return bets;
        }
        public List<Ruletas> ruletasList()
        {
            List<Ruletas> ruletasList = new List<Ruletas>();

            string findAll = "SELECT * FROM ruletas";

            try
            {
                command = new SqlCommand(findAll, conn.getCon());
                conn.getCon().Open();
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    Ruletas ruleta = new Ruletas();
                    ruleta.id_ruleta = Convert.ToInt32(read[10.ToString()]);
                    ruleta.state = Convert.ToInt32(read[1].ToString());
                    ruleta.number = Convert.ToInt32(read[2].ToString());
                    ruleta.color = Convert.ToInt32(read[2].ToString());
                    ruletasList.Add(ruleta);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.closeConnection();
            }
            return ruletasList;
        }
    }
}
