using Microsoft.EntityFrameworkCore;
using AspNetMinimalApiTemplate.Models;

namespace AspNetMinimalApiTemplate.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Post> Posts { get; set; }
}

