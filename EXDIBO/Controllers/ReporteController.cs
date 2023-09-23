using Microsoft.AspNetCore.Mvc;
using EXDIBO.Util;
using Microsoft.AspNetCore.Authorization;
using EXDIBO.Models;

namespace EXDIBO.Controllers
{
    public class ReporteController : Controller
    {

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Gestacion()
        {
            try
            {
                return View();
            }
            catch (Exception) 
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        [HttpGet]
        public JsonResult DataGestacion()
        {
            try
            {
                DateTime hasta = DateTime.Now;
                DateTime desde = new(hasta.Year - 1, hasta.Month, 01, 00, 00, 00);
                Serie data = new ServiceReport().GetPregnancy(desde, hasta);
                return Json(data);
            }
            catch (Exception)
            {
                Gestacion();
                return Json(null);
            }
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult PrenesEfectiva()
        {
            ViewData["error"] = String.Empty;
            return View(null);
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        [HttpPost]
        public IActionResult PrenesEfectiva(DateTime Desde, DateTime Hasta)
        {

            try
            {
                ViewData["error"] = String.Empty;

                if (DateTime.Compare(Hasta, DateTime.Now) > 0)
                {
                    ViewData["error"] = "La Fecha debe no debe ser mayor a hoy";
                    return View(null);
                }
                else if (DateTime.Compare(Desde, Hasta) > 0)
                {
                    ViewData["error"] = "La Fecha de Inicio debe ser menor a la Fecha Final";
                    return View(null);
                }
                else if (DateTime.Compare(Desde, new DateTime(0001, 1, 1, 00, 00, 00)) == 0)
                {
                    ViewData["error"] = "Debe indicar una fecha para Desde valida";
                    return View(null);
                }
                else if (DateTime.Compare(Hasta, new DateTime(0001, 1, 1, 00, 00, 00)) == 0)
                {
                    ViewData["error"] = "Debe indicar una fecha para Hasta valida";
                    return View(null);
                }

                List<PregnantReport> report = new ServiceReport().PregnantReport(Desde, Hasta);
                if (report.Count() <= 0)
                {
                    ViewData["error"] = String.Empty;
                    report = null;
                }
                return View(report);
            }
            catch (Exception)
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }


        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Nacimientos()
        {
            ViewData["error"] = String.Empty;
            return View(null);
        }


        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        [HttpPost]
        public IActionResult Nacimientos(DateTime Desde, DateTime Hasta)
        {
            try
            {
                ViewData["error"] = String.Empty;

                if (DateTime.Compare(Hasta, DateTime.Now) > 0)
                {
                    ViewData["error"] = "La Fecha debe no debe ser mayor a hoy";
                    return View(null);
                }
                else if (DateTime.Compare(Desde, Hasta) > 0)
                {
                    ViewData["error"] = "La Fecha de Inicio debe ser menor a la Fecha Final";
                    return View(null);
                }
                else if (DateTime.Compare(Desde, new DateTime(0001, 1, 1, 00, 00, 00)) == 0)
                {
                    ViewData["error"] = "Debe indicar una fecha para Desde valida";
                    return View(null);
                }
                else if (DateTime.Compare(Hasta, new DateTime(0001, 1, 1, 00, 00, 00)) == 0)
                {
                    ViewData["error"] = "Debe indicar una fecha para Hasta valida";
                    return View(null);
                }
                List<BovineReport> report = new ServiceReport().BornReport(Desde, Hasta);
                if (report.Count() <= 0)
                {
                    ViewData["error"] = String.Empty;
                    report = null;
                }
                return View(report);
            }
            catch (Exception)
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }


        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult AnimalDesecho()
        {
            ViewData["error"] = String.Empty;
            return View(null);
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        [HttpPost]
        public IActionResult AnimalDesecho(DateTime Desde, DateTime Hasta)
        {
            try
            {
                ViewData["error"] = String.Empty;

                if (DateTime.Compare(Hasta, DateTime.Now) > 0)
                {
                    ViewData["error"] = "La Fecha debe no debe ser mayor a hoy";
                    return View(null);
                }
                else if (DateTime.Compare(Desde, Hasta) > 0)
                {
                    ViewData["error"] = "La Fecha de Inicio debe ser menor a la Fecha Final";
                    return View(null);
                }
                else if (DateTime.Compare(Desde, new DateTime(0001, 1, 1, 00, 00, 00)) == 0)
                {
                    ViewData["error"] = "Debe indicar una fecha para Desde valida";
                    return View(null);
                }
                else if (DateTime.Compare(Hasta, new DateTime(0001, 1, 1, 00, 00, 00)) == 0)
                {
                    ViewData["error"] = "Debe indicar una fecha para Hasta valida";
                    return View(null);
                }
                List<Bovine> report = new ServiceReport().DiscardReport(Desde, Hasta);
                if (report.Count() <= 0)
                {
                    ViewData["error"] = String.Empty;
                    report = null;
                }
                return View(report);
            }
            catch (Exception)
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }



        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Inyectados()
        {
            ViewData["error"] = String.Empty;
            return View(null);
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        [HttpPost]
        public IActionResult Inyectados(DateTime Desde, DateTime Hasta)
        {
            try
            {
                ViewData["error"] = String.Empty;

                if (DateTime.Compare(Hasta, DateTime.Now) > 0)
                {
                    ViewData["error"] = "La Fecha debe no debe ser mayor a hoy";
                    return View(null);
                }
                else if (DateTime.Compare(Desde, Hasta) > 0)
                {
                    ViewData["error"] = "La Fecha de Inicio debe ser menor a la Fecha Final";
                    return View(null);
                }
                else if (DateTime.Compare(Desde, new DateTime(0001, 1, 1, 00, 00, 00)) == 0)
                {
                    ViewData["error"] = "Debe indicar una fecha para Desde valida";
                    return View(null);
                }
                else if (DateTime.Compare(Hasta, new DateTime(0001, 1, 1, 00, 00, 00)) == 0)
                {
                    ViewData["error"] = "Debe indicar una fecha para Hasta valida";
                    return View(null);
                }
                List<WithdrawalReport> report = new ServiceReport().WithdrawalReport(Desde, Hasta);
                if (report.Count() <= 0)
                {
                    ViewData["error"] = String.Empty;
                    report = null;
                }
                return View(report);
            }
            catch (Exception)
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Implantado()
        {
            ViewData["error"] = String.Empty;
            return View(null);
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        [HttpPost]
        public IActionResult Implantado(DateTime Desde, DateTime Hasta)
        {
            try
            {
                ViewData["error"] = String.Empty;

                if (DateTime.Compare(Hasta, DateTime.Now) > 0)
                {
                    ViewData["error"] = "La Fecha debe no debe ser mayor a hoy";
                    return View(null);
                }
                else if (DateTime.Compare(Desde, Hasta) > 0)
                {
                    ViewData["error"] = "La Fecha de Inicio debe ser menor a la Fecha Final";
                    return View(null);
                }
                else if (DateTime.Compare(Desde, new DateTime(0001, 1, 1, 00, 00, 00)) == 0)
                {
                    ViewData["error"] = "Debe indicar una fecha para Desde valida";
                    return View(null);
                }
                else if (DateTime.Compare(Hasta, new DateTime(0001, 1, 1, 00, 00, 00)) == 0)
                {
                    ViewData["error"] = "Debe indicar una fecha para Hasta valida";
                    return View(null);
                }
                List<WithdrawalReport> report = new ServiceReport().ImplantReport(Desde, Hasta);
                if (report.Count() <= 0)
                {
                    ViewData["error"] = String.Empty;
                    report = null;
                }
                return View(report);
            }
            catch (Exception)
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Retiros()
        {
            ViewData["error"] = String.Empty;
            return View(null);
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult TopFarmacos()
        {
            ViewData["error"] = String.Empty;
            return View(null);
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Rendimiento()
        {
            ViewData["error"] = String.Empty;
            return View(null);
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult ProyeccionAlumbramiento()
        {
            ViewData["error"] = String.Empty;
            return View(null);
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        [HttpPost]
        public IActionResult ProyeccionAlumbramiento(DateTime Desde, DateTime Hasta)
        {
            try
            {
                ViewData["error"] = String.Empty;
                if (DateTime.Compare(Desde, Hasta) > 0)
                {
                    ViewData["error"] = "La Fecha de Inicio debe ser menor a la Fecha Final";
                    return View(null);
                }
                else if (DateTime.Compare(Desde, Hasta) == 0)
                {
                    ViewData["error"] = "La Fecha de Inicio debe ser menor a la Fecha Final";
                    return View(null);
                }
                else if (DateTime.Compare(Desde, new DateTime(0001, 1, 1, 00, 00, 00)) == 0)
                {
                    ViewData["error"] = "Debe indicar una fecha para Desde valida";
                    return View(null);
                }
                else if (DateTime.Compare(Hasta, new DateTime(0001, 1, 1, 00, 00, 00)) == 0)
                {
                    ViewData["error"] = "Debe indicar una fecha para Hasta valida";
                    return View(null);
                }

                List<Born> report = new ServiceReport().GetBornByMonth(Desde, Hasta);

                if (report.Count() <= 0)
                {
                    ViewData["error"] = String.Empty;
                    report = null;
                }
                return View(report);
            }
            catch (Exception)
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }


        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult ProduccionLactea()
        {
            return View(null);
        }


        [HttpPost]
        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult ProduccionLactea(DateTime Desde, DateTime Hasta)
        {
            try
            {
                ViewData["error"] = String.Empty;
                if (DateTime.Compare(Hasta, DateTime.Now) > 0)
                {
                    ViewData["error"] = "La Fecha debe no debe ser mayor a hoy";
                    return View(null);
                }
                else if (DateTime.Compare(Desde, Hasta) > 0)
                {
                    ViewData["error"] = "La Fecha de Inicio debe ser menor a la Fecha Final";
                    return View(null);
                }
                else if (DateTime.Compare(Desde, new DateTime(0001, 1, 1, 00, 00, 00)) == 0)
                {
                    ViewData["error"] = "Debe indicar una fecha para Desde valida";
                    return View(null);
                }
                else if (DateTime.Compare(Hasta, new DateTime(0001, 1, 1, 00, 00, 00)) == 0)
                {
                    ViewData["error"] = "Debe indicar una fecha para Hasta valida";
                    return View(null);
                }
                ServiceReport serviceReport = new ServiceReport();
                List<ProductionReport> report = serviceReport.GetDealyProductionFromTo(Desde, Hasta);
                Production average = serviceReport.GetReportProductionAverage(Desde, Hasta);
                ViewData["cows"] = average.Id;
                ViewData["production"] = average.IdBovine;
                ViewData["average"] = average.Output;
                ViewData["from"] = average.Register.ToString("dd-MM-yyyy");
                ViewData["to"] = Convert.ToDateTime(average.Name).ToString("dd-MM-yyyy");
                if (report.Count() <= 0)
                {
                    ViewData["error"] = String.Empty;
                    report = null;
                }
                return View(report);
            }
            catch (Exception)
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }


    }
}
