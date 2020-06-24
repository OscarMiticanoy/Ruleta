using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ruleta.Model
{
    public class Ruletas
    {
        [Key]
        public int id_ruleta { get; set; }
        public int state { get; set; }
        public int color { get; set; }
        public int number { get; set; }
        public Ruletas(int color, int number )
        {
            this.state = 0;
            this.color = color;
            this.number = number;
        }
        public Ruletas()
        {
        }
    }

}
