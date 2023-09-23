using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EXDIBO.Controllers
{
   public class ExpedienteController : Controller
    {

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Portada()
        {
            return View();
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult ProblemasConexion()
        {
            return View();
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult AccesoDenegado()
        {
            return View();
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Politicas()
        {
            return View();
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult PoliticasPublicas()
        {
            return View();
        }

        public IActionResult AccesoNegado()
        {
            return View();
        }

        public IActionResult EXDIBO()
        {
            return View();
        }
    }
}
