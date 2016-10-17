using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bier.Model;
using Bier.DAO;

namespace Bier.Service
{
    public class InhoudService
    {
        InhoudDAO inhoudDAO;
        public List<Inhoud> GetPublicInhoud()
        {
            inhoudDAO = new InhoudDAO();
            return inhoudDAO.GetPublicInhoud();
        }

        public IEnumerable<Inhoud> GetInhoudPerUserId(String id)
        {
            return InhoudDAO.GetInhoudPerUserId(id);
        }
    }
}
