using Data.Mapping;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexto
{
    public class DBContexto : DbContext
    {
        public DBContexto(DbContextOptions<DBContexto> options) : base(options) 
        {
            Database.Migrate();
        }

        public DbSet<AnelEntidade> Anel {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AnelEntidade>(new AnelMap().Configure);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer("Data Source=ALEX_122024\\SQLEXPRESS;Initial Catalog=ANEL_TESTE;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
    }
}
