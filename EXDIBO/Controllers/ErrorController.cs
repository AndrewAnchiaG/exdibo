using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace EXDIBO.Controllers
{
    public class ErrorController : Controller
    {


        /* [Route("Error/{statusCode}")]
         [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
         public IActionResult HttpStatusCodeHandler(int statusCode)
         {
             switch (statusCode)
             {
                 case 404:
                     ViewData["Code"] = "404";
                     ViewBag.ErrorMessage = "El recurso solicitado no puede ser encontrado";
                     break;

                 case 500:
                     ViewData["Code"] = "500";
                     RedirectToAction("ProblemasConexion", "Expediente");
                     break;


             }
             ViewData["Code"] = statusCode;
             return View("Error");
         }*/

        [Route("/Error/Error/{code:int}")]
        public IActionResult Error(int code) {

            ViewBag.Code = code;
            ViewBag.ResquetId = "Test";
            ViewBag.ErrorMessage = "Lo sentimos, La Página que estás buscando no existe en este servidor";
            return View("Error");
        }
    }
}
