using emprestimos_site.Models;
using Microsoft.EntityFrameworkCore;

namespace emprestimos_site.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {               
        }

        public DbSet<EmprestimoModel> Emprestimo { get; set; }
    }
}
