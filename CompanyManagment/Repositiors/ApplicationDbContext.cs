using CompanyManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.Repositiors
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
		{

		}
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Department>()
				.HasMany(d => d.Employees)
				.WithOne(e => e.Department!)
				.HasForeignKey(e => e.DepartmentId)
				.OnDelete(DeleteBehavior.Cascade); // if delete department delete employees 
		}
	}
}
