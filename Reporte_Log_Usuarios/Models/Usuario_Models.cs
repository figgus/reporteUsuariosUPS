using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reporte_Log_Usuarios.Models
{
    public class Usuario_Models
    {
        public string Usuario {get; set;}
        public string PassWord {get; set;}
        public string Nombre {get; set;}
        public string Firma {get; set;}
        public string Rut {get; set;}
        public string eMail {get; set;}
        public int Bloqueado {get; set;}
        public DateTime FechaLogin {get; set;}
        public string MotivoBloqueo {get; set;}
        public string Activity {get; set;}
        public string usersistema {get; set;}
        public DateTime Date_Time { get; set; }
        public string detalle {get; set;}
        public DateTime fechad { get; set; }
        public DateTime fechaa { get; set; }
        public string Hora { get; set; }
        
    }
}