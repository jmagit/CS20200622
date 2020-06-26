using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos {
    public partial class Producto {
        public string Estilo {
            get {
                switch(Style) {
                    case "W ": return "Womens";
                    case "M ": return "Mens";
                    case "U ": return "Universal";
                    default: return "";
                }
            }
        }

        public void Descatalogar() {
            DiscontinuedDate = DateTime.Today;
            this.ListPrice = 0;
            // ...
        }
    }
}
