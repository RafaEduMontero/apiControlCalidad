using apiControlCalidad.Context;
using apiControlCalidad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiControlCalidad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefectoController : ControllerBase
    {
        public readonly AppDbContext context;

        public DefectoController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<DefectoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.defecto.ToList());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("defectosreproceso", Name = "GetDefectoreproceso")]
        public ActionResult GetReproceso()
        {
            try
            {
                return Ok(obtenerDefectosReproceso());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("defectosobservado", Name = "GetDefectoobservado")]
        public ActionResult GetObservado()
        {
            try
            {
                return Ok(obtenerDefectosObservado());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<DefectoController>/5
        [HttpGet("{id}", Name ="GetDefecto")]
        public ActionResult Get(int id)
        {
            try
            {
                var defecto1 = context.defecto.FirstOrDefault(d => d.iddefecto == id);
                return Ok(defecto1);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<DefectoController>
        [HttpPost]
        public ActionResult Post([FromBody] Defecto defecto)
        {
            try
            {
                context.defecto.Add(defecto);
                context.SaveChanges();
                return CreatedAtRoute("GetDefecto", new { id = defecto.iddefecto }, defecto);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<DefectoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Defecto defecto)
        {
            try
            {
                if(defecto.iddefecto == id)
                {
                    context.Entry(defecto).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetDefecto", new { id = defecto.iddefecto }, defecto);
                }
                else
                {
                    return BadRequest();
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<DefectoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var defecto1 = context.defecto.FirstOrDefault(d => d.iddefecto == id);
                if(defecto1 != null)
                {
                    context.Remove(defecto1);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public List<Defecto> obtenerDefectosReproceso()
        {
            var defectos = context.defecto.ToList();
            var defectosR = defectos.Where(d => d.tipo_defecto == "Reproceso");
            var defectosReproceso = defectosR.ToList();
            return defectosReproceso;
        }

        public List<Defecto> obtenerDefectosObservado()
        {
            var defectos = context.defecto.ToList();
            var defectosO = defectos.Where(d => d.tipo_defecto == "Observado");
            var defectosObservado = defectosO.ToList();
            return defectosObservado;
        }
    }
}
