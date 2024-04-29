using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TermProject.Models;

namespace TermProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TermProject.Models.Author> Author { get; set; } = default!;
        public DbSet<TermProject.Models.Book> Book { get; set; } = default!;
        public DbSet<TermProject.Models.BookPublisher> BookPublisher { get; set; } = default!;
        public DbSet<TermProject.Models.Customer> Customer { get; set; } = default!;
        public DbSet<TermProject.Models.OrderDetail> OrderDetail { get; set; } = default!;
        public DbSet<TermProject.Models.Genre> Genre { get; set; } = default!;
        public DbSet<TermProject.Models.Order> Order { get; set; } = default!;
        public DbSet<TermProject.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<TermProject.Models.Review> Review { get; set; } = default!;
    }
}
