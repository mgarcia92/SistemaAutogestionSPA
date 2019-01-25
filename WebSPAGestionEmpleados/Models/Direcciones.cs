using System;
using System.Collections.Generic;

namespace WebSPAGestionEmpleados.Models
{
    public partial class Direcciones
    {
        public string CiaCd { get; set; }
        public string FichaCd { get; set; }
        public int ParentescoNbr { get; set; }
        public int ItemNbr { get; set; }
        public int PaisNbr { get; set; }
        public int EstadoNbr { get; set; }
        public int CiudadNbr { get; set; }
        public string DireccionTxt { get; set; }
        public byte ActivoFg { get; set; }
        public string CreaUsr { get; set; }
        public DateTime CreaDate { get; set; }
        public string MttoUsr { get; set; }
        public DateTime MttoDate { get; set; }

        public virtual Cias CiaCdNavigation { get; set; }
        public virtual Maestro Maestro { get; set; }
        public virtual MaestroDatos MaestroDatos { get; set; }
    }
}
