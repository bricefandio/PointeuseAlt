using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ClasseContext:DbContext
    {
        public ClasseContext(DbContextOptions<ClasseContext> options)  : base(options)
        {

        }

        public DbSet<Administrateur> administrateur { get; set; } = null!;
        public DbSet<Coordinateur> coordinateur { get; set; } = null!;
        public DbSet<Eleve> eleve { get; set; } = null!;
        public DbSet<Presence> presence { get; set; } = null!;
    }
}
