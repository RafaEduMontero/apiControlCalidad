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
    public class OpController : ControllerBase
    {
        public readonly AppDbContext context;

        public OpController(AppDbContext context)
        {
            this.context = context; 
        }
        // GET: api/<OpController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.op.ToList());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET api/<OpController>/opdisponible
        [HttpGet("opdisponible", Name ="GetOpdisponible")]
        public ActionResult Get(string entrada)
        {
            try
            {
                return Ok(obtenerOpsDisponibles());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        ////GET api/<OpController>/opcontroldisponible
        [HttpGet("opcontroldisponible",Name ="GetOpcontroldisponible")]
        public ActionResult GetOpcontroldisponible(string e)
        {
            try
            {
                return Ok(obtenerOpsControlDisponibles());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        // GET api/<OpController>/5
        [HttpGet("{id}", Name ="GetOp")]
        public ActionResult Get(int id)
        {
            try
            {
                var op1 = context.op.FirstOrDefault(o => o.idop == id);
                return Ok(op1);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<OpController>
        [HttpPost]
        public ActionResult Post([FromBody] Op op)
        {
            try
            {
                bool condicion = lineaAsignada(op);
                if (condicion)
                {
                    Console.WriteLine(op.linea_numero.GetType());
                    context.op.Add(op);
                    context.SaveChanges();
                    return CreatedAtRoute("GetOp", new { id = op.idop }, op);
                }
                else
                {
                    return BadRequest("Linea Ocupada");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<OpController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Op op)
        {
            try
            {
                if(op.idop == id)
                {
                    context.Entry(op).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetOp", new { id = op.idop }, op);
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

        // DELETE api/<OpController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var op1 = context.op.FirstOrDefault(o => o.idop == id);
                if (op1 != null)
                {
                    context.op.Remove(op1);
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

        //Obtener las lineas disponibles para crear la op
        public bool lineaAsignada(Op op)
        {
            var ops = context.op.ToList();
            bool condicion;
            var count = 0;
            var opFinalizadas = ops.Where(op => op.estado != "Finalizada");
            Console.WriteLine(opFinalizadas);

            var opsFinalizadas = opFinalizadas.ToList();

            var tamaño = opsFinalizadas.Count;

            if(tamaño != 0)
            {
                for(var i=0; i<tamaño; i++)
                {
                    if(opsFinalizadas[i].linea_numero == op.linea_numero)
                    {
                        count = count + 1;
                    }
                }
                if (count > 0)
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

        //Obtener las op disponibles para comenzar la inspeccion de calzado
        public List<Op> obtenerOpsDisponibles()
        {
            var ops = context.op.ToList();

            for(var i = 0; i < ops.Count; i++)
            {
                ops.RemoveAll(o => o.estado == "Finalizada");
            }
            return ops;
        }

        public List<Op> obtenerOpsControlDisponibles()
        {
            var ops = context.op.ToList();

            for (var i = 0; i < ops.Count; i++)
            {
                ops.RemoveAll(o => o.estado != "Iniciada");
            }
            return ops;
        }
    }
}
