using System;
using System.Collections.Generic;
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
    public class TrabajadorDataController : ControllerBase
    {
        AUTO_GESTION2Context _context = null;
        GenericRepository<AUTO_GESTION2Context> _repository = null;
        public TrabajadorDataController(AUTO_GESTION2Context Dbcontext)
        {
            _context = Dbcontext;
           //_repository = new GenericRepository<AUTO_GESTION2Context>(_context);
           // List<Maestro> lista = new List<Maestro>();
           // foreach (var maestro in lista)
           // {
           //     // var maestro = _repository.model.Maestro.Where(x => x.FichaCd == "miguel").FirstOrDefault();
           //     maestro.NivelNbr = 10;
           //     _repository.Modificar<Maestro>(maestro);
           // }

        }
        // GET: api/TrabajadorData
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("[action]")]
        public Utilies.ResponseResult GetPersonalInfo(string ficha)
        {
            try
            {
                using (_context)
                {
                    var data = (from ma in _context.Maestro
                                join da in _context.MaestroDatos on ma.FichaCd equals da.FichaCd
                                join user in _context.Usuarios on da.CedulaNbr equals user.CedulaNbr
                                where da.FichaCd == ficha && da.ParentescoNbr == 0
                                select new {
                                    da.FichaCd,
                                    da.CedulaNbr,
                                    da.FichaNm,
                                    da.NacimientoDate,
                                    da.EmailTxt,
                                    edoCivil = _context.Tablas.Where(x => x.TablaNbr.Equals(3) && x.ItemNbr.Equals(da.EdocivilNbr)).Select(x => x.TablaDesc).FirstOrDefault(),
                                    profesion = _context.Tablas.Where(x => x.TablaNbr.Equals(10) && x.ItemNbr.Equals(da.ProfesionNbr)).Select(x => x.TablaDesc).FirstOrDefault(),
                                    sexo = _context.Tablas.Where(x => x.TablaNbr.Equals(2) && x.ItemNbr.Equals(da.SexoNbr)).Select(x => x.TablaDesc).FirstOrDefault()
                                }).ToList();

                    if (data.Count > 0)
                    {
                        return Utilies.ResponseResult.GetResponse("", TypeResponse.Succes, data[0]);
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
        public Utilies.ResponseResult GetEmpresasInfo(string ficha)
        {
            try
            {
                using (_context)
                {
                    var data = (from ma in _context.Maestro
                                join da in _context.MaestroDatos on ma.FichaCd equals da.FichaCd
                                where da.FichaCd == ficha && da.ParentescoNbr == 0
                                select new
                                {
                                    da.FichaCd,
                                    departamento = _context.Departamentos.Where(x => x.DptoCd == ma.DptoCd).Select(x => x.DptoDesc).FirstOrDefault(),
                                    ma.Sueldo3Sal,
                                    sueldoMen = ma.Sueldo3Sal * 30,
                                    ma.IngresoDate,
                                    jefe = _context.MaestroDatos.Where(x => x.FichaCd == ma.JefeCd && x.ParentescoNbr == 0).Select(x => x.FichaNm).FirstOrDefault(),
                                    cargo = _context.Cargos.Where(x => x.CargoCd.Equals(ma.CargoCd)).Select(x => x.CargoDesc).FirstOrDefault(),
                                }).ToList();

                    if (data.Count > 0)
                    {
                        return Utilies.ResponseResult.GetResponse("", TypeResponse.Succes, data[0]);
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
        public Utilies.ResponseResult GetFamiliarInfo(string ficha)
        {
            try
            {
                using (_context)
                {
                    var data = (from ma in _context.MaestroDatos
                                where ma.FichaCd == ficha && ma.ParentescoNbr != 0
                                select new
                                {
                                    ma.CedulaNbr,
                                    ma.FichaNm,
                                    parentesco = _context.Tablas.Where(x => x.TablaNbr.Equals(5) && x.ItemNbr.Equals(ma.ParentescoNbr)).Select(x => x.TablaDesc).FirstOrDefault(),
                                    ma.NacimientoDate,
                                    sexo = _context.Tablas.Where(x => x.TablaNbr.Equals(2) && x.ItemNbr.Equals(ma.SexoNbr)).Select(x => x.TablaDesc).FirstOrDefault(),
                                    edoCivil = _context.Tablas.Where(x => x.TablaNbr.Equals(3) && x.ItemNbr.Equals(ma.EdocivilNbr)).Select(x => x.TablaDesc).FirstOrDefault()
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
        public Utilies.ResponseResult GetAumentosSalInfo(string ficha)
        {
            try
            {
                using (_context)
                {
                    var data = (from ma in _context.MaestroDatos
                                join hs in _context.HistoricoSueldos on ma.FichaCd equals hs.FichaCd
                                where ma.FichaCd == ficha && ma.ParentescoNbr == 0
                                orderby hs.SueldoDate descending, hs.SueldoTipo
                                select new
                                {
                                    //ma.CedulaNbr,
                                    //ma.FichaNm,
                                    hs.SueldoDate,
                                    hs.SueldoTipo,
                                    hs.SueldoSal,
                                    sueldoMen = hs.SueldoSal*30,
                                    hs.ItemNbr
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
        public Utilies.ResponseResult GetSaldosFijoInfo(string ficha)
        {
            try
            {
                using (_context)
                {
                    var data = (from ma in _context.Maestro
                                join sa in _context.Saldos 
                                    on new { ma.CiaCd, ma.FichaCd } equals new { sa.CiaCd, sa.FichaCd }
                                where ma.FichaCd == ficha
                                select new
                                {
                                    sa.ConceptoNbr,
                                    conceptoDesc = _context.Conceptos.Where(x => x.NominaCd.Equals(ma.NominaCd) && x.ConceptoNbr.Equals(sa.ConceptoNbr)).Select(x => x.ConceptoDesc).FirstOrDefault(),
                                    sa.CantidadQty,
                                    sa.ValorSal,
                                    sa.SaldoSal
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
        public Utilies.ResponseResult GetNivelesInfo(string ficha)
        {
            try
            {
                using (_context)
                {
                    var data = (from ma in _context.Maestro
                                join md in _context.MaestroDatos
                                    on new { ma.CiaCd, ma.FichaCd } equals new { md.CiaCd, md.FichaCd }
                                    //where ma.FichaCd == ficha && md.ParentescoNbr == 0
                                where md.ParentescoNbr == 0
                                select new
                                {
                                    ma.FichaCd,
                                    md.FichaNm,
                                    ma.NivelNbr,
                                    ma.NivelOrg
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

        // GET: api/TrabajadorData/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TrabajadorData
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/TrabajadorData/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
