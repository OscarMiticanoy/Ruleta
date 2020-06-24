using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ruleta.Model;

namespace Ruleta.contexts
{
    public class ContexConn : DbContext
    {
        public ContexConn(DbContextOptions<ContexConn> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ruletas> Ruletas { get; set; }
    }
}
