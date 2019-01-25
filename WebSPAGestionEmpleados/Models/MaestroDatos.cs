using System;
using System.Collections.Generic;

namespace WebSPAGestionEmpleados.Models
{
    public partial class MaestroDatos
    {
        public MaestroDatos()
        {
            Profesiones = new HashSet<Profesiones>();
        }

        public string CiaCd { get; set; }
        public string FichaCd { get; set; }
        public string FichaNm { get; set; }
        public int ParentescoNbr { get; set; }
        public int ItemNbr { get; set; }
        public DateTime NacimientoDate { get; set; }
        public int SexoNbr { get; set; }
        public int EdocivilNbr { get; set; }
        public string CedulaNac { get; set; }
        public string CedulaNbr { get; set; }
        public string RifTipo { get; set; }
        public string RifNbr { get; set; }
        public int CuentaNro { get; set; }
        public string CuentaBco { get; set; }
        public string DepositoBco { get; set; }
        public int ProfesionNbr { get; set; }
        public string EmailTxt { get; set; }
        public string SsoNbr { get; set; }
        public string PasaporteNbr { get; set; }
        public string CreaUsr { get; set; }
        public DateTime CreaDate { get; set; }
        public string MttoUsr { get; set; }
        public DateTime MttoDate { get; set; }

        public virtual Cias CiaCdNavigation { get; set; }
        public virtual Maestro Maestro { get; set; }
        public virtual Direcciones Direcciones { get; set; }
        public virtual Telefonos Telefonos { get; set; }
        public virtual ICollection<Profesiones> Profesiones { get; set; }
    }
}
