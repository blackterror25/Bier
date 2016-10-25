using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Beer.Model;
using Beer.ExtensionMethods;
using Beer.DAO;

namespace Beer.Service
{
    public class InhoudService
    {
        InhoudDAO inhoudDAO;
        public List<Model.Inhoud> GetPublicInhoud()
        {
            inhoudDAO = new InhoudDAO();
            return inhoudDAO.GetPublicInhoud();
        }

        public IEnumerable<Model.Inhoud> GetInhoudPerUserId(String id)
        {
            return InhoudDAO.GetInhoudPerUserId(id);
        }

        public void VoegInhoudToe(Model.Inhoud inhoud)
        {
            InhoudDAO.VoegInhoudToe(inhoud);
        }

        public Model.Inhoud GetInhoudPerId(int v)
        {
            return InhoudDAO.GetInhoudPerId(v);
        }

        public void Update(Model.Inhoud inhoud)
        {
            InhoudDAO.Update(inhoud);
        }
    }
}
