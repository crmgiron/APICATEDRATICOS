using apiCatedratico.Models;
using apiCatedratico.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiCatedratico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class catedraticoController : ControllerBase
    {
        private readonly AppDbContext context;

        public catedraticoController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<catedraticoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.catedratico.ToList());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<catedraticoController>/5
        [HttpGet("{id}", Name="GetCatedratico")]
        public ActionResult Get(int id)
        {
            try
            {
                var catedratico = context.catedratico.FirstOrDefault(f => f.id == id);
                return Ok(catedratico);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<catedraticoController>
        [HttpPost]
        public ActionResult Post([FromBody] Catedratico catedratico)
        {
            try
            {
                context.catedratico.Add(catedratico);
                context.SaveChanges();
                return CreatedAtRoute("GetCatedratico", new { id = catedratico.id }, catedratico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<catedraticoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Catedratico catedratico)
        {
            try
            {
                if (catedratico.id == id)
                {
                    context.Entry(catedratico).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCatedratico", new { id = catedratico.id }, catedratico);
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

        // DELETE api/<catedraticoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var catedratico = context.catedratico.FirstOrDefault(f => f.id == id);
                if(catedratico != null)
                {
                    string estatus = "inactivo";
                    catedratico.estatus = estatus;
                    context.SaveChanges();
                    return Ok(id);
                }else
                {
                    return BadRequest();
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
