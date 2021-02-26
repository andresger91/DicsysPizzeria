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
        
        [HttpGet("int/{id:int}")]
        public ActionResult GetById(int id)
        {
            Pedido pedido = Services.PedidoService.GetById(id);
            if (pedido == null)
            {
                return NotFound();  // status 404
            }
            return Ok(pedido);
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Pedido> pedidos = Services.PedidoService.GetAll();
            if (pedidos == null)
            {
                return NotFound();  // status 404
            }
            return Ok(pedidos);
        }
    }
}
