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
    public class EmpleadoController : ControllerBase
    {
        public readonly AppDbContext context;

        public EmpleadoController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<EmpleadoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.empleado.ToList());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<EmpleadoController>/5
        [HttpGet("{id}", Name = "GetEmpleado")]
        public ActionResult Get(int id)
        {
            try
            {
                var empleado1 = context.empleado.FirstOrDefault(e => e.idempleado == id);
                return Ok(empleado1);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public ActionResult Post([FromBody] Empleado empleado)
        {
            try
            {
                context.empleado.Add(empleado);
                context.SaveChanges();
                return CreatedAtRoute("GetEmpleado", new { id = empleado.idempleado }, empleado);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Empleado empleado)
        {
            try
            {
                if (empleado.idempleado == id)
                {
                    context.Entry(empleado).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetColor", new { id = empleado.idempleado }, empleado);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<EmpleadoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var empleado1 = context.empleado.FirstOrDefault(e => e.idempleado == id);
                if (empleado1 != null)
                {
                    context.empleado.Remove(empleado1);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
