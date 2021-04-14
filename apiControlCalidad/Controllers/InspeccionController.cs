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
    public class InspeccionController : ControllerBase
    {
        public readonly AppDbContext context;

        public InspeccionController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<InspeccionController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.inspeccion.ToList());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<InspeccionController>/5
        [HttpGet("{id}",Name ="GetInspeccion")]
        public ActionResult Get(int id)
        {
            try
            {
                var insp1 = context.inspeccion.FirstOrDefault(i => i.idinspeccion == id);
                return Ok(insp1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<InspeccionController>
        [HttpPost]
        public ActionResult Post([FromBody] Inspeccion inspeccion)
        {
            try
            {
                context.inspeccion.Add(inspeccion);
                context.SaveChanges();
                return CreatedAtRoute("GetInspeccion", new { id = inspeccion.idinspeccion }, inspeccion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<InspeccionController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Inspeccion inspeccion)
        {
            try
            {
                if (inspeccion.idinspeccion == id)
                {
                    context.Entry(inspeccion).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetInspeccion", new { id = inspeccion.idinspeccion }, inspeccion);
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

        // DELETE api/<InspeccionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var insp1 = context.inspeccion.FirstOrDefault(i => i.idinspeccion == id);
                if (insp1 != null)
                {
                    context.inspeccion.Remove(insp1);
                    context.inspeccion.Remove(insp1);
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
