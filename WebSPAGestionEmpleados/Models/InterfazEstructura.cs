using System;
using System.Collections.Generic;

namespace WebSPAGestionEmpleados.Models
{
    public partial class InterfazEstructura
    {
        public string CiaCd { get; set; }
        public string ArchivoIoCd { get; set; }
        public string ArchivoNm { get; set; }
        public string ColumnaNm { get; set; }
        public string DataTipo { get; set; }
        public int InicioQty { get; set; }
        public int LongitudQty { get; set; }
        public int DecimalesQty { get; set; }
        public string FormatoTxt { get; set; }
        public string CheckTableNm { get; set; }
        public string CreaUsr { get; set; }
        public DateTime CreaDate { get; set; }
        public string MttoUsr { get; set; }
        public DateTime MttoDate { get; set; }

        public virtual Cias CiaCdNavigation { get; set; }
    }
}
