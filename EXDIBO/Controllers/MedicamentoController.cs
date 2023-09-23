using Microsoft.AspNetCore.Mvc;
using EXDIBO.Models;
using EXDIBO.Util;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace EXDIBO.Controllers
{
    public class MedicamentoController : Controller
    {
        // GET: MedicamentoController
        [Authorize(Roles = "0,1,2,4,5")]
        public ActionResult Farmaco()
        {
            ViewData["kinds"] = new ServiceMedicine().GetKindMedicine();
            return View();
        }

        // POST: MedicamentoController
        [Authorize(Roles = "0,1,2,4,5")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Farmaco(Medicine medicine)
        {
            ServiceMedicine service = new ServiceMedicine();

            bool result = service.SaveMedicine(medicine);

            if (result)
            {
                return RedirectToAction("Farmaceuticos", "Medicamento");
            }
            else
            {
                ViewData["kinds"] = new ServiceMedicine().GetKindMedicine();
                return View();
            }
        }


        [Authorize(Roles = "0,1,2,4,5,6,7,9")]
        public ActionResult Farmaceuticos()
        {
            List<Medicine> medicaments = new ServiceMedicine().GetAllMedicine();
            return View(medicaments);
        }

        // GET: MedicamentoController/Details/5
        [Authorize(Roles = "0,1,2,4,5,6,7,9")]
        public ActionResult DetallesFarmaco(int id)
        {
            Medicine medicine = new ServiceMedicine().GetMedicineById(id);
            return View(medicine);
        }


        // GET: MedicamentoController/Edit/5
        [Authorize(Roles = "0,1,2,4,5")]
        public ActionResult EditarFarmaco(int id)
        {
            Medicine medicine = new ServiceMedicine().GetMedicineById(id);
            ViewData["kinds"] = new ServiceMedicine().GetKindMedicine();
            return View(medicine);
        }

        // POST: MedicamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "0,1,2,4,5")]
        public ActionResult EditarFarmaco(Medicine medicine)
        {
            try
            {
                bool result = new ServiceMedicine().EditMedicine(medicine);
                if (result)
                {
                    return RedirectToAction("Farmaceuticos", "Medicamento");
                }
                else 
                {
                    ViewData["kinds"] = new ServiceMedicine().GetKindMedicine();
                    return View(medicine);
                }
            }
            catch
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }



        // GET: MedicamentoController/EstadoFarmaco/5
        [Authorize(Roles = "0,1,2,4,5")]
        [HttpGet]
        public ActionResult EstadoFarmaco(int id, bool status)
        {
            bool result = new ServiceMedicine().StatusMedicine(id, status);
            if (result)
            {
                return RedirectToAction("Farmaceuticos", "Medicamento");
            }
            else
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }


        // GET: MedicamentoController/MedicineRecord/
        [Authorize(Roles = "0,1,2,4,5")]
        public ActionResult AplicarMedicamento() // Crear un Historial Medico
        {
            ViewData["medicamento"] = new ServiceMedicine().GetAllActiveMedicine();
            ViewData["enfermedad"] = new ServiceMedicine().GetAllIllness();
            return View();
        }
       
        //POST: MedicamentoController/MedicineRecord/MedicamentoController/
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "0,1,2,4,5")]
        public ActionResult AplicarMedicamento(MedicineRecord diagnostico)  // Guardar el Historial Medico
        {
            try
            {
                diagnostico.IdUser = Convert.ToInt32( User.FindFirst(ClaimTypes.Sid).Value);
                diagnostico.Status = true;

                string error = String.Empty;

                if (diagnostico.IdMedicine != null)
                {
                    Medicine medicine = new ServiceMedicine().GetMedicineById(Convert.ToInt32(diagnostico.IdMedicine));
                    diagnostico.IdKind = medicine.IdKind;
                }
                else 
                {
                    ViewData["idmedicine"] = "Seleccione un medicamento. ";
                }

                if (diagnostico.IdBovine == null) {
                    ViewData["Idbovine"] = "Indique un número de animal válido. ";
                }

                if (diagnostico.Notes == null) {
                    diagnostico.Notes = "";
                }
                if (diagnostico.Symptom == null) 
                {
                    diagnostico.Symptom = "";
                }

                bool result = new ServiceMedicine().SaveMedicineRecord(diagnostico);
                if (result)
                {
                    return RedirectToAction("VerRegistros", "Medicamento");   
                }
                else
                {
                    ViewData["medicamento"] = new ServiceMedicine().GetAllActiveMedicine();
                    ViewData["enfermedad"] = new ServiceMedicine().GetAllIllness();
                    return View();
                }
            }
            catch (Exception) 
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }

        }


        [Authorize(Roles = "0,1,2,4,5,6,7,9")]
        public ActionResult TipoFarmaco()
        {
            List<Kind> records = new ServiceMedicine().GetKindMedicine();

            return View(records);
        }


        [Authorize(Roles = "0,1,2,4,5,6,7,9")]
        public ActionResult VerRegistros()
        {
            return View();
        }

        [Authorize(Roles = "0,1,2,4,5,6,7,9")]
        public ActionResult RegistroAnimal()
        {
            //List<Record> records = new ServiceMedicine().GetRecordByBovine(110);
            @ViewData["error"] = string.Empty;
            return View(null);
        }

        [Authorize(Roles = "0,1,2,4,5,6,7,9")]
        [HttpPost]
        public ActionResult RegistroAnimal(int animal)
        {
            List<Record> records = new ServiceMedicine().GetRecordByBovine(animal);
            return View(records);
        }


        [Authorize(Roles = "0,1,2,4,5,6,7,9")]
        public ActionResult RegistroPorFecha()
        {
            //List<Record> records = new ServiceMedicine().GetRecordByBovine(32);
            @ViewData["error"] = string.Empty;
            return View(null);
        }

        [Authorize(Roles = "0,1,2,4,5,6,7,9")]
        [HttpPost]
        public IActionResult RegistroPorFecha(DateTime Desde, DateTime Hasta)
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

            DateTime fecha = new DateTime(Hasta.Year, Hasta.Month, Hasta.Day, 23, 59, 59);

            List<Record> records = new ServiceMedicine().GetRecordByDate(Desde, fecha);
            return View(records);
        }


        [Authorize(Roles = "0,1,2,4,5,6,7,9")]
        public ActionResult RegistroPorUsuario()
        {
            //List<Record> records = new ServiceMedicine().GetRecordByBovine(32);
            @ViewData["error"] = string.Empty;
            return View(null);
        }


        [Authorize(Roles = "0,1,2,4,5,6,7,9")]
        [HttpPost]
        public ActionResult RegistroPorUsuario(int code)
        {
            List<Record> records = new ServiceMedicine().GetRecordByUser(code);
            return View(records);
        }


        [Authorize(Roles = "0,1,2,4,5,6,7,9")]
        [HttpGet]
        public ActionResult DetalleExpediente (int id)
        {
            Record records = new ServiceMedicine().GetRecordById(id);
            return View(records);
        } 

    }
}
