using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cl.riobaker.DAL.Data;
using cl.riobaker.DAL;
using Reporte_Log_Usuarios.DAO;
using Reporte_Log_Usuarios.Models;

namespace Reporte_Log_Usuarios.Controllers
{
    public class MantenedorController : Controller
    {


        public ActionResult EditarCC()
        {
            return View();
        }

        public ActionResult EditarRelacionProv()
        {
            return View();
        }

        public ActionResult EditarCuentasContables()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Eliminar()
        {

            string res = "false";
            string nomBd = Request["bd"].ToString();
            int id = int.Parse(Request["id"].ToString());
            if (nomBd == "RelProveedor")
            {
                if (MantenedorDAO.EliminarRelProveedor(id))
                {
                    res = "true";
                }
               
            }
            else if (nomBd == "CuentasContables")
            {
                if (MantenedorDAO.EliminarCuentaContable(id))
                {
                    res = "true";
                }
            }
            else if (nomBd == "CentroCostos")
            {
                if (MantenedorDAO.EliminarCC(id))
                {
                    res = "true";
                }
            }
            return Json(res);

        }

        [HttpPost]
        public JsonResult Editar()
        {

            string res = "false";
            string nomBd = Request["bd"].ToString();
            
            if (nomBd == "RelProveedor")
            {
                int id = int.Parse(Request["id"].ToString());
                string codProvS = Request["codProvS"].ToString();
                string razonSocial = Request["razonSocial"].ToString();
                string codProvU = Request["codProvU"].ToString();
                string siteId = Request["siteId"].ToString();
                if (MantenedorDAO.EditarRelProveedor( id, codProvS,  razonSocial,  codProvU,  siteId))
                {
                    res = "true";
                }

            }
            else if (nomBd == "CuentasContables")
            {
                int id = int.Parse(Request["idCueCon"].ToString());
                string CueConSof = Request["CueConSof"].ToString();
                string CueConUPS = Request["CueConUPS"].ToString();
                if (MantenedorDAO.EditarCuentasContables( id,  CueConSof, CueConUPS))
                {
                    res = "true";
                }
            }
            else if (nomBd == "CentroCostos")
            {
                int id = int.Parse(Request["idCentroCostos"].ToString());
                string codCenSo = Request["codCenSo"].ToString();
                string nomCentro = Request["nomCentro"].ToString();
                string codCenUps = Request["codCenUps"].ToString();
                if (MantenedorDAO.EditarCC(id, codCenSo, nomCentro,codCenUps))
                {
                    res = "true";
                }
            }
            return Json(res);

        }


        [HttpPost]
        public JsonResult Autocompletar()
        {
            string bd = Request["bd"].ToString();
            string bd2 = "PIXIS";
            JsonResult res = new JsonResult();

            if (bd.Equals("RelProveedor"))
            {
                string filtro = Request["codProvS"].ToString();
                res= Json(MantenedorDAO.AutoListaRelProveedor(filtro, bd2));
            }
            else if (bd.Equals("CentroCostos"))
            {
                string filtro = Request["codCenSo"].ToString();
                res= Json(MantenedorDAO.AutoListaCC(filtro, bd2));
            }
            else if (bd.Equals("CuentasContables"))
            {
                string filtro = Request["CueConSof"].ToString();
                res = Json(MantenedorDAO.AutoListaCuentasContables(filtro, bd2));
            }


            return res;
        }


    }
}
