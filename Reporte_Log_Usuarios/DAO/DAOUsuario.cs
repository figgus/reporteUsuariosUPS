using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cl.riobaker.DAL;
using cl.riobaker.DAL.Data;
using System.Data;
using Reporte_Log_Usuarios.Models;

namespace Reporte_Log_Usuarios.DAO
{
    public class DAOUsuario
    {
        public static List<Usuario_Models> buscar(Usuario_Models NVC)
        {
            try
            {
                using (DataContext dc = new DataContext("SnackCenter", "ReportUsuarios", CommandType.StoredProcedure))
                {
                    dc.parameters.AddWithValue("FECHAD", NVC.fechad);
                    dc.parameters.AddWithValue("FECHAA", NVC.fechaa);

                    return dc.executeQuery<Usuario_Models>();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }
    }
}