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
    public class ReporteController : Controller
    {
 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Agregar()
        {
            return View();
        }

        public ActionResult AgregarCC()
        {
            return View();
        }
        public ActionResult AgregarCuentaCont()
        {
            return View();
        }

        public ActionResult RelacionProveedor()
        {
            RelProveedor_Model CuentaCont = new RelProveedor_Model();
            List<RelProveedor_Model> lista = MantenedorDAO.ListarRelacionProv(CuentaCont);
            ViewBag.rel = lista;
            return View();
        }
        public ActionResult CuentasContables()
        {
            CuentasContables_Model CuentaCont = new CuentasContables_Model();
            List<CuentasContables_Model> lista = MantenedorDAO.ListarCuentasContables(CuentaCont);
            ViewBag.cuenta = lista;
            return View();
        }
        public ActionResult CentroCostos()
        {
            CentroCostos_Model centroCosto = new CentroCostos_Model();
            List<CentroCostos_Model> lista = MantenedorDAO.ListarCentroCostos(centroCosto);
            ViewBag.centro = lista;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Login(FormCollection frm)
        {
            Usuario_Models usuario = new Usuario_Models();

            usuario.Usuario = Request.Form["__usuario"];
            usuario.PassWord = Request.Form["__password"];

            List<UsuariosModels> listaUsuario = LoginDAO.Login(usuario);

            if (listaUsuario == null || listaUsuario.Count == 0)
            {
                //TempData["Mensaje"] = " <div class='alert alert-danger fade in' role='alert'><button type='button' class='close' data-dismiss='alert'><span aria-hidden='true'>×</span><span class='sr-only'>Close</span></button><strong style='font-size:24px'><i class='fa fa-times-circle' aria-hidden='true'></i> Error - Credenciales Incorrectas</strong></div>";
                TempData["Mensaje"] = "ERROR - Verifique los datos ingresados <br>";
                return View();
            }
            else
            {
                Session["UsuarioValidado"] = true;
                Session["ID"] = listaUsuario[0].id;
                //Session["nombre"] = listaUsuario[0].nombre;
                Session["nombre"] = listaUsuario[0].Usuario;
                Session["VenCod"] = listaUsuario[0].VenCod;
                Session["tipoId"] = listaUsuario[0].tipoId;
                //System.Web.HttpContext.Current.Session["id"] = listaUsuario[0].id;
                //System.Web.HttpContext.Current.Session["nombre"] = listaUsuario[0].nombre;
                //System.Web.HttpContext.Current.Session["sessionString"] = "pruebaLOGIN";


                Session["Test"] = "Am new to Session";

                //When u want to retrieve the value,
                //string abc = Session["Test"].ToString();


                //return RedirectToAction("Ventas", listaUsuario[0].urlInicio);

                if (listaUsuario[0].tipoId == 1)
                {
                    return RedirectToAction("index", "Reporte");
                }
                else
                {
                    return RedirectToAction("index", "Reporte");
                }
                //return RedirectToAction(listaUsuario[0].urlInicio, "Ventas");
            }

            //return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Index(FormCollection frm)
        {
            Usuario_Models usu = new Usuario_Models();
            DateTime fechaInicio;
            DateTime fechaTermino;
            try
            {
                fechaInicio = DateTime.Parse(Request["fechaInicio"].ToString());
                fechaTermino = DateTime.Parse(Request["fechaTermino"].ToString());
            }
            catch (Exception)
            {
                return Json("formato de fecha no valido");
            }

            usu.fechad = fechaInicio;
            usu.fechaa = fechaTermino;
            List<Usuario_Models> lista = DAOUsuario.buscar(usu);

            ViewBag.usua = lista;

            return View();
        }

        public void CerrarSession()
        {
            Session["UsuarioValidado"] = false;
            Response.Redirect("/Reporte/Login");
        }

        [HttpPost]
        public JsonResult Insertar()
        {
            string res="false";
            string nomBd = Request["bd"].ToString();
            if (nomBd == "RelProveedor")
            {
                
                string codProvS = Request["codProvS"].ToString();
                string razonSocial = Request["razon"].ToString();
                string codProvU = Request["codProvU"].ToString();
                string siteId = Request["siteId"].ToString();
                if (MantenedorDAO.insertarRel(codProvS, razonSocial, codProvU, siteId))
                {
                    res = "true";
                }
            }
            else if (nomBd == "CuentasContables")
            {
                string CueConSof = Request["CueConSof"].ToString();
                string CueConUPS = Request["CueConUPS"].ToString();
                if (MantenedorDAO.insertarCuentaCont(CueConSof, CueConUPS))
                {
                    res = "true";
                }
            }
            else if (nomBd == "CentroCostos")
            {
                string codCenSo = Request["codCenSo"].ToString();
                string nomCentro = Request["nomCentro"].ToString();
                string codCenUps = Request["codCenUps"].ToString();
                if (MantenedorDAO.insertarCC(codCenSo, nomCentro, codCenUps))
                {
                    res = "true";
                }
            }
            return Json(res);
        }


    }
}
