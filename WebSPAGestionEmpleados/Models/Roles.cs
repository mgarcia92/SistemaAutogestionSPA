using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSPAGestionEmpleados.Models
{
    public partial class Roles
    {
        
        public string CiaCd { get; set; }
        public string RoleCd { get; set; }
        public string RoleDesc { get; set; }
        public byte ActivoFg { get; set; }
        public string CreaUsr { get; set; }
        public DateTime CreaDate { get; set; }
        public string MttoUsr { get; set; }
        public DateTime MttoDate { get; set; }

        public virtual Cias CiaCdNavigation { get; set; }

    }
}
