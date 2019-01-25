using System;
using System.Collections.Generic;

namespace WebSPAGestionEmpleados.Models
{
    public partial class Cias
    {
        public Cias()
        {
            Cargos = new HashSet<Cargos>();
            Conceptos = new HashSet<Conceptos>();
            Departamentos = new HashSet<Departamentos>();
            Direcciones = new HashSet<Direcciones>();
            Historico = new HashSet<Historico>();
            HistoricoSueldos = new HashSet<HistoricoSueldos>();
            InterfazControl = new HashSet<InterfazControl>();
            InterfazEstructura = new HashSet<InterfazEstructura>();
            Maestro = new HashSet<Maestro>();
            MaestroDatos = new HashSet<MaestroDatos>();
            Procesos = new HashSet<Procesos>();
            Profesiones = new HashSet<Profesiones>();
            Promedios = new HashSet<Promedios>();
            PromediosConceptos = new HashSet<PromediosConceptos>();
            PromediosDetalle = new HashSet<PromediosDetalle>();
            Saldos = new HashSet<Saldos>();
            Telefonos = new HashSet<Telefonos>();
            TipoNomina = new HashSet<TipoNomina>();
            Usuarios = new HashSet<Usuarios>();
        }

        public string CiaCd { get; set; }
        public string CiaDesc { get; set; }
        public string RifTipo { get; set; }
        public string RifNbr { get; set; }
        public string CreaUsr { get; set; }
        public DateTime CreaDate { get; set; }
        public string MttoUsr { get; set; }
        public DateTime MttoDate { get; set; }

        public virtual ICollection<Cargos> Cargos { get; set; }
        public virtual ICollection<Conceptos> Conceptos { get; set; }
        public virtual ICollection<Departamentos> Departamentos { get; set; }
        public virtual ICollection<Direcciones> Direcciones { get; set; }
        public virtual ICollection<Historico> Historico { get; set; }
        public virtual ICollection<HistoricoSueldos> HistoricoSueldos { get; set; }
        public virtual ICollection<InterfazControl> InterfazControl { get; set; }
        public virtual ICollection<InterfazEstructura> InterfazEstructura { get; set; }
        public virtual ICollection<Maestro> Maestro { get; set; }
        public virtual ICollection<MaestroDatos> MaestroDatos { get; set; }
        public virtual ICollection<Procesos> Procesos { get; set; }
        public virtual ICollection<Profesiones> Profesiones { get; set; }
        public virtual ICollection<Promedios> Promedios { get; set; }
        public virtual ICollection<PromediosConceptos> PromediosConceptos { get; set; }
        public virtual ICollection<PromediosDetalle> PromediosDetalle { get; set; }
        public virtual ICollection<Saldos> Saldos { get; set; }
        public virtual ICollection<Telefonos> Telefonos { get; set; }
        public virtual ICollection<TipoNomina> TipoNomina { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
