using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Reporte_Log_Usuarios.Models.Clases
{
    public class Archivo
    {
        public void guardarExcel(string ruta,List<Usuario_Models> modelo){
            if(modelo==null){
                throw new Exception("el modelo esta vacio");
            }
            FileInfo newFile = new FileInfo(ruta);
            if (newFile.Exists){
                File.Delete(ruta);
            }

            //File.Create(ruta);
            using (StreamWriter sw = new StreamWriter(ruta))
            {
                foreach (Usuario_Models usu in modelo)
                {
                    sw.WriteLine("Usuario: "+usu.Usuario+" --nombre:"+usu.Nombre+" --rut: "+usu.Rut+
                        "-- actividad: " + usu.Activity + "-- fecha:" + DateTime.Parse(usu.Date_Time.ToString()).ToLongDateString() + "-- hora: " + DateTime.Parse(usu.Date_Time.ToString()).ToLongTimeString() + "-- detalle:" + usu.detalle + "");
                }
                sw.Close();
            }

        }
    }
}