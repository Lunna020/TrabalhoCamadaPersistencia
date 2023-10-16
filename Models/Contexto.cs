using Microsoft.EntityFrameworkCore;

namespace TrabalhoCamadaPersistencia.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Especie> Especies { get; set; }

        public DbSet<Racas1> Racas { get; set; }
    
        public DbSet<Tutor> Tutores { get; set; }
        
        public DbSet<Precomercado> Precosmercado { get; set;}
    }

}
