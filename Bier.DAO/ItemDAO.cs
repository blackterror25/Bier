using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using Beer.Model;

namespace Beer.DAO
{
    public class ItemDAO
    {
        public List<Item> GetAllItemsPerUser(string v)
        {
            using (var db = new BeerEntities())
            {
                List<Item> il = db.Item.Include(i => i.Bier).Where(i => i.AspNetUsersId.Equals(v)).ToList();
                return il;
            }
        }
    }
}
