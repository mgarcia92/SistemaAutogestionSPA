using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSPAGestionEmpleados.Helpers;
using WebSPAGestionEmpleados.Models;


namespace WebSPAGestionEmpleados.Controllers
{
    [Route("api/[controller]")]
    public class LoginApiController : Controller
    {
        AUTO_GESTION2Context _context = null;

        public LoginApiController(AUTO_GESTION2Context Dbcontext)
        {
            _context = Dbcontext;
        }

        [HttpGet("[action]")]
        public Utilies.ResponseResult SessionStatus(string username)
        {
            object user = (Usuarios)Utilies.DeserializeJson<Usuarios>(HttpContext.Session.GetString(username.ToLower()));
            if (user != null)
            {
              return  Utilies.ResponseResult.GetResponse("Session Active", TypeResponse.Succes, new { session = true });
            }
            return Utilies.ResponseResult.GetResponse("Session Inactive", TypeResponse.Succes, new { session = false });
        }


        [HttpGet("[action]")]
        public Utilies.ResponseResult GetInfoSession(string username)
        {
            object user = Utilies.DeserializeJson<Usuarios>(HttpContext.Session.GetString(username.ToLower()));
            if (user != null)
            {
                return Utilies.ResponseResult.GetResponse("", TypeResponse.Succes, user);
            }
            return Utilies.ResponseResult.GetResponse("Session Inactive", TypeResponse.Succes, new {});
        }

        [HttpGet("[action]")]
        public Utilies.ResponseResult Logout(string username)
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove(username.ToLower());
            string user = HttpContext.Session.GetString(username.ToLower());
            if (string.IsNullOrEmpty(user))
            {
               return  Utilies.ResponseResult.GetResponse("Session empty", TypeResponse.Succes, new { session = true });
            }

            return Utilies.ResponseResult.GetResponse("Session alive", TypeResponse.Succes, new { session = false });
        }


        [HttpPost("[action]")]
        public Utilies.ResponseResult Logon([FromBody] Usuarios login)
        {
            try
            {
               
                  
                if (!string.IsNullOrEmpty(login.LoginUsr) && !string.IsNullOrEmpty(login.LoginPwd))
                {
                    using (_context)
                    {
                      var  data = ( from user in _context.Usuarios
                                    join ma in _context.MaestroDatos on user.CedulaNbr equals ma.CedulaNbr
                                    where user.LoginUsr == login.LoginUsr.Trim() && user.LoginPwd == login.LoginPwd.Trim()
                                    select new {
                                        user.LoginUsr,
                                        user.CedulaNbr,
                                        user.FotoImg,
                                        user.CreaDate,
                                        user.CiaCd,
                                        ma.FichaCd,
                                        ma.FichaNm,
                                        ma.RifNbr,
                                        ma.RifTipo,
                                        ma.CuentaBco,
                                        ma.EmailTxt
                                    }).ToList();

                        if (data.Count > 0)
                        {
                            string userJson = Utilies.ObjectToJson(data[0]);
                            HttpContext.Session.SetString(data[0].LoginUsr.ToLower(), userJson);
                            return Utilies.ResponseResult.GetResponse("",TypeResponse.Succes, data); 
                        }

                        return Utilies.ResponseResult.GetResponse("Usuario o Password Incorrectos", TypeResponse.Warning, data);

                    }
                }
                return Utilies.ResponseResult.GetResponse("Data Empty", TypeResponse.Warning, new object[0]);
            }
            catch (Exception ex)
            {
                return Utilies.ResponseResult.GetResponse(ex.Message, TypeResponse.Error, new object[0]);
            }
        }
    }

}