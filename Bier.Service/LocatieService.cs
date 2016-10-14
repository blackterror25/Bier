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

        public IEnumerable<Locatie> getAllLocationsPerUser(string userId)
        {
            return locatieDAO.getAllLocationsPerUser(userId);
        }
    }
}
