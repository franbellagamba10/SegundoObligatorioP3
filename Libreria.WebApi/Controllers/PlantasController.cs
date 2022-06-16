using Datos;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Libreria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantasController : ControllerBase
    {
        public IRepositorioPlantas RepoPlantas { get; set; }
        public PlantasController(IRepositorioPlantas repo)
        {
            RepoPlantas = repo;
        }


        // GET: api/<PlantasController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Planta> plantas = RepoPlantas.GetAll();
                if (plantas == null) //null o count() == 0?
                    return NotFound();
                return Ok(new List<Planta>());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // GET api/<PlantasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == null || id == 0)
                    return BadRequest();

                Planta plantaBuscada = RepoPlantas.FindById(id);
                if (plantaBuscada == null)
                    return NotFound();
                return Ok(plantaBuscada);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // POST api/<PlantasController>
        [HttpPost]
        public IActionResult Post([FromBody] Planta plantaModel)
        {
            try
            {
                if (plantaModel == null || !ModelState.IsValid)
                    return BadRequest();

                bool resultado = RepoPlantas.Create(plantaModel);
                if (!resultado)
                    return Conflict();

                return Created("api/plantas/" + plantaModel.id, plantaModel);
            }
            catch
            {

                throw;
            }
        }

        // PUT api/<PlantasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Planta plantaModel)
        {
            try
            {
                if (plantaModel != null && ModelState.IsValid && id != 0)
                {
                    plantaModel.id = id;
                    bool resultado = RepoPlantas.Update(plantaModel);
                    if (!resultado)
                        return Conflict();

                    return Ok(plantaModel);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }

        // DELETE api/<PlantasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            try
            {
                Planta plantaBD = RepoPlantas.FindById(id);
                if (plantaBD == null)
                    return NotFound();

                bool resultado = RepoPlantas.Delete(id);
                if (!resultado)
                    return Conflict();

                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
