using System;
using System.Collections.Generic;

namespace WebSPAGestionEmpleados.Models
{
    public partial class Configuracion
    {
        public string CiaCd { get; set; }
        public string EmailEnvioTxt { get; set; }
        public string EmailSoporteTxt { get; set; }
        public string TimeZoneTxt { get; set; }
        public string CarpetaFilesTxt { get; set; }
        public string ExtensionFilesTxt { get; set; }
        public string CarpetaBackupTxt { get; set; }
        public string ExtensionBackupTxt { get; set; }
        public string CarpetaErrorTxt { get; set; }
        public string ExtensionErrorTxt { get; set; }
        public string CreaUsr { get; set; }
        public DateTime CreaDate { get; set; }
        public string MttoUsr { get; set; }
        public DateTime MttoDate { get; set; }
    }
}
