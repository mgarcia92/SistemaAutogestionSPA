using System;
using System.Collections.Generic;

namespace WebSPAGestionEmpleados.Models
{
    public partial class Promedios
    {
        public Promedios()
        {
            PromediosConceptos = new HashSet<PromediosConceptos>();
            PromediosDetalle = new HashSet<PromediosDetalle>();
        }

        public string CiaCd { get; set; }
        public string NominaCd { get; set; }
        public string PromedioCd { get; set; }
        public string PromedioDesc { get; set; }
        public int SalarioNbr { get; set; }
        public byte ActivoFg { get; set; }
        public string CreaUsr { get; set; }
        public DateTime CreaDate { get; set; }
        public string MttoUsr { get; set; }
        public DateTime MttoDate { get; set; }

        public virtual Cias CiaCdNavigation { get; set; }
        public virtual ICollection<PromediosConceptos> PromediosConceptos { get; set; }
        public virtual ICollection<PromediosDetalle> PromediosDetalle { get; set; }
    }
}
