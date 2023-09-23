using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EXDIBO.Models;
using EXDIBO.Util;


namespace EXDIBO.Controllers
{
    public class MantenimientoController : Controller
    {

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Enfermedades()
        {
            List<Kind> illness = new ServiceMedicine().GetAllIllness();
            return View(illness);
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult DetallesEnfermedad(int id) //DetallesEnfermedad
        {
            List<Kind> illness = new ServiceMedicine().GetAllIllness();
            return View(illness);
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult EditarEnfermedad(int id) //TODO:EditarEnfermedad
        {
            List<Kind> illness = new ServiceMedicine().GetAllIllness();
            return View(illness);
        }

        
        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult EstadoEnfermedad(int id, bool status)  //TODO: EstadoEnfermedad
        {
            bool result = new ServiceMantenimiento().StatusIlness(id, status);

            if (result)
            {
                return RedirectToAction("Enfermedades", "Mantenimiento");
            }
            else
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Procedimientos()
        {
            return View();
        }


        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Vias()
        {
            return View();
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Aplicar()
        {
            return View();
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Examenes()
        {
            return View();
        }

    }
}
