using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bier.Model;





namespace Bier.DAO
{
    public class LocatieDAO
    {
        public IEnumerable<Locatie> getAllLocationsPerUser(string userId)
        {
            using (var db = new beerEntities())
            {
                return db.Locatie.Where(l => l.AspNetUsersId == userId).ToList();
            }
        }
    }
}
