using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using opening_hours.Models;
using opening_hours.Services;

namespace opening_hours.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpeningHoursController : ControllerBase
    {
        private readonly ILogger<OpeningHoursController> _logger;
        private readonly IOpeningHoursService _openingHoursService;

        public OpeningHoursController(ILogger<OpeningHoursController> logger, IOpeningHoursService openingHoursService)
        {
            _logger = logger;
            _openingHoursService = openingHoursService;
        }

        [HttpGet]
        public string OpeningHours()
		{
            return @"Send POST me data: {""monday"": [],""tuesday"": [{""type"": ""open"",""value"": 36000},{""type"": ""close"",""value"": 64800 }],""wednesday"":[],""thursday"": [{""type"": ""open"",""value"": 36000 },{""type"": ""close"",""value"": 64800 }],""friday"": [{""type"": ""open"",""value"": 36000 }],""saturday"": [{""type"": ""close"",""value"": 3600 },{""type"": ""open"",""value"": 36000 }],""sunday"": [{""type"": ""close"",""value"": 3600 },{""type"": ""open"",""value"": 43200 },{""type"": ""close"",""value"": 75600 }]}";
		}

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] DayOfWeekInput input)
        {
            try
            {

                var request = _openingHoursService.ProcessRequest(input);

                if (request.IsSuccess)
                {
                    return Ok(request);
                }

                return BadRequest(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");

                return BadRequest(ex.Message);
            }

        }


    }
}
