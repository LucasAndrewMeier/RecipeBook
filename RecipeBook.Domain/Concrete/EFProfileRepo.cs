using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeBook.Domain.Abstract;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Domain.Concrete
{
    public class EFProfileRepo : IProfileRepo
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Profile> Profiles
        {
            get { return context.Profiles; }
        }
        public void SaveProfile(Profile profile)
        {
            if (profile.ProfileID == 0)
            {
                context.Profiles.Add(profile);
            }
            else
            {
                Profile dbEntry = context.Profiles.Find(profile.ProfileID);
                if (dbEntry != null)
                {
                    dbEntry.FirstName = profile.FirstName;
                    dbEntry.LastName = profile.LastName;
                    dbEntry.Email = profile.Email;
                    dbEntry.Password = profile.Password;
                }
            }
            context.SaveChanges();
        }
        public Profile DeleteProfile(int profileID)
        {
            Profile dbEntry = context.Profiles.Find(profileID);
            if(dbEntry != null)
            {
                context.Profiles.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
      
    }
}
