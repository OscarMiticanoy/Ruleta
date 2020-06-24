using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Ruleta.contexts
{
    public class Connection
    {
        private SqlConnection con;

        private Connection()
        {
            con = new SqlConnection("Data Source=.; Initial catalog=DESKTOP-MQBAK55; Integrated Security=true");
        }
                
        public SqlConnection getCon()
        {
            return con;
        }

        public void closeConnection()
        {
            con.Close();
        }

    }
}
