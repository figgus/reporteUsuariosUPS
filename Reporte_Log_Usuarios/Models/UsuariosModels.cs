﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reporte_Log_Usuarios.Models
{
    public class UsuariosModels
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string tipoUsuario { get; set; }
        public string urlInicio { get; set; }
        public string nombre { get; set; }
        public int tipoId { get; set; }
        public string VenCod { get; set; }
    }
}