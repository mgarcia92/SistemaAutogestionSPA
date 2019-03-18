using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSPAGestionEmpleados.Helpers;
using WebSPAGestionEmpleados.Models;
using WebSPAGestionEmpleados.ModelsApi;
using WebSPAGestionEmpleados.Repository;

namespace WebSPAGestionEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasDataController : ControllerBase
    {
        // GET: api/EmpresasData
        AUTO_GESTION2Context _context = null;
        GenericRepository<AUTO_GESTION2Context> _repository = null;

        public EmpresasDataController(AUTO_GESTION2Context Dbcontext)
        {
            _context = Dbcontext;
            _repository = new GenericRepository<AUTO_GESTION2Context>(_context);
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("[action]")]
        public Utilies.ResponseResult SaveNivel([FromBody]  NivelApi nivelApi)
        {
            try
            {
                List<KeyValuePair<string, int>> data = new List<KeyValuePair<string, int>>();
                using (_repository)
                {
                    if (nivelApi.FichaCd.Length > 0)
                    {
                        foreach (var ficha in nivelApi.FichaCd)
                        {
                            var maestro = _repository.model.Maestro.Where(x => x.FichaCd == ficha).FirstOrDefault();
                            maestro.NivelNbr = nivelApi.NivelNbr;
                            maestro.NivelOrg = nivelApi.NivelOrg;
                            int value = _repository.Modificar(maestro);
                            data.Add(new KeyValuePair<string, int>(ficha, value));
                        }

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

        [HttpPost("[action]")]
        public Utilies.ResponseResult SaveUsuario([FromBody]  UsuarioApi usuarioApi)
        {
            try
            {
                List<KeyValuePair<string, int>> data = new List<KeyValuePair<string, int>>();
                using (_repository)
                {
                    if (usuarioApi.CedulaNbr.Length > 0)
                    {
                        foreach (var cedula in usuarioApi.CedulaNbr)
                        {
                            var usuario = _repository.model.Usuarios.Where(x => x.CedulaNbr == cedula).FirstOrDefault();
                            usuario.RoleCd = usuarioApi.RoleCd;
                            int value = _repository.Modificar(usuario);
                            data.Add(new KeyValuePair<string, int>(cedula, value));
                        }

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

    }
}
