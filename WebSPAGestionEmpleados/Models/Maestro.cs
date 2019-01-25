using System;
using System.Collections.Generic;

namespace WebSPAGestionEmpleados.Models
{
    public partial class Maestro
    {
        public Maestro()
        {
            Direcciones = new HashSet<Direcciones>();
            Historico = new HashSet<Historico>();
            HistoricoSueldos = new HashSet<HistoricoSueldos>();
            MaestroDatos = new HashSet<MaestroDatos>();
            Profesiones = new HashSet<Profesiones>();
            Saldos = new HashSet<Saldos>();
            Telefonos = new HashSet<Telefonos>();
        }

        public string CiaCd { get; set; }
        public string FichaCd { get; set; }
        public string NominaCd { get; set; }
        public DateTime IngresoDate { get; set; }
        public byte RetiroFg { get; set; }
        public DateTime RetiroDate { get; set; }
        public decimal Sueldo1Sal { get; set; }
        public decimal Sueldo2Sal { get; set; }
        public decimal Sueldo3Sal { get; set; }
        public string JefeCd { get; set; }
        public string DptoCd { get; set; }
        public string CargoCd { get; set; }
        public int NivelNbr { get; set; }
        public int NivelOrg { get; set; }
        public byte SindicatoFg { get; set; }
        public string CreaUsr { get; set; }
        public DateTime CreaDate { get; set; }
        public string MttoUsr { get; set; }
        public DateTime MttoDate { get; set; }

        public virtual Cias CiaCdNavigation { get; set; }
        public virtual ICollection<Direcciones> Direcciones { get; set; }
        public virtual ICollection<Historico> Historico { get; set; }
        public virtual ICollection<HistoricoSueldos> HistoricoSueldos { get; set; }
        public virtual ICollection<MaestroDatos> MaestroDatos { get; set; }
        public virtual ICollection<Profesiones> Profesiones { get; set; }
        public virtual ICollection<Saldos> Saldos { get; set; }
        public virtual ICollection<Telefonos> Telefonos { get; set; }
    }
}
