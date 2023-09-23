using EXDIBO.Models;
using EXDIBO.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EXDIBO.Controllers
{
    public class AnimalController : Controller
    {

        [Authorize(Roles = "0,1,2,4,5,6")]
        public IActionResult Animal()
        {
            ServiceFarm serviceFarm = new();
            ServiceAnimal serviceAnimal = new();
            List<Group> groups = serviceFarm.GetAllGroup();
            List<Farm> farms = serviceFarm.GetAllFarm();
            List<Breed> breeds = serviceAnimal.GetBreeds();
            ViewData["farms"] = farms;
            ViewData["groups"] = groups;
            ViewData["breeds"] = breeds;
            ViewData["number"] = serviceAnimal.SuggestedNumber();
            return View();
        }


        [Authorize(Roles = "0,1,2,4,5,6")]
        [HttpPost]
        public IActionResult Animal(Bovine bovine)
        {

            try
            {
                if (bovine != null)
                {
                    bool error = false;
                    string msgerror = string.Empty;
                    ServiceAnimal serviceAnimal = new();
                    if (bovine.Number < 1)
                    {
                        error = true;
                        msgerror = msgerror + "Número de res invalido. ";
                    }
                    Bovine animal = serviceAnimal.GetBovineByNumber(Convert.ToInt32(bovine.Number));
                    if (animal != null)
                    {
                        error = true;
                        msgerror = msgerror + "El número de res ya existe. ";
                    }
                    if (bovine.IdMother != null)
                    {
                        Bovine madre = serviceAnimal.GetByAnimalId(Convert.ToInt32(bovine.IdMother));
                        if (madre == null)
                        {
                            error = true;
                            msgerror = msgerror + "El número de Madre no existe. ";

                        }
                        if (madre != null)
                        {
                            if (madre.Gender == "Macho")
                            {
                                error = true;
                                msgerror = msgerror + "El número de Madre pertenece a un Toro. ";
                            }
                        }
                        madre = null;
                    }
                    else
                    {
                        error = true;
                        msgerror = msgerror + "Por favor indique el número de la Madre. ";
                    }

                    Bovine padre = serviceAnimal.GetByAnimalId(Convert.ToInt32(bovine.IdFather));
                    if (padre == null)
                    {
                        error = true;
                        msgerror = msgerror + "El número de Padre no existe. ";

                    }
                    if (padre != null)
                    {
                        if (padre.Gender == "Hembra")
                        {
                            error = true;
                            msgerror = msgerror + "El número de Padre pertenece a un Vaca. ";
                        }
                    }
                    padre = null;

                    if (bovine.Earring == null)
                    {
                        error = true;
                        msgerror = msgerror + "El Arete de la Res es invalido. ";

                    }
                    if (bovine.Name == null)
                    {
                        error = true;
                        msgerror = msgerror + "El Nombre de la res es invalido. ";
                    }
                    if (bovine.IdMother < 1)
                    {
                        error = true;
                    }
                    else if (bovine.IdFather < 1)
                    {
                        error = true;
                    }
                    else if (bovine.Notes == null)
                    {
                        bovine.Notes = String.Empty;
                    }
                    else if (bovine.Brand == null)
                    {
                        bovine.Brand = String.Empty;
                    }
                    if (error)
                    {
                        ServiceFarm serviceFarm = new ServiceFarm();
                        List<Group> groups = serviceFarm.GetAllGroup();
                        List<Farm> farms = serviceFarm.GetAllFarm();
                        List<Breed> breeds = new ServiceAnimal().GetBreeds();
                        ViewData["farms"] = farms;
                        ViewData["groups"] = groups;
                        ViewData["breeds"] = breeds;
                        ViewData["error"] = msgerror;
                        return View(bovine);
                    }
                    else
                    {
                        ServiceAnimal service = new();

                        bool rest = service.SaveBovine(bovine);
                        bool num = service.UpdateBovineBirth(Convert.ToInt32(bovine.IdMother));
                        if (rest)
                        {
                            ServiceFarm serviceFarm = new ServiceFarm();
                            ServiceAnimal serviceAnimalnew = new();
                            List<Group> groups = serviceFarm.GetAllGroup();
                            List<Farm> farms = serviceFarm.GetAllFarm();
                            List<Breed> breeds = serviceAnimal.GetBreeds();
                            ViewData["farms"] = farms;
                            ViewData["groups"] = groups;
                            ViewData["breeds"] = breeds;
                            ViewData["number"] = serviceAnimal.SuggestedNumber();
                            ViewData["error"] = "Animal Registrado Correctamente";
                            return View();
                        }
                        else
                        {
                            return RedirectToAction("ProblemasConexion", "Expediente");
                        }
                    }
                }
                else
                {
                    ServiceFarm serviceFarm = new ServiceFarm();
                    List<Group> groups = serviceFarm.GetAllGroup();
                    List<Farm> farms = serviceFarm.GetAllFarm();
                    List<Breed> breeds = new ServiceAnimal().GetBreeds();
                    ViewData["farms"] = farms;
                    ViewData["groups"] = groups;
                    ViewData["breeds"] = breeds;
                    ViewData["error"] = "Digite los datos correctamente";
                    return View(bovine);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }

        //GET: Editar Animal 
        [Authorize(Roles = "0,1,2,4,5,6")]
        [HttpGet]
        public IActionResult EditarAnimal(int id)
        {
            ServiceFarm serviceFarm = new ServiceFarm();
            List<Group> groups = serviceFarm.GetAllGroup();
            List<Farm> farms = serviceFarm.GetAllFarm();
            List<Breed> breeds = new ServiceAnimal().GetBreeds();
            Bovine animal = new ServiceAnimal().GetByAnimalId(id);
            Bovine father = new ServiceAnimal().GetByAnimalId(Convert.ToInt32(animal.IdFather));
            Bovine mother = new ServiceAnimal().GetByAnimalId(Convert.ToInt32(animal.IdMother));
            ViewData["farms"] = farms;
            ViewData["groups"] = groups;
            ViewData["breeds"] = breeds;
            ViewData["namemadre"] = mother.Name;
            ViewData["namepadre"] = father.Name;
            ViewData["nummadre"] = mother.Number;
            ViewData["numpadre"] = father.Number;
            ViewData["genmadre"] = mother.Gender;
            ViewData["genpadre"] = father.Gender;
            return View(animal);
        }

        //GET: Editar Animal 
        [Authorize(Roles = "0,1,2,4,5,6")]
        [HttpPost]
        public IActionResult EditarAnimal(Bovine animal)
        {
            ServiceFarm serviceFarm = new ServiceFarm();
            List<Group> groups = serviceFarm.GetAllGroup();
            List<Farm> farms = serviceFarm.GetAllFarm();
            List<Breed> breeds = new ServiceAnimal().GetBreeds();
            ViewData["farms"] = farms;
            ViewData["groups"] = groups;
            ViewData["breeds"] = breeds;
            bool result = new ServiceAnimal().EditarAnimal(animal);
            if (result)
            {
                return RedirectToAction("ListaAnimales", "Animal");
            }
            else
            {
                return View(animal);
            }
        }

        //GET: Editar Animal 
        [Authorize(Roles = "0,1,2,3,4,5,6,8,9")]
        public IActionResult DetallesAnimal(int id)
        {
            try
            {
                Detail animal = new ServiceAnimal().GetBovineDetails(id);
                if (animal != null)
                {
                    return View(animal);
                }
                else
                {
                    return View(null);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }
        //GET: Editar Animal 

        [Authorize(Roles = "0,1,2,4,5,6")]
        public IActionResult QuitarAnimal(int id, bool status)
        {
            ServiceAnimal serviceAnimal = new();
            bool result = serviceAnimal.StatusAnimal(id, status);
            if (result)
            {
                return RedirectToAction("ListaAnimales", "Animal");
            }
            else
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult ListaAnimales()
        {
            try
            {
                List<Bovine> animales = new ServiceAnimal().GetAllBovine();
                return View(animales);
            }
            catch (Exception)
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        [HttpPost]
        public IActionResult ListaAnimales(string clave)
        {
            try
            {
                List<Bovine> animales = new ServiceAnimal().GetBovineByErringOrName(clave);
                return View(animales);
            }
            catch (Exception)
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }


        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Parto()
        {
            return View();
        }



        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Production()
        {
            ServiceFarm serviceFarm = new();
            List<Group> groups = serviceFarm.GetAllGroup();
            List<Farm> farms = serviceFarm.GetAllFarm();
            ViewData["error"] = string.Empty;
            ViewData["farms"] = farms;
            ViewData["groups"] = groups;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Production(Production MilkProduction)
        {

            if (MilkProduction != null)
            {
                ViewData["error"] = string.Empty;
                DateTime hora = DateTime.Now;
                MilkProduction.Register = new DateTime(MilkProduction.Register.Year, MilkProduction.Register.Month, MilkProduction.Register.Day ,hora.Hour,hora.Minute, hora.Second);
                MilkProduction.Status = false;
                ServiceAnimal serviceAnimal = new();
                bool result = serviceAnimal.SaveProduction(MilkProduction);
                bool update = serviceAnimal.UpdateBovineProduction(MilkProduction);
                if (result)
                {
                    if (update)
                    {
                        ServiceFarm serviceFarm = new();
                        List<Group> groups = serviceFarm.GetAllGroup();
                        List<Farm> farms = serviceFarm.GetAllFarm();
                        ViewData["error"] = "Producción Guardada";
                        ViewData["farms"] = farms;
                        ViewData["groups"] = groups;
                        return View();
                    }
                    else
                    {
                        ServiceFarm serviceFarm = new();
                        List<Group> groups = serviceFarm.GetAllGroup();
                        List<Farm> farms = serviceFarm.GetAllFarm();
                        ViewData["error"] = "Debe actualizar la producción a la vaca";
                        ViewData["farms"] = farms;
                        ViewData["groups"] = groups;
                        return View();
                    }

                }
                else
                {
                    return RedirectToAction("ProblemasConexion", "Expediente");
                }
            }
            else
            {
                ViewData["error"] = "Indique datos de Producción Láctea que sean válidos";
                return View(MilkProduction);
            }

        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public JsonResult Res(int id)
        {
            Bovine records = new ServiceAnimal().GetBovineByNumber(id);
            var json = Json("El número digitado no corresponde a ninguna res registrada");
            if (records != null)
            {
                json = Json(records);
            }
            else
            {
                records = new()
                {
                    Name = "El número digitado no corresponde a ninguna res registrada",
                    Earring = "No existe una res con el número anotado",
                    Gender = "Escriba un número válido de res",
                    IdFarm = 1,
                    IdGroup = 1
                };
                json = Json(records);
            }
            return json;
        }


        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public JsonResult ResById(int id)
        {
            Bovine records = new ServiceAnimal().GetByAnimalId(id);
            var json = Json("El número digitado no corresponde a ninguna res registrada");
            if (records.Id > 0)
            {
                json = Json(records);
            }
            else
            {
                records = new()
                {
                    Name = "El número digitado no corresponde a ninguna res registrada",
                    Earring = "No existe una res con el número anotado",
                    Gender = "Escriba un número válido de res",
                    IdFarm = 1,
                    IdGroup = 1
                };
                json = Json(records);
            }
            return json;
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult Razas()
        {
            List<Breed> razas = new ServiceAnimal().GetBreeds();
            return View(razas);
        }

        [Authorize(Roles = "0,1,2,3,4,5,6")]
        public IActionResult Gestacion()
        {
            DateTime hasta = DateTime.Now;
            DateTime desde = hasta.AddMonths(-2);
            List<Reovulation> razas = new ServiceAnimal().GetGestation(desde, hasta);
            return View(razas);
        }


        [Authorize(Roles = "0,1,2,3,4,5,6")]
        public IActionResult EstadoOvulacion(int id, int mother, bool status)
        {
            ServiceAnimal serviceAnimal = new ServiceAnimal();
            bool result = serviceAnimal.UpdateOvulationStatus(id, status);
            bool gest = serviceAnimal.UpdateBovinePregnant(mother, status);

            if (result && gest)
            {
                return RedirectToAction("Gestacion", "Animal");
            }
            else
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }


        [Authorize(Roles = "0,1,2,3,4,5,6")]
        public IActionResult Ovulation()
        {
            ServiceFarm serviceFarm = new ServiceFarm();
            ViewData["farms"] = serviceFarm.GetAllFarm();
            ViewData["groups"] = serviceFarm.GetAllGroup();
            ViewData["breeds"] = new ServiceAnimal().GetBreeds();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "0,1,2,3,4,5,6")]
        public IActionResult Ovulation(Ovulation ovulation)
        {
            ovulation.Status = false;
            ServiceAnimal serviceAnimal = new();
            bool rest = serviceAnimal.SaveOvulation(ovulation);
            bool gestation = serviceAnimal.UpdateBovineOvulation(false, ovulation.Register, Convert.ToInt32(ovulation.IdMother));
            if (rest)
            {
                return RedirectToAction("Portada", "Expediente");
            }
            else
            {
                ServiceFarm serviceFarm = new ServiceFarm();
                ViewData["farms"] = serviceFarm.GetAllFarm();
                ViewData["groups"] = serviceFarm.GetAllGroup();
                ViewData["breeds"] = new ServiceAnimal().GetBreeds();
                return View();
            }
        }


        [Authorize(Roles = "0,1,2,3,4,5,6")]
        public IActionResult ListaProduccion()
        {
            try
            {
                DateTime to = DateTime.Now;
                DateTime from = to.AddMonths(-1);
                List<ProductionReport> productions = new ServiceReport().GetDealyProductionFromTo(from, to);
                ViewData["to"] = to;
                ViewData["from"] = from;
                return View(productions);
            }
            catch (Exception) 
            {
                return RedirectToAction("Error404", "Expediente");
            }
        }

        [Authorize(Roles = "0,1,2,3,4,5,6")]
        [HttpPost]
        public IActionResult ListaProduccion(DateTime fecha)
        {
            try
            {
                DateTime to = DateTime.Now;
                DateTime from = fecha.AddMonths(-1);
                List<ProductionReport> productions = new ServiceReport().GetDealyProductionFromTo(from, to);
                ViewData["to"] = to;
                ViewData["from"] = from;
                return View(productions);
            }
            catch (Exception)
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }

        [Authorize(Roles = "0,1,2,3,4,5,6")]
        [HttpGet]
        public IActionResult DetallesProduccion(int id)
        {
            try
            {
                ProductionReport productions = new ServiceAnimal().GetDealyProductionById(id);
                return View(productions);
            }
            catch (Exception)
            {
                return RedirectToAction("Error404", "Expediente");
            }
        }

        [Authorize(Roles = "0,1,2,3,4,5,6")]
        [HttpGet]
        public IActionResult EditarProduccion(int id)
        {
            try
            {
                ProductionReport productions = new ServiceAnimal().GetDealyProductionById(id);
                return View(productions);
            }
            catch (Exception)
            {
                return RedirectToAction("Error404", "Expediente");
            }
        }

        [Authorize(Roles = "0,1,2,3,4,5,6")]
        [HttpPost]
        public IActionResult EditarProduccion(ProductionReport production)
        {
            try
            {
                bool result = new ServiceAnimal().UpdateBovineProduction(production);
                if (result)
                {
                    return RedirectToAction("DetallesProduccion", "Expediente", production.Id);
                }
                else 
                {
                    return RedirectToAction("ProblemasConexion", "Expediente");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error404", "Expediente");
            }
        }


        [Authorize(Roles = "0,1,2,3,4,5,6")]
        [HttpGet]
        public IActionResult EstadoProduccion(int id, bool status) 
        {
            try
            {
                bool resul = new ServiceAnimal().EstadoProduccion(id, status);
                if (resul)
                {
                    return RedirectToAction("ListaProduccion", "Animal");
                }
                else
                {
                    return RedirectToAction("ProblemasConexion", "Expediente");
                }
            }
            catch (Exception) {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }


    }
}
