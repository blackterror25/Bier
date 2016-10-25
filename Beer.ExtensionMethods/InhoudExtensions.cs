using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Beer.Model;

namespace Beer.ExtensionMethods
{
    public partial class InhoudExtension : Inhoud
    {
        public String TestData{ get; set; }

        override
        public String ToString()
        {
            return Capaciteit + " " + Eenheid;
        }
    }
}
