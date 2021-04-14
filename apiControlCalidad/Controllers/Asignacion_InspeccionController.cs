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
    public class Asignacion_InspeccionController : ControllerBase
    {
        public readonly AppDbContext context;

        public Asignacion_InspeccionController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<Asignacion_InspeccionController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.asignacion_inspeccion.ToList());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<Asignacion_InspeccionController>/5
        [HttpGet("{id}",Name ="GetAsignacion_Inspeccion")]
        public ActionResult Get(int id)
        {
            try
            {
                var ai1 = context.asignacion_inspeccion.FirstOrDefault(a => a.idasignacion == id);
                return Ok(ai1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<Asignacion_InspeccionController>
        [HttpPost]
        public ActionResult Post([FromBody] Asignacion_Inspeccion asignacion_inspeccion)
        {
            try
            {
                bool condicion = asignacionInspeccion(asignacion_inspeccion);
                if (condicion)
                {
                    context.asignacion_inspeccion.Add(asignacion_inspeccion);
                    context.SaveChanges();
                    return CreatedAtRoute("GetAsignacion_Inspeccion", new { id = asignacion_inspeccion.idasignacion }, asignacion_inspeccion);
                }
                else
                {
                    return BadRequest("OP a inspeccionar Ocupada");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("OP a inspeccionar Ocupada");
            }
        }

        // PUT api/<Asignacion_InspeccionController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Asignacion_Inspeccion asignacion_inspeccion)
        {
            try
            {
                if (asignacion_inspeccion.idasignacion == id)
                {
                    context.Entry(asignacion_inspeccion).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetAsignacion_Inspeccion", new { id = asignacion_inspeccion.idasignacion }, asignacion_inspeccion);
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

        // DELETE api/<Asignacion_InspeccionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var ai1 = context.asignacion_inspeccion.FirstOrDefault(a => a.idasignacion == id);
                if (ai1 != null)
                {
                    context.asignacion_inspeccion.Remove(ai1);
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

        public bool asignacionInspeccion(Asignacion_Inspeccion asI)
        {
            var asIns = context.asignacion_inspeccion.ToList();
            bool condicion;
            var asInsOcu = asIns.Where(asi => asi.estado == "Ocupada");
            var count = 0;
            var asInsOcus = asInsOcu.ToList();
            var tamaño = asInsOcus.Count;

            if (tamaño != 0)
            {
                for(var i = 0; i < tamaño; i++)
                {
                    if(asInsOcus[i].estado == asI.estado && asInsOcus[i].op_numero_op == asI.op_numero_op)
                    {
                        count = count + 1;
                    }
                }
                if(count > 0)
                {
                    condicion = false;
                }
                else
                {
                    condicion = true;
                }
            }
            else
            {
                condicion = true;
            }

            return condicion;
        }
    }
}
