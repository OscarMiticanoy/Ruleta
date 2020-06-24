using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ruleta.Model
{
    public class User
    {
        [Key]
        public string id_user { get; set; }
        public int cash { get; set; }
        public int bet { get; set; }
        public int id_ruleta { get; set; }
        public User(string id_user, int cash, int bet, int id_ruleta)
        {
            this.id_user = id_user;
            this.cash = cash;
            this.bet = bet;
            this.id_ruleta = id_ruleta;
        }

        public User()
        {
        }
    }
}
