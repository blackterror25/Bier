using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bier.Model;

namespace Bier.DAO
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
    }
}
