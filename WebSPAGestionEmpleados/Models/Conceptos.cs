using System;
using System.Collections.Generic;

namespace WebSPAGestionEmpleados.Models
{
    public partial class Conceptos
    {
        public string CiaCd { get; set; }
        public string NominaCd { get; set; }
        public int ConceptoNbr { get; set; }
        public string ConceptoDesc { get; set; }
        public int FuncionNbr { get; set; }
        public decimal SalarioSal { get; set; }
        public byte ActivoFg { get; set; }
        public string CreaUsr { get; set; }
        public DateTime CreaDate { get; set; }
        public string MttoUsr { get; set; }
        public DateTime MttoDate { get; set; }

        public virtual Cias CiaCdNavigation { get; set; }
    }
}
