using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Beer.DAO;
using Beer.Model;

namespace Beer.Service
{
    public class ItemService
    {
        ItemDAO itemDAO;
        public List<Item> GetAllItemsPerUser(string v)
        {
            itemDAO = new ItemDAO();
            return itemDAO.GetAllItemsPerUser(v);
        }
    }
}
