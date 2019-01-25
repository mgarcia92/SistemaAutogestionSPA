using System;
using System.Collections.Generic;

namespace WebSPAGestionEmpleados.Models
{
    public partial class HistoricoSueldos
    {
        public string CiaCd { get; set; }
        public string FichaCd { get; set; }
        public DateTime SueldoDate { get; set; }
        public string SueldoTipo { get; set; }
        public int ItemNbr { get; set; }
        public decimal SueldoSal { get; set; }
        public byte ActivoFg { get; set; }
        public string CreaUsr { get; set; }
        public DateTime CreaDate { get; set; }
        public string MttoUsr { get; set; }
        public DateTime MttoDate { get; set; }

        public virtual Cias CiaCdNavigation { get; set; }
        public virtual Maestro Maestro { get; set; }
    }
}
