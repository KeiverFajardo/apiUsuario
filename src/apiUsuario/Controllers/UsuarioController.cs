using apiUsuario.Context;
using apiUsuario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiUsuario.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly AppDbContext context;

        public UsuarioController(AppDbContext context)
        {
            this.context = context;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.usuarios.ToList());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name ="GetUsuario")]
        public ActionResult Get(int id)
        {
            try
            {
                var usuario = context.usuarios.FirstOrDefault(u => u.id == id);
                return Ok(usuario);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody]Usuario usuario)
        {
            try
            {
                context.usuarios.Add(usuario);
                context.SaveChanges();
                return CreatedAtRoute("GetUsuario", new { id = usuario.id }, usuario);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Usuario usuario)
        {
            try
            {
                if (usuario.id == id)
                {
                    context.Entry(usuario).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetUsuario", new { id = usuario.id }, usuario);
                }
                else
                {
                    return BadRequest();
                }
               
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var usuario = context.usuarios.FirstOrDefault(e => e.id == id);
                if (usuario != null)
                {
                    context.usuarios.Remove(usuario);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }

}
