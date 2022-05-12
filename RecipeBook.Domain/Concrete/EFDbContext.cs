using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeBook.Domain.Entities;
using System.Data.Entity;

namespace RecipeBook.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}
