using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetadatasController : ControllerBase
    {
        private readonly IMetadataService _service;

        public MetadatasController(IMetadataService service)
        {
            _service = service;
        }

        [HttpGet("{entityName}")]
        public async Task<ActionResult> Get(string entityName)
        {
            try
            {
                var metadata = await _service.GetMetadataAsync(entityName);
                return Ok(metadata);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}