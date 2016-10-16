using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bier.Model;
using Bier.DAO;

namespace Bier.Service
{
    public class LocatieService
    {
        private LocatieDAO locatieDAO;

        public LocatieService()
        {
            locatieDAO = new LocatieDAO();
        }

        public IEnumerable<Locatie> GetAllLocationsPerUser(string userId)
        {
            return locatieDAO.getAllLocationsPerUser(userId);
        }

        public void VoegLocatieToe(Locatie locatie)
        {
            locatieDAO.VoegLocatieToe(locatie);
        }

        public Locatie GetLocatiePerId(int id)
        {
            return locatieDAO.GetLocatiePerId(id);
        }

        public void Update(Locatie locatie)
        {
            locatieDAO.Update(locatie);
        }
    }
}
