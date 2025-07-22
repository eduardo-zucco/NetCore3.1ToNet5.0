using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.UserCompleto;
using Api.Domain.Interfaces.Services.UserCompleto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCompletosController : ControllerBase
    {
        public IUserCompletoService _service { get; set; }
        public UserCompletosController(IUserCompletoService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAll(

        [FromQuery(Name = "search")] string? search = null,
        [FromQuery] string? name = null,
        [FromQuery] string? email = null,
        [FromQuery] string? uf = null,
        [FromQuery] string? municipio = null,
        [FromQuery] string? cep = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var (items, hasNext) = await _service.GetFiltered(search, name, email, uf, municipio, cep, page, pageSize);

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
        [HttpGet]
        [Route("{id}", Name = "GetCompleteWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Get(id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserCompletoDtoCreate user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Post(user);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetCompleteWithId", new { id = result.Id })), result);
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
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UserCompletoDtoUpdate user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                user.Id = id;

                var result = await _service.Put(user);

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
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpGet("by-email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest("Email inválido.");

            var result = await _service.GetByEmail(email);

            if (result == null)
                return NotFound();
            return Ok(result);
        }

    }
}