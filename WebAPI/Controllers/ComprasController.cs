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

        [HttpGet]
        [Route("ComprasId/{id}", Name = "FindById")]
        public IActionResult FindById(int id)
        {
            return Ok(RepoCompras.FindById(id));
        }

        [HttpGet("{idTipoPlanta}")]
        [Route("ComprasTipoPlanta/{idTipoPlanta}", Name = "Get")]

        public IActionResult Get(int idTipoPlanta)
        {
            try
            {
                if (idTipoPlanta == 0)
                    return BadRequest();

                IEnumerable<Compra> compraBD = RepoCompras.FindByTipoPlanta(idTipoPlanta);
                if (compraBD == null || compraBD.Count() == 0)
                    return NotFound();

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

                    costoTotal = compraBD.costoTotal,
                });

                return Ok(dtos);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("alta/compraImportacion")]
        [Route("compraImportacion")]
        public IActionResult Post([FromBody] CompraImportacion compraImportacion)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                bool ok = RepoCompras.Create(compraImportacion);
                if (!ok) return Conflict();

                return CreatedAtRoute("FindById", new { id = compraImportacion.id }, compraImportacion);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }


        [HttpPost("alta/CompraPlaza")]
        [Route("CompraPlaza")]
        public IActionResult Post([FromBody] CompraPlaza compraPlaza)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                bool ok = RepoCompras.Create(compraPlaza);
                if (!ok) return Conflict();

                return CreatedAtRoute("FindById", new { id = compraPlaza.id}, compraPlaza);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

    }
}
