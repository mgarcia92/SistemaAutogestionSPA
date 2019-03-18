using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSPAGestionEmpleados.Helpers;
using WebSPAGestionEmpleados.Models;
using WebSPAGestionEmpleados.Repository;

namespace WebSPAGestionEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionDataController : ControllerBase
    {
        AUTO_GESTION2Context _context = null;
        GenericRepository<AUTO_GESTION2Context> _repository = null;
        public ConfiguracionDataController(AUTO_GESTION2Context Dbcontext)
        {
            _context = Dbcontext;
            _repository = new GenericRepository<AUTO_GESTION2Context>(_context);

        }
        // GET: api/ConfiguracionData
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpPost("[action]")]
        public Utilies.ResponseResult SaveUsuario([FromBody]  Usuarios usuarios)
        {
            try
            {
                dynamic data = new ExpandoObject();
                data.save = false;
                using (_repository)
                {
                    var usuario = _repository.model.Usuarios.Where(x => x.CedulaNbr == usuarios.CedulaNbr).FirstOrDefault();
                    if (usuario != null)
                    {
                        usuario.RoleCd = usuarios.RoleCd;
                        usuario.ActivoFg = usuarios.ActivoFg;
                        int value = _repository.Modificar<Usuarios>(usuario);
                        if (value > 0)
                            data.save = !data.save;

                        return Utilies.ResponseResult.GetResponse("", TypeResponse.Succes, data);
                    }               
                    else
                    {
                        return Utilies.ResponseResult.GetResponse("", TypeResponse.Warning, data);
                    }
                }
            }
            catch (Exception ex)
            {
                return Utilies.ResponseResult.GetResponse(ex.Message, TypeResponse.Error, new object[0]);
            }
        }

        [HttpPost("[action]")]
        public Utilies.ResponseResult SaveFuncion([FromBody]  Roles funciones)
        {
            try
            {
                dynamic data = new ExpandoObject();
                data.save = false;
                using (_repository)
                {
                    var funcion = _repository.model.Roles.Where(x => x.RoleCd == funciones.RoleCd).FirstOrDefault();
                    if (funcion != null)
                    {
                        funcion.RoleCd = funciones.RoleCd;
                        funcion.RoleDesc = funciones.RoleDesc;
                        funcion.ActivoFg = funcion.ActivoFg;
                        int value = _repository.Modificar<Roles>(funcion);
                        if (value > 0)
                            data.save = !data.save;

                        return Utilies.ResponseResult.GetResponse("", TypeResponse.Succes, data);
                    }
                    else
                    {
                        return Utilies.ResponseResult.GetResponse("", TypeResponse.Warning, data);
                    }
                }
            }
            catch (Exception ex)
            {
                return Utilies.ResponseResult.GetResponse(ex.Message, TypeResponse.Error, new object[0]);
            }
        }



        [HttpGet("[action]")]
        public Utilies.ResponseResult GetRolAutocomplete()
        {
            try
            {
                using (_context)
                {
                    IEnumerable<string> query = _context.Roles.Select(x => x.RoleCd).ToList<string>();

                    if (query.Count() > 0)
                    {
                        return Utilies.ResponseResult.GetResponse("", TypeResponse.Succes, query);
                    }
                    else
                    {
                        return Utilies.ResponseResult.GetResponse("", TypeResponse.Warning, new object[0]);
                    }
                }
            }
            catch (Exception ex)
            {
               return Utilies.ResponseResult.GetResponse(ex.Message, TypeResponse.Error, new object[0]);
            }
        }


        [HttpGet("[action]")]
        public Utilies.ResponseResult GetUsuariosInfo(string cedula)
        {
            try
            {
                using (_context)
                {
                    
                    var data = (from us in _context.Usuarios
                                join md in _context.MaestroDatos
                                    on new { us.CiaCd, us.CedulaNbr } equals new { md.CiaCd, md.CedulaNbr }
                                where md.ParentescoNbr == 0
                                orderby us.CedulaNbr
                                select new
                                {
                                    us.CedulaNbr,
                                    us.RoleCd,
                                    md.FichaNm,
                                    us.ActivoFg,
                                    //ActivoDesc = ""
                                    ActivoDesc = _context.Tablas.Where(x => x.TablaNbr.Equals(901) && x.ItemNbr.Equals(Int32.Parse(us.ActivoFg.ToString()))).Select(x => x.TablaDesc).FirstOrDefault()
                                    //ActivoDesc = _context.Tablas.Where(x => x.TablaNbr.Equals(901) && x.ItemNbr.Equals(us.ActivoFg)).Select(x => x.TablaDesc).FirstOrDefault()
                                }).ToList();

                    if (data.Count > 0)
                    {
                        return Utilies.ResponseResult.GetResponse("", TypeResponse.Succes, data);
                    }
                    else
                    {
                        return Utilies.ResponseResult.GetResponse("", TypeResponse.Warning, new object[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                return Utilies.ResponseResult.GetResponse(ex.Message, TypeResponse.Error, new object[0]);
            }
        }

        [HttpGet("[action]")]
        public Utilies.ResponseResult GetEstatusInfo(string estatu)
        {
            try
            {
                using (_context)
                {

                    var data2 = (from ta in _context.Tablas
                                where ta.TablaNbr == 901
                                orderby ta.ItemNbr
                                select new
                                {
                                    ta.ItemNbr,
                                    ta.TablaDesc
                                }).ToList();

                    if (data2.Count > 0)
                    {
                        return Utilies.ResponseResult.GetResponse("", TypeResponse.Succes, data2);
                    }
                    else
                    {
                        return Utilies.ResponseResult.GetResponse("", TypeResponse.Warning, new object[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                return Utilies.ResponseResult.GetResponse(ex.Message, TypeResponse.Error, new object[0]);
            }
        }

        public Utilies.ResponseResult GetFuncionesInfo()
        {
            try
            {
                using (_context)
                {
                    
                    var data = (from ro in _context.Roles
                                orderby ro.RoleCd   
                                select new
                                {
                                    ro.RoleCd,
                                    ro.RoleDesc,
                                    ro.ActivoFg
                                }).ToList();


                    if (data.Count > 0)
                    {
                        return Utilies.ResponseResult.GetResponse("", TypeResponse.Succes, data);
                    }
                    else
                    {
                        return Utilies.ResponseResult.GetResponse("", TypeResponse.Warning, new object[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                return Utilies.ResponseResult.GetResponse(ex.Message, TypeResponse.Error, new object[0]);
            }
        }

        //// GET: api/ConfiguracionData/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/ConfiguracionData
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/ConfiguracionData/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
