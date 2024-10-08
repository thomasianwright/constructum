using Constructum.Server.Entities;
using Constructum.Server.Organisations.Entities;
using Microsoft.EntityFrameworkCore;

namespace Constructum.Server;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Organisation> Organisations => Set<Organisation>();
}