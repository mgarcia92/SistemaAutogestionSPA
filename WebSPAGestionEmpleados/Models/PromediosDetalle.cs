using System;
using System.Collections.Generic;

namespace WebSPAGestionEmpleados.Models
{
    public partial class PromediosDetalle
    {
        public string CiaCd { get; set; }
        public string NominaCd { get; set; }
        public string FichaCd { get; set; }
        public int AnoNbr { get; set; }
        public int MesNbr { get; set; }
        public int PeriodoNbr { get; set; }
        public string PromedioCd { get; set; }
        public decimal CantidadQty { get; set; }
        public decimal ValorSal { get; set; }
        public byte ActivoFg { get; set; }
        public string CreaUsr { get; set; }
        public DateTime CreaDate { get; set; }
        public string MttoUsr { get; set; }
        public DateTime MttoDate { get; set; }

        public virtual Cias CiaCdNavigation { get; set; }
        public virtual Promedios Promedios { get; set; }
    }
}
