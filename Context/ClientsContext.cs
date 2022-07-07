using CrudClientAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudClientAPI.Context
{
    public class CrudClientContext : DbContext
    {
        public CrudClientContext(DbContextOptions<CrudClientContext> options) : base(options) 
        { 
            
        }

        public DbSet<Client> Client { get; set; }

    }
}
