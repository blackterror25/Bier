using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Beer.DAO;
using Beer.Model;

namespace Beer.Service
{
    public class UserService
    {
        
        public static bool GetShowPublicLocatie(string id)
        {
            UserDAO userDAO = new UserDAO();
            return userDAO.GetShowPublicLocatie(id);
        }

        public static bool GetShowPublicInhoud(string id)
        {
            UserDAO userDAO = new UserDAO();
            return userDAO.GetShowPublicInhoud(id);
        }

        public static bool GetShowPublicBier(string id)
        {
            UserDAO userDAO = new UserDAO();
            return userDAO.GetShowPublicBier(id);
        }

        public static bool VeranderPublicSettings(string v, bool showPublicLocatie, bool showPublicInhoud, bool showPublicBier)
        {
            UserDAO userDAO = new UserDAO();
            return userDAO.VeranderPublicSettings(v, showPublicLocatie, showPublicInhoud, showPublicBier);
        }
    }
}
