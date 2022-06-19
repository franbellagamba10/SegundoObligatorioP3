using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViveroDTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        public IRepositorioCompras RepoCompras { get; set; }

        public ComprasController(IRepositorioCompras RepoCompras)
        {
            this.RepoCompras = RepoCompras;
        }

        //[HttpGet("{id}")]
        //[Route("{id}", Name = "Get")]
        //public IActionResult FindById(int id)
        //{
        //    return RepoCompras.FindById(id);
        //}


        [HttpGet("compra/{idTipoPlanta}")]
        [Route("{idTipoPlanta}", Name = "Get")]
        public IActionResult Get(int idTipoPlanta)
        {
            try
            {
                if (idTipoPlanta == 0)
                    return BadRequest();

                IEnumerable<Compra> compraBD = RepoCompras.FindByTipoPlanta(idTipoPlanta);
                IEnumerable<CompraDTO> dtos = compraBD.Select(compraBD => new CompraDTO()
                {
                    id = compraBD.id,
                    fecha = compraBD.fecha,
                    Items = compraBD.Items,

                    impuestoImportacion = compraBD is CompraImportacion ? (compraBD as CompraImportacion).impuestoImportacion : 0,
                    esSudamericana = compraBD is CompraImportacion ? (compraBD as CompraImportacion).esSudamericana : false,
                    tasaArancelaria = compraBD is CompraImportacion ? (compraBD as CompraImportacion).tasaArancelaria : 0,
                    medidasSanitarias = compraBD is CompraImportacion ? (compraBD as CompraImportacion).medidasSanitarias : string.Empty,

                    IVA = compraBD is CompraPlaza ? (compraBD as CompraPlaza).IVA : 0,
                    cobroFlete = compraBD is CompraPlaza ? (compraBD as CompraPlaza).cobroFlete : false,
                    costoEnvio = compraBD is CompraPlaza ? (compraBD as CompraPlaza).costoEnvio : 0,

                });

                return Ok(dtos);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // POST api/<ComprasController>
        [HttpPost]
        [Route("alta/compraImportacion")]
        public IActionResult Post([FromBody] CompraImportacion compraImportacion)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                //if (!ModelState.IsValid) return BadRequest();

                bool ok = RepoCompras.Create(compraImportacion);
                if (!ok) return Conflict();

                return CreatedAtRoute("Get", new { id = compraImportacion.id }, compraImportacion);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/<ComprasController>
        [HttpPost]
        [Route("alta/compraPlaza")]
        public IActionResult Post([FromBody] CompraPlaza compraPlaza)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                //if (!ModelState.IsValid) return BadRequest();

                bool ok = RepoCompras.Create(compraPlaza);
                if (!ok) return Conflict();

                return CreatedAtRoute("Get", new { id = compraPlaza.id }, compraPlaza);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

    }
}
