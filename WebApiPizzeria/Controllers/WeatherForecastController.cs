using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPizzeria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public class PedidoController : ControllerBase
        {
            /*
            [HttpGet("int/{id:int}")]
            public IActionResult GetIntPedido(int id)
            {
                return ControllerContext.MyDisplayRouteInfo(id);
            }*/

            /*[HttpGet("int/{id:int}")]
            public IActionResult GetById(int id)
            {
                Pedido pedido = Services.PedidoService.GetById(id);
                if (pedido == null)
                {
                    return NotFound();  // status 404
                }
                return Ok(pedido);
            }*/


            [HttpPost]
            public IActionResult CreatePedido(Pedido myPedido)
            {
                /*Services.PedidoService.Add(myPedido);
                return CreatedAtRoute("DefaultApi", new { id = myPedido.Id }, myPedido);*/
                return Ok();
            }
        }
    }
}
