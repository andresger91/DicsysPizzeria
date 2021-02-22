using Microsoft.AspNetCore.Mvc;
using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController: ControllerBase
    {
        /*
        [HttpGet("int/{id:int}")]
        public IActionResult GetIntPedido(int id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }*/
        /*
        [HttpGet("int/{id:int}")]
        public IActionResult GetById(int id)
        {
            Pedido pedido = Services.PedidoService.GetById(id);
            if (pedido == null)
            {
                return NotFound();  // status 404
            }
            return Ok(pedido);
        }*/
    }
}
