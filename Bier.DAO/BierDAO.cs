using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beer.Model;

namespace Beer.DAO
{
    public class BierDAO
    {
        public static List<Bier> GetPublicBier()
        {
            using (var db = new BeerEntities())
            {
                return db.Bier.Where(b => b.AspNetUsersId == null).ToList();
            }
        }

        public static List<Bier> GetBierPerUserId(string v)
        {
            using (var db = new BeerEntities())
            {
                return db.Bier.Where(b => b.AspNetUsersId == v).ToList();
            }
        }

        public static Bier GetBierPerId(int? id)
        {
            using (var db = new BeerEntities())
            {
                return db.Bier.Where(b => b.Id == id).First();
            }
        }
    }
}
