using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EXDIBO.Models;
using EXDIBO.Util;

namespace EXDIBO.Controllers
{
    public class FincaController : Controller
    {
        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Fincas()
        {
            List<Farm> farms = new ServiceFarm().GetAllFarm();
            return View(farms);
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Grupos()
        {
            List<Group> groups = new ServiceFarm().GetAllGroup();
            return View(groups);
        }
    }
}
