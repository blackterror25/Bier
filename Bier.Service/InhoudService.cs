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

        public void VoegInhoudToe(Inhoud inhoud)
        {
            InhoudDAO.VoegInhoudToe(inhoud);
        }

        public Inhoud GetInhoudPerId(int v)
        {
            return InhoudDAO.GetInhoudPerId(v);
        }

        public void Update(Inhoud inhoud)
        {
            InhoudDAO.Update(inhoud);
        }
    }
}
