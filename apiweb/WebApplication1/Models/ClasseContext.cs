using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ClasseContext:DbContext
    {
        public ClasseContext(DbContextOptions<ClasseContext> options)  : base(options)
        {

        }

        public DbSet<Groupe> groupe { get; set; } = null!;
        public DbSet<Promotion> promotion { get; set; } = null!;
        public DbSet<Eleve> eleve { get; set; } = null!;
        public DbSet<Presence> presence { get; set; } = null!;
    }
}
