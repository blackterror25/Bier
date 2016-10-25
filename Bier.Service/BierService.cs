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
        BierDAO bierDAO;

        public List<Bier> GetPublicBier()
        {
            return BierDAO.GetPublicBier();
        }

        public List<Bier> GetBierPerUserId(string v)
        {
            return BierDAO.GetBierPerUserId(v);
        }

        public Bier GetBierPerId(int? id)
        {
            return BierDAO.GetBierPerId(id);
        }

        public void BierToevoegen(Bier bier)
        {
            bierDAO = new BierDAO();

            bierDAO.BierToevoegen(bier);
        }
    }
}
