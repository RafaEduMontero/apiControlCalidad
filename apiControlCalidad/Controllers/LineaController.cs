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
    public class LineaController : ControllerBase
    {
        public readonly AppDbContext context;

        public LineaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<LineaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(obtenerLineasDisponibles());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<LineaController>/5
        [HttpGet("{id}", Name ="GetLinea")]
        public ActionResult Get(int id)
        {
            try
            {
                var linea1 = context.linea.FirstOrDefault(linea => linea.idlinea == id);
                return Ok(linea1);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<LineaController>
        [HttpPost]
        public ActionResult Post([FromBody] Linea linea)
        {
            try
            {
                context.linea.Add(linea);
                context.SaveChanges();
                return CreatedAtRoute("GetLinea", new { id = linea.idlinea },linea);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<LineaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Linea linea)
        {
            try
            {
                if(linea.idlinea == id)
                {
                    context.Entry(linea).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetLinea", new { id = linea.idlinea }, linea);
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

        // DELETE api/<LineaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var linea1 = context.linea.FirstOrDefault(l => l.idlinea == id);
                if(linea1 != null)
                {
                    context.linea.Remove(linea1);
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

        public List<Linea> obtenerLineasDisponibles()
        {
            var lineas1 = context.linea.ToList();
            var ops = context.op.ToList();

            for(var i=0; i < ops.Count; i++)
            {
                lineas1.RemoveAll(l => l.numero == ops[i].linea_numero && ops[i].estado != "Finalizada");
            }
            return lineas1;
        }
    }
}
