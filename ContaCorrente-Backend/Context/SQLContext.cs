using ContaCorrente_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ContaCorrente_Backend.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

        public DbSet<ContaCorrente> ContaCorrente { get; private set; }
    }
}
