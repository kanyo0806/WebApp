using System.Data.Entity;


namespace WebApplication.Models
{
    public class DetailsContext : DbContext
    {
        public DetailsContext() : base("WebApplicationDB")
        {
            
        }
        public DbSet<Details> Detail { get; set; }
        
    }
}