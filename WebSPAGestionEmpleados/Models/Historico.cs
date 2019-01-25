using System;
using System.Collections.Generic;

namespace WebSPAGestionEmpleados.Models
{
    public partial class Historico
    {
        public string CiaCd { get; set; }
        public string FichaCd { get; set; }
        public string NominaCd { get; set; }
        public int AnoNbr { get; set; }
        public int MesNbr { get; set; }
        public int PeriodoNbr { get; set; }
        public int ProcesoNbr { get; set; }
        public int SubprocesoNbr { get; set; }
        public int ItemNbr { get; set; }
        public int ConceptoNbr { get; set; }
        public int FuncionNbr { get; set; }
        public decimal SueldoSal { get; set; }
        public string SueldoTipo { get; set; }
        public decimal CantidadQty { get; set; }
        public decimal FactorQty { get; set; }
        public decimal ValorSal { get; set; }
        public decimal MontoSal { get; set; }
        public decimal SaldoSal { get; set; }
        public byte SumarizaFg { get; set; }
        public DateTime MovimientoDate { get; set; }
        public string PromedioCd { get; set; }
        public int PrioridadNbr { get; set; }
        public string DptoCd { get; set; }
        public string CargoCd { get; set; }
        public string CuentaContable { get; set; }
        public int CuentaNro { get; set; }
        public string CuentaBco { get; set; }
        public byte DepositoFg { get; set; }
        public string DepositoTipo { get; set; }
        public string DepositoBco { get; set; }
        public string CreaUsr { get; set; }
        public DateTime CreaDate { get; set; }
        public string MttoUsr { get; set; }
        public DateTime MttoDate { get; set; }

        public virtual Cias CiaCdNavigation { get; set; }
        public virtual Maestro Maestro { get; set; }
    }
}
