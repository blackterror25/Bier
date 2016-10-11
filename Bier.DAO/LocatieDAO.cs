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
        public IEnumerable<locatie> getAllLocationsPerUser(string userId)
        {
            using (var db = new beerEntities())
            {
                //return db.Departments.SqlQuery(query, id).SingleOrDefaultAsync();
                //return (IEnumerable<locatie>) db.bier.SqlQuery("SELECT * FROM LOCATIES WHERE AspNetUsersId = ?", userId).ToList();
            }
        }
    }
}
