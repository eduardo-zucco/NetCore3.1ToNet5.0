using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Sw_Parametro;
using Api.Domain.Interfaces.Services.Sw_Parametro;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sw_ParametrosController : ControllerBase
    {
        public ISw_ParametroService _service { get; set; }
        public Sw_ParametrosController(ISw_ParametroService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Get(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAll(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery(Name = "search")] string? search = "")
        {
            try
            {

                var (items, hasNext) = await _service.GetFiltered(search ?? "", page, pageSize);

                var response = new
                {
                    items,
                    hasNext
                };

                return Ok(response);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Sw_ParametroDtoCreate dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Create(dto);
                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Sw_ParametroDtoUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                dto.Id = id;

                var result = await _service.Update(dto);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Delete(id);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}