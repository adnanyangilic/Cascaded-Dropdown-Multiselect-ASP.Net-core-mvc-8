using CountriesDB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CountriesDB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public  DbSet<City> Cities { get; set; }

        public  DbSet<Country> Countries { get; set; }

        public  DbSet<State> States { get; set; }

       

           
        

     

    }
}
