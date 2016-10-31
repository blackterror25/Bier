using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Beer.Model;





namespace Beer.DAO
{
    public class LocatieDAO
    {
        public IEnumerable<Locatie> getAllLocationsPerUser(string userId)
        {
            using (var db = new BeerEntities())
            {
                return db.Locatie.Where(l => l.AspNetUsersId == userId).ToList();
            }
        }

        public void VoegLocatieToe(Locatie locatie)
        {
            using (var db = new BeerEntities())
            {
                db.Entry(locatie).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public Locatie GetLocatiePerId(int id)
        {
            using (var db = new BeerEntities())
            {
                return db.Locatie.Where(l => l.Id == id).First();
            }
        }

        public void RemoveLocatie(int? id)
        {
            using (var db = new BeerEntities())
            {
                var locatie = db.Locatie.Where(l => l.Id == id).First();
                db.Locatie.Remove(locatie);
                db.SaveChanges();
            }
        }

        public List<Locatie> GetPublicLocatie()
        {
            using (var db = new BeerEntities())
            {
                return db.Locatie.Where(l => l.AspNetUsersId == null).ToList();
            }
        }

        public void Update(Locatie locatie)
        {
            using (var db = new BeerEntities())
            {
                db.Entry(locatie).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
