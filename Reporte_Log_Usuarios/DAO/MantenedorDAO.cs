using cl.riobaker.DAL.Data;
using Reporte_Log_Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Reporte_Log_Usuarios.DAO
{
    public class MantenedorDAO
    {
        public static List<CentroCostos_Model> ListarCentroCostos(CentroCostos_Model centro)
        {
            try
            {
                using (DataContext dc = new DataContext("DSUPS", "TraerCentroCostos", CommandType.StoredProcedure))
                {
                    //dc.parameters.AddWithValue("id", agents.results[indice].id);
                    //dc.parameters.AddWithValue("usuario", usuario.Usuario);
                    //dc.parameters.AddWithValue("password", usuario.Password);
                    return dc.executeQuery<CentroCostos_Model>();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }


        public static List<CuentasContables_Model> ListarCuentasContables(CuentasContables_Model centro)
        {
            try
            {
                using (DataContext dc = new DataContext("DSUPS", "TraerCuentasContables", CommandType.StoredProcedure))
                {
                    //dc.parameters.AddWithValue("id", agents.results[indice].id);
                    //dc.parameters.AddWithValue("usuario", usuario.Usuario);
                    //dc.parameters.AddWithValue("password", usuario.Password);
                    return dc.executeQuery<CuentasContables_Model>();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }


        public static List<RelProveedor_Model> ListarRelacionProv(RelProveedor_Model relpro)
        {
            try
            {
                using (DataContext dc = new DataContext("DSUPS", "TraerRelProveedor", CommandType.StoredProcedure))
                {
                    //dc.parameters.AddWithValue("id", agents.results[indice].id);
                    //dc.parameters.AddWithValue("usuario", usuario.Usuario);
                    //dc.parameters.AddWithValue("password", usuario.Password);
                    return dc.executeQuery<RelProveedor_Model>();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
        }

        public static bool insertarRel(string codProvS, string razonSocial, string codProvU, string siteId)
        {
            try
            {
                using (DataContext dc = new DataContext("DSUPS", "TraerRelProveedor", CommandType.Text))
                {
                    //dc.parameters.AddWithValue("id", agents.results[indice].id);
                    dc.command = "insert into [DSUPS].[dbo].[RelProveedor] (codProvS,razonSocial,codProvU,siteId) values ('" + codProvS + "','" + razonSocial + "','" + codProvU + "','" + siteId + "')";
                    //dc.parameters.AddWithValue("password", usuario.Password);
                    dc.executeQuery<RelProveedor_Model>();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return false;
            }
        }

        public static bool insertarCuentaCont(string CueConSof, string CueConUPS)
        {
            try
            {
                string query = "insert into [DSUPS].[dbo].[CuentasContables] (CueConSof,CueConUPS) values ('" + CueConSof + "','" + CueConUPS + "')";
                using (DataContext dc = new DataContext("DSUPS", query, CommandType.Text))
                {
                    
                    dc.executeQuery<RelProveedor_Model>();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return false;
            }
        }


        public static bool insertarCC(string codCenSo, string nomCentro, string codCenUps)
        {
            try
            {
                string query = "insert into [DSUPS].[dbo].[CentroCostos] (codCenSo,nomCentro,codCenUps) values ('" + codCenSo + "','" + nomCentro + "','" + codCenUps + "')";
                using (DataContext dc = new DataContext("DSUPS", query, CommandType.Text))
                {
                    dc.executeQuery<RelProveedor_Model>();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return false;
            }
        }

        public static bool EliminarCC(int id)
        {
            try
            {
                string query = "delete from [DSUPS].[dbo].[CentroCostos] where idCentroCostos=" + id + "";
                using (DataContext dc = new DataContext("DSUPS", query, CommandType.Text))
                {
                    dc.executeQuery<RelProveedor_Model>();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return false;
            }
        }

        public static bool EliminarCuentaContable(int id)
        {
            try
            {
                string query = "delete from [DSUPS].[dbo].[CuentasContables] where idCueCon=" + id + "";
                using (DataContext dc = new DataContext("DSUPS", query, CommandType.Text))
                {
                    dc.executeQuery<RelProveedor_Model>();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return false;
            }
        }


        public static bool EliminarRelProveedor(int id)
        {
            try
            {
                string query = "delete from [DSUPS].[dbo].[RelProveedor] where idRelProv=" + id + "";
                using (DataContext dc = new DataContext("DSUPS", query, CommandType.Text))
                {
                    dc.executeQuery<RelProveedor_Model>();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return false;
            }
        }

        public static bool EditarRelProveedor(int id,string codProvS, string razonSocial, string codProvU, string siteId)
        {
            try
            {
                string query = "update [DSUPS].[dbo].[RelProveedor] set codProvS='" + codProvS + "', razonSocial='" + razonSocial + 
                    "', codProvU='" + codProvU + "', siteId='" + siteId + "' where idRelProv=" + id + "";
                using (DataContext dc = new DataContext("DSUPS", query, CommandType.Text))
                {
                    dc.executeQuery<RelProveedor_Model>();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return false;
            }
        }

        public static bool EditarCuentasContables(int id, string CueConSof,string CueConUPS)
        {
            try
            {
                string query = "update [DSUPS].[dbo].[CuentasContables] set CueConSof='" + CueConSof + "', CueConUPS='" + CueConUPS +
                    "'  where idCueCon=" + id + "";
                using (DataContext dc = new DataContext("DSUPS", query, CommandType.Text))
                {
                    dc.executeQuery<RelProveedor_Model>();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return false;
            }
        }

        public static bool EditarCC(int id,string codCenSo,string nomCentro,string codCenUps)
        {
            try
            {
                string query = "update [DSUPS].[dbo].[CentroCostos] set codCenSo='" + codCenSo + "', nomCentro='" + nomCentro +
                    "',codCenUps='" + codCenUps + "'  where idCentroCostos=" + id + "";
                using (DataContext dc = new DataContext("DSUPS", query, CommandType.Text))
                {
                    dc.executeQuery<RelProveedor_Model>();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return false;
            }
        }

        //Autolista devuelve las opciones a ser listadas en autocompletado
        public static List<string> AutoListaRelProveedor(string cuenta,string bd)
        {
            List<string> res = new List<string>();
            try
            {
                string query = "select CodAux+' - '+NomAux as listar from " + bd + ".softland.cwtauxi where CodAux like '%" + cuenta + "%' or NomAux like '%" + cuenta + "%'";
                using (DataContext dc = new DataContext("DSUPS", query, CommandType.Text))
                {
                    DataTable dt= dc.executeQuery();
                    foreach(DataRow row in dt.Rows){
                        res.Add(row["listar"].ToString());
                    }
                    return res;
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                res.Add("error");
                return res;
            }
        }

        public static List<string> AutoListaCC(string cuenta, string bd)
        {
            List<string> res = new List<string>();
            try
            {
                string query = "select CodiCC+DescCC as listar from " + bd + ".softland.cwtccos where CodiCC like '%" + cuenta + "%' or DescCC like '%" + cuenta + "%'";
                using (DataContext dc = new DataContext("DSUPS", query, CommandType.Text))
                {
                    DataTable dt = dc.executeQuery();
                    //res.Add("{");
                    foreach (DataRow row in dt.Rows)
                    {
                        //string agregar = "'opt':'" + row["listar"].ToString() + "'";
                        res.Add(row["listar"].ToString());
                    }
                    //res.Add("}");
                    return res;
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                res.Add("error");
                return res;
            }
        }

        public static List<string> AutoListaCuentasContables(string cuenta, string bd)
        {
            List<string> res = new List<string>();
            try
            {
                string query = "select PCCODI+' - '+PCDESC as listar from " + bd + ".softland.cwpctas where PCCODI like '%" + cuenta + "%' or PCDESC like '%" + cuenta + "%'";
                using (DataContext dc = new DataContext("DSUPS", query, CommandType.Text))
                {
                    DataTable dt = dc.executeQuery();
                    //res.Add("{");
                    foreach (DataRow row in dt.Rows)
                    {
                        //string agregar = "'opt':'" + row["listar"].ToString() + "'";
                        res.Add(row["listar"].ToString());
                    }
                    //res.Add("}");
                    return res;
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                res.Add("error");
                return res;
            }
        }

    }
}