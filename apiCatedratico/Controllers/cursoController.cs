using apiCatedratico.Context;
using apiCurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiCurso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cursoController : ControllerBase
    {
        private readonly AppDbContext context;

        public cursoController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<cursoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.curso.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<cursoController>/5
        [HttpGet("{id}", Name = "GetCurso")]
        public ActionResult Get(int id)
        {
            try
            {
                var curso = context.curso.FirstOrDefault(f => f.id == id);
                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<cursoController>
        [HttpPost]
        public ActionResult Post([FromBody] Curso curso)
        {
            try
            {
                context.curso.Add(curso);
                context.SaveChanges();
                return CreatedAtRoute("GetCurso", new { id = curso.id }, curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<cursoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Curso curso)
        {
            try
            {
                if (curso.id == id)
                {
                    context.Entry(curso).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCurso", new { id = curso.id }, curso);
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
