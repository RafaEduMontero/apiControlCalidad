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
    public class ColorController : ControllerBase
    {
        public readonly AppDbContext context;

        public ColorController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<ColorController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.color.ToList());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ColorController>/5
        [HttpGet("{id}", Name ="GetColor")]
        public ActionResult Get(int id)
        {
            try
            {
                var color1 = context.color.FirstOrDefault(color => color.idcolor == id);
                return Ok(color1);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ColorController>
        [HttpPost]
        public ActionResult Post([FromBody] Color color)
        {
            try
            {
                context.color.Add(color);
                context.SaveChanges();
                return CreatedAtRoute("GetColor", new { id = color.idcolor }, color);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ColorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Color color)
        {
            try
            {
                if(color.idcolor == id)
                {
                    context.Entry(color).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetColor", new { id = color.idcolor }, color);
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

        // DELETE api/<ColorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var color1 = context.color.FirstOrDefault(c => c.idcolor == id);
                if(color1 != null)
                {
                    context.color.Remove(color1);
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
