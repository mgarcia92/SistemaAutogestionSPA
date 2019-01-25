using System;
using System.Collections.Generic;

namespace WebSPAGestionEmpleados.Models
{
    public partial class InterfazControl
    {
        public string CiaCd { get; set; }
        public int ItemNbr { get; set; }
        public string InterfazDesc { get; set; }
        public string ArchivoNm { get; set; }
        public string ArchivoInterfaz { get; set; }
        public int FrecuenciaNbr { get; set; }
        public byte EjecutarFg { get; set; }
        public DateTime EjecutarDate { get; set; }
        public DateTime InterfazDate { get; set; }
        public int ItemTbl { get; set; }
        public byte ActivoFg { get; set; }
        public string CreaUsr { get; set; }
        public DateTime CreaDate { get; set; }
        public string MttoUsr { get; set; }
        public DateTime MttoDate { get; set; }

        public virtual Cias CiaCdNavigation { get; set; }
    }
}
