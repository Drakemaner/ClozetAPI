using Microsoft.EntityFrameworkCore;
using Models;

namespace ClozetAPI.Banco
{
    public class BancoContext : DbContext
    {
        public DbSet<Roupa> Roupa { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public BancoContext(DbContextOptions options) : base(options)
        {

        }


        
    }

}
