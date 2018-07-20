using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reporte_Log_Usuarios.Models
{
    public class RelProveedor_Model
    {
        public int idRelProv { get; set; }
        public string codProvS { get; set; }
        public string razonSocial { get; set; }
        public string codProvU { get; set; }
        public string siteId { get; set; }


        public string[] autocomp { get; set; }
        public string json { get; set; }
        
    }
}