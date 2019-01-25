using System;
using System.Collections.Generic;

namespace WebSPAGestionEmpleados.Models
{
    public partial class PromediosConceptos
    {
        public string CiaCd { get; set; }
        public string NominaCd { get; set; }
        public string PromedioCd { get; set; }
        public int ConceptoNbr { get; set; }
        public byte ActivoFg { get; set; }
        public string CreaUsr { get; set; }
        public DateTime CreaDate { get; set; }
        public string MttoUsr { get; set; }
        public DateTime MttoDate { get; set; }

        public virtual Cias CiaCdNavigation { get; set; }
        public virtual Promedios Promedios { get; set; }
    }
}
