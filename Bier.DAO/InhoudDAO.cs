using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using Beer.Model;
using Beer.ExtensionMethods;

namespace Beer.DAO
{
    public class InhoudDAO
    {
        public List<Model.Inhoud> GetPublicInhoud()
        {
            using (var db = new BeerEntities())
            {
                return db.Inhoud.Where(i => i.AspNetUsersId == null).ToList();
            }
        }

        public static IEnumerable<Model.Inhoud> GetInhoudPerUserId(String id)
        {
            using (var db = new BeerEntities())
            {
                return db.Inhoud.Where(i => i.AspNetUsersId.Equals(id)).ToList();
            }
        }

        public static void VoegInhoudToe(Model.Inhoud inhoud)
        {
            using (var db = new BeerEntities())
            {
                db.Entry(inhoud).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public static void Update(Model.Inhoud inhoud)
        {
            using (var db = new BeerEntities())
            {
                db.Entry(inhoud).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static Model.Inhoud GetInhoudPerId(int id)
        {
            using (var db = new BeerEntities())
            {
                return db.Inhoud.Where(i => i.Id == id).First();
            }
        }
    }
}
