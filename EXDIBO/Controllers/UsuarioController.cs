using Microsoft.AspNetCore.Mvc;
using EXDIBO.Util;
using EXDIBO.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace EXDIBO.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult IniciarSesion()
        {
            ViewData["ErrorInicio"] = String.Empty;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(User user)
        {
            if (user.Email.Length >= 6 && user.Password.Length > 6)
            {
                try
                {
                    ViewData["ErrorInicio"] = String.Empty;
                    string AESEncript = new AESCryptography().Encrypt(user.Password);
                    User _user = new ServiceUser().GetValidateUser(user.Email, AESEncript);
                    if (_user != null)
                    {
                        if (Convert.ToBoolean(_user.Status))
                        {
                            var Claims = new List<Claim>() {
                            new Claim(ClaimTypes.Sid, _user.Id.ToString()),
                            new Claim(ClaimTypes.Name, _user.Name),
                            new Claim(ClaimTypes.UserData, _user.FirstName),
                            new Claim(ClaimTypes.Email, _user.Email),
                            new Claim(ClaimTypes.Role, _user.Role),
                            new Claim(ClaimTypes.Gender, _user.Gender)
                        };
                            var claimsIdentity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                            return RedirectToAction("Portada", "Expediente");
                        }
                        else
                        {
                            return RedirectToAction("AccesoInactivo", "Usuario");
                        }
                    }
                    else
                    {
                        ViewData["ErrorInicio"] = "El Usuario y/o Contraseña son invalidos";
                        return View();
                    }
                }
                catch (Exception)
                {
                    ViewData["ErrorInicio"] = "Uppps! Algo va mal!....";
                    return RedirectToAction("IniciarSesion", "Usuario");
                }
            }
            ViewData["ErrorInicio"] = "El Usuario y/o Contraseña es invalido";
            return View();
        }

        [Authorize(Roles = "0,1,2")]
        public IActionResult ListaUsuarios()
        {
            List<User> users = new ServiceUser().GetAllUsers();
            return View(users);
        }


        [Authorize(Roles = "0,1,2")]
        public IActionResult Nuevo()
        {
            ViewData["error"] = String.Empty; 
            return View();
        }


        [Authorize(Roles = "0,1,2")]
        [HttpPost]
        public IActionResult Nuevo(User user, string confirmar)
        {

            if (confirmar == null || user.Password == null) 
            {
                ViewData["error"] = "La Contraseña no tiene ocho caracteres de seguridad requeridos";
                return View(user);
            } 
            else if (user.Password != confirmar || user.Password == "" || user.Password == " " || (user.Password.Length) <= 7)
            {
                ViewData["error"] = "La Contraseña no cumple con los requerimientos mínimos de seguridad";
                return View(user);
            }
            else if (user.DNI.Length <= 8)
            {
                ViewData["error"] = "Por favor indique su Identificación de la siguiente manera 203210456";
                return View(user);

            } else if (user.Name.Trim() == " " || user.Name.Length <= 2)
            {
                ViewData["error"] = "Por favor indique un Nombre válido";
                return View(user);
            }
            else if (user.FirstName.Trim() == "" || user.FirstName == " " || user.FirstName.Length < 2)
            {
                ViewData["error"] = "Por favor indique un Apellido válido";
                return View(user);
            }
            else if (user.Email.Length <= 6 || user.Email.Trim() == " ")
            {
                ViewData["error"] = "Por favor indique un Correo Electronico válido";
                return View(user);
            }
            else if (user.Code < 999)
            {
                ViewData["error"] = "Por favor indique un Número de usuario válido ";
                return View(user);
            }
            else if (user.Mobile == "" || user.Mobile == " " || user.Mobile.Length <= 7)
            {
                ViewData["error"] = "Por favor indique mínimo un número teléfonico válido";
                return View(user);
            }
            user.Id = 0;
            user.RegisterDate = DateTime.Now;
            user.Status = true;
            user.Token = "0000";
            string encrypt = user.Password;
            user.Password = new AESCryptography().Encrypt(encrypt);
            bool respuesta = new ServiceUser().SaveUser(user);
            if (respuesta)
            {
                return RedirectToAction("ListaUsuarios");
            }
            else
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }


        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        [HttpGet]
        public IActionResult EditarPerfil(int Id)
        {
            int userNow = Convert.ToInt32(User.FindFirst(ClaimTypes.Sid).Value);
            if (userNow == Id)
            {
                User usuario = new ServiceUser().GetUserById(Id);
                usuario.Password = new AESCryptography().Decrypt(usuario.Password);
                return View("EditarUsuario", usuario);
            }
            else
            {
                return RedirectToAction("AccesoDenegado", "Expediente");
            }
        }


        [Authorize(Roles = "0,1,2")]
        [HttpGet]
        public IActionResult EditarUsuario(int Id)
        {
            int userNow = Convert.ToInt32(User.FindFirst(ClaimTypes.Sid).Value);
            int userRole = Convert.ToInt32(User.FindFirst(ClaimTypes.Role).Value);
            if (userRole <= 2 || userNow == Id)
            {
                User usuario = new ServiceUser().GetUserById(Id);
                usuario.Password = new AESCryptography().Decrypt(usuario.Password);
                return View(usuario);
            }
            else
            {
                return RedirectToAction("AccesoDenegado", "Expediente");
            }
        }


        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        [HttpPost]
        public IActionResult EditarUsuario(User user, string confirmar)
        {
            try
            {
                if (confirmar == null || user.Password == null)
                {
                    ViewData["error"] = "La Contraseña no tiene ocho caracteres de seguridad requeridos";
                    return View(user);
                }
                else if (user.Password != confirmar || user.Password == "" || user.Password == " " || (user.Password.Length) <= 7)
                {
                    ViewData["error"] = "La Contraseña no cumple con los requerimientos mínimos de seguridad";
                    return View(user);
                }
                else if (user.DNI.Length <= 8)
                {
                    ViewData["error"] = "Por favor indique su Identificación de la siguiente manera 203210456";
                    return View(user);

                }
                else if (user.Name.Trim() == " " || user.Name.Length <= 2)
                {
                    ViewData["error"] = "Por favor indique un Nombre válido";
                    return View(user);
                }
                else if (user.FirstName.Trim() == "" || user.FirstName == " " || user.FirstName.Length < 2)
                {
                    ViewData["error"] = "Por favor indique un Apellido válido";
                    return View(user);
                }
                else if (user.Email.Length <= 6 || user.Email.Trim() == " ")
                {
                    ViewData["error"] = "Por favor indique un Correo Electronico válido";
                    return View(user);
                }
                else if (user.Code < 999)
                {
                    ViewData["error"] = "Por favor indique un Número de usuario válido ";
                    return View(user);
                }
                else if (user.Mobile == "" || user.Mobile == " " || user.Mobile.Length <= 7)
                {
                    ViewData["error"] = "Por favor indique mínimo un número teléfonico válido";
                    return View(user);
                } 
                string desencrypt = user.Password;
                user.Password = new AESCryptography().Encrypt(desencrypt);
                user.Token = String.Empty;
                bool respuesta = new ServiceUser().EditUser(user);

                if (respuesta)
                {
                    if (user.Role == "0" || user.Role == "1" || user.Role == "2")
                    {
                        return RedirectToAction("ListaUsuarios", "Usuario");
                    }
                    else {
                        return Redirect("/Usuario/DetallesUsuario/" + user.Id);
                    }
                }
                else
                {
                    return RedirectToAction("ProblemasConexion", "Expediente");
                }
            }
            catch (Exception)
            {
                return View(user);
            }
        }


        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        [HttpGet]
        public IActionResult DetallesUsuario(int Id)
        {
            int userNow = Convert.ToInt32(User.FindFirst(ClaimTypes.Sid).Value);
            int userRole = Convert.ToInt32(User.FindFirst(ClaimTypes.Role).Value);
            if (userRole <= 2 || userNow == Id)
            {
                User usuario = new ServiceUser().GetUserById(Id);
                if (usuario != null)
                {
                    return View(usuario);
                }
                else 
                {
                    return View(null);
                }
            }
            else
            {
                return RedirectToAction("AccesoDenegado", "Expediente");
            }
        }

        [Authorize(Roles = "0,1,2")]
        public IActionResult QuitarUsuario(int Id, bool Status)
        {
            bool result = new ServiceUser().ChangeStatusUser(Id, Status);
            if (result)
            {
                return RedirectToAction("ListaUsuarios", "Usuario");
            }
            else
            {
                return RedirectToAction("ProblemasConexion", "Expediente");
            }
        }


        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("IniciarSesion", "Usuario");
        }


        public IActionResult AccesoInactivo()
        {
            return View();
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult AccesoDenegado()
        {
            return View();
        }

        [Authorize(Roles = "0,1,2,3,4,5,6,7,8,9")]
        public IActionResult VerRoles()
        {
            return View();
        }
         

    }
}
