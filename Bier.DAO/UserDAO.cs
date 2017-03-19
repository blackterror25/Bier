using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Beer.Model;
using System.Data.Entity;

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

        public bool UpdateUser(AspNetUsers user)
        {
            using (var db = new BeerEntities())
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
        }

        public AspNetUsers GetUserById(string id)
        {
            using (var db = new BeerEntities())
            {
                return db.AspNetUsers.Where(u => u.Id == id).First();
            }
        }
    }
}
