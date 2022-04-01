using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WillFly.Model;

namespace WillFly.Data
{
    public class WillFlyContext : DbContext
    {
        public WillFlyContext (DbContextOptions<WillFlyContext> options)
            : base(options)
        {
        }

        public DbSet<WillFly.Model.Passageiro> Passageiro { get; set; }

        public DbSet<WillFly.Model.Aeronave> Aeronave { get; set; }

        public DbSet<WillFly.Model.Aeroporto> Aeroporto { get; set; }

        public DbSet<WillFly.Model.Voo> Voo { get; set; }
        public object Endereco { get; internal set; }
    }
}
