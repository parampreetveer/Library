using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Model;

namespace RepositoryLayer
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<BookDetails> BookDetails { get; set; }
        public  DbSet<PersonDetails> PersonDetails { get; set; }
       public DbSet<PersoBooks> PersoBooks { get; set; }
        

      
    }
}
