using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Beer.Model;
using System.Data.Entity;

namespace Beer.DAO
{
    public class BierDAO
    {
        public static List<Bier> GetPublicBier()
        {
            using (var db = new BeerEntities())
            {
                return db.Bier.Include(b => b.Inhoud).Where(b => b.AspNetUsersId == null).ToList();
            }
        }

        public static List<Bier> GetBierPerUserId(string v)
        {
            using (var db = new BeerEntities())
            {
                return db.Bier.Include(b => b.Inhoud).Where(b => b.AspNetUsersId == v).ToList();
            }
        }

        public static Bier GetBierPerId(int? id)
        {
            using (var db = new BeerEntities())
            {
                return db.Bier.Where(b => b.Id == id).First();
            }
        }

        public void BierUpdaten(Bier bier)
        {
            using (var db = new BeerEntities())
            {
                db.Entry(bier).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void BierToevoegen(Bier bier)
        {
            using (var db = new BeerEntities())
            {
                db.Bier.Add(bier);
                db.SaveChanges();
            }
        }
    }
}
