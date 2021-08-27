using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Domain.Models;

using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/alerts")]
    public class AlertController : ControllerBase
    {

        private readonly ILogger<AlertController> _logger;

        private readonly AlertService _service;

        public AlertController(ILogger<AlertController> logger, AlertService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlert([FromBody] Alert alert)
        {
            try
            {
                await _service.CreateAlert(alert);
                return CreatedAtAction("CreateAlert", alert);
            }
            catch(Exception e)
            {
                _logger.LogInformation(e.Message, e);
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAlertById(int id)
        {
            try
            {
                var result = await _service.GetAlertById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message, e);
                return BadRequest();
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAlerts()
        {
            try
            {
                var result = await _service.GetAllAlerts();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message, e);
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAlert(int id)
        {
            try
            {
                await _service.DeleteAlert(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message, e);
                return BadRequest();
            }
        }
    }
}
