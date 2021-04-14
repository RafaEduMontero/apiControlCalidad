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
    public class ModeloController : ControllerBase
    {
        public readonly AppDbContext context;

        public ModeloController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<ModeloController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.modelo.ToList());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ModeloController>/5
        [HttpGet("{id}", Name ="GetModelo")]
        public ActionResult Get(int id)
        {
            try
            {
                var modelo1 = context.modelo.FirstOrDefault(modelo => modelo.idmodelo == id);
                return Ok(modelo1);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ModeloController>
        [HttpPost]
        public ActionResult Post([FromBody] Modelo modelo)
        {
            try
            {
                context.modelo.Add(modelo);
                context.SaveChanges();
                return CreatedAtRoute("GetModelo", new { id = modelo.idmodelo }, modelo);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ModeloController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Modelo modelo)
        {
            try
            {
                if(modelo.idmodelo == id)
                {
                    context.Entry(modelo).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetModelo", new { id = modelo.idmodelo }, modelo);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ModeloController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var modelo1 = context.modelo.FirstOrDefault(m => m.idmodelo == id);
                if(modelo1 != null)
                {
                    context.modelo.Remove(modelo1);
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
