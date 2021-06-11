using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFG2021API_2.Models.Response;
using TFG2021API_2.Models;
using TFG2021API_2.Models.Request;

namespace TFG2021API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Pedido>> oRespuesta = new Respuesta<List<Pedido>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    var lst = db.Pedidos.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(PedidoRequest model)
        {
            Respuesta<List<Pedido>> oRespuesta = new Respuesta<List<Pedido>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Pedido oPedido = new Pedido();
                    oPedido.PedidoId = model.PedidoID;
                    oPedido.UsuarioPedido = model.Usuario_Pedido;
                    oPedido.FechaPedido = model.FechaPedido;
                    oPedido.EstadoPedido = model.EstadoPedido;
                    oPedido.TipoEnvio = model.TipoEnvio;
                    oPedido.UsuarioPedidoNavigation = db.Usuarios.Find(model.Usuario_Pedido);

                    db.Pedidos.Add(oPedido);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(PedidoRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Pedido oPedido = db.Pedidos.Find(model.PedidoID);
                    oPedido.PedidoId = model.PedidoID;
                    oPedido.UsuarioPedido = model.Usuario_Pedido;
                    oPedido.FechaPedido = model.FechaPedido;
                    oPedido.EstadoPedido = model.EstadoPedido;
                    oPedido.TipoEnvio = model.TipoEnvio;
                    oPedido.UsuarioPedidoNavigation = db.Usuarios.Find(model.Usuario_Pedido);

                    db.Entry(oPedido).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Pedido oPedido = db.Pedidos.Find(Id);
                    db.Remove(oPedido);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
    }
}
