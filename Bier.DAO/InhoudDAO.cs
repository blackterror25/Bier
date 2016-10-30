using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using Beer.Model;

namespace Beer.DAO
{
    public class InhoudDAO
    {
        public List<Inhoud> GetPublicInhoud()
        {
            using (var db = new BeerEntities())
            {
                return db.Inhoud.Where(i => i.AspNetUsersId == null).ToList();
            }
        }

        public static IEnumerable<Inhoud> GetInhoudPerUserId(String id)
        {
            using (var db = new BeerEntities())
            {
                return db.Inhoud.Where(i => i.AspNetUsersId.Equals(id)).ToList();
            }
        }

        public static void VoegInhoudToe(Inhoud inhoud)
        {
            using (var db = new BeerEntities())
            {
                db.Entry(inhoud).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public static void Update(Inhoud inhoud)
        {
            using (var db = new BeerEntities())
            {
                db.Entry(inhoud).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static Inhoud GetInhoudPerId(int id)
        {
            using (var db = new BeerEntities())
            {
                return db.Inhoud.Where(i => i.Id == id).First();
            }
        }
    }
}
