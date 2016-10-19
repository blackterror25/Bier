using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Beer.Model;
using Beer.DAO;

namespace Beer.Service
{
    public class BierService
    {
        Bier bier;

        public List<Bier> GetPublicBier()
        {
            return BierDAO.GetPublicBier();
        }

        public List<Bier> GetBierPerUserId(string v)
        {
            return BierDAO.GetBierPerUserId(v);
        }
    }
}
