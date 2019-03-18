using System;
using System.Collections.Generic;

namespace WebSPAGestionEmpleados.Models
{
    public partial class Usuarios
    {
        public string CiaCd { get; set; }
        public string LoginUsr { get; set; }
        public string LoginPwd { get; set; }
        public string CedulaNbr { get; set; }
        public string RoleCd { get; set; }
        public string FotoImg { get; set; }
        public byte ActivoFg { get; set; }
        public string CreaUsr { get; set; }
        public DateTime? CreaDate { get; set; }
        public string MttoUsr { get; set; }
        public DateTime? MttoDate { get; set; }

        public virtual Cias CiaCdNavigation { get; set; }
    }
}
