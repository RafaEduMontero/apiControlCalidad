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
    public class TurnoController : ControllerBase
    {
        public readonly AppDbContext context;

        public TurnoController(AppDbContext context)
        {
            this.context = context;        
        }
        // GET: api/<TurnoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.turno.ToList());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TurnoController>/5
        [HttpGet("{id}", Name ="GetTurno")]
        public ActionResult Get(int id)
        {
            try
            {
                var turno1 = context.turno.FirstOrDefault(t => t.idturno == id);
                return Ok(turno1);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TurnoController>
        [HttpPost]
        public ActionResult Post([FromBody] Turno turno)
        {
            try
            {
                context.turno.Add(turno);
                context.SaveChanges();
                return CreatedAtRoute("GetTurno", new { id = turno.idturno }, turno);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TurnoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Turno turno)
        {
            try
            {
                if(turno.idturno == id)
                {
                    context.Entry(turno).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetTurno", new { id = turno.idturno }, turno);
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

        // DELETE api/<TurnoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var empleado1 = context.empleado.FirstOrDefault(e => e.idempleado == id);
                if(empleado1 != null)
                {
                    context.Remove(empleado1);
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
    }
}
