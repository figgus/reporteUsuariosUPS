using cl.riobaker.DAL.Data;
using Reporte_Log_Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Reporte_Log_Usuarios.DAO
{
    public class LoginDAO
    {
        public static List<UsuariosModels> Login(Usuario_Models usuario)
        {
            try
            {
                using (DataContext dc = new DataContext("Disofi", "SP_Login", CommandType.StoredProcedure))
                {
                    //dc.parameters.AddWithValue("id", agents.results[indice].id);
                    dc.parameters.AddWithValue("usuario", usuario.Usuario);
                    dc.parameters.AddWithValue("password", usuario.PassWord);
                    return dc.executeQuery<UsuariosModels>();
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