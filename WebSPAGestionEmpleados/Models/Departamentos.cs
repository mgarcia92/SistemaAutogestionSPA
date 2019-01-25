using System;
using System.Collections.Generic;

namespace WebSPAGestionEmpleados.Models
{
    public partial class Departamentos
    {
        public string CiaCd { get; set; }
        public string DptoCd { get; set; }
        public string DptoDesc { get; set; }
        public byte ActivoFg { get; set; }
        public string CreaUsr { get; set; }
        public DateTime CreaDate { get; set; }
        public string MttoUsr { get; set; }
        public DateTime MttoDate { get; set; }

        public virtual Cias CiaCdNavigation { get; set; }
    }
}
