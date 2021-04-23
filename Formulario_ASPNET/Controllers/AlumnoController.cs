using Formulario_ASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Formulario_ASPNET.Controllers
{
    public class AlumnoController : Controller
    {
        private Alumno alumno = new Alumno();
        
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Registrar nuevo alumno";


            return View(alumno.Listar());
        }


        [HttpPost]
        public ActionResult Index(string dni, string nombre, string apellido)
        {          
            
            if (alumno.Insertar(dni, nombre, apellido))
            {
                ViewBag.alerta = "success";
                ViewBag.res = "Alumno registrado";
            }
            else
            {
                ViewBag.alerta = "danger";
                ViewBag.res = "Error al registrar alumno";
            }

            return View(alumno.Listar());
        }
        
    }
}