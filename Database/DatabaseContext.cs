using API_Tradingcenter.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Tradingcenter.Database
{
    public class DatabaseContext : DbContext
    {
       public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){} 

       public DbSet<Value> Value {get; set;}
    }
}