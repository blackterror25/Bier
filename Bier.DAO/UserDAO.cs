using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Beer.Model;

namespace Beer.DAO
{
    public class UserDAO
    {
        public bool GetShowPublicLocatie(string id)
        {
            using (var db = new BeerEntities())
            {
                return db.AspNetUsers.Where(u => u.Id == id).First().ShowPublicLocatie;
            }
        }

        public bool GetShowPublicInhoud(string id)
        {
            using (var db = new BeerEntities())
            {
                return db.AspNetUsers.Where(u => u.Id == id).First().ShowPublicInhoud;
            }
        }

        public bool GetShowPublicBier(string id)
        {
            using (var db = new BeerEntities())
            {
                return db.AspNetUsers.Where(u => u.Id == id).First().ShowPublicBier;
            }
        }

        public bool VeranderPublicSettings(string id,bool showPublicLocatie,  bool showPublicInhoud, bool showPublicBier)
        {
            using (var db = new BeerEntities())
            {
                var user = new AspNetUsers() { ShowPublicLocatie = showPublicLocatie, ShowPublicInhoud = showPublicInhoud, ShowPublicBier = showPublicBier };
                db.AspNetUsers.Attach(user);
                db.Entry(user).Property(u => u.ShowPublicLocatie).IsModified = true;
                db.Entry(user).Property(u => u.ShowPublicInhoud).IsModified = true;
                db.Entry(user).Property(u => u.ShowPublicBier).IsModified = true;

                db.SaveChanges();

                return true;
            }
        }
    }
}
