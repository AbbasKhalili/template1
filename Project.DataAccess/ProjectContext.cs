using Microsoft.EntityFrameworkCore;

namespace Project.DataAccess
{
    public class ProjectContext : DbContext
    {
        public DbSet<Domain.Project> Projects { get; set; }
        


        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}