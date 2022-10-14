using System;
using System.Collections.Generic;
using System.Linq;
using LiveImport.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LiveImport.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly ILogger<UploadController> _logger;

        public UploadController(ILogger<UploadController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpPost]
        public IActionResult Post(ExtractDto extractDto)
        {
            _logger.LogInformation("Uploading file...");
            _bus.Publish(new Vault() {FileName = extractDto.File, DateLocked = extractDto.Date});
            return Ok();
        }
    }
}