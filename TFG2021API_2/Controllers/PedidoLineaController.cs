using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFG2021API_2.Models.Response;
using TFG2021API_2.Models;
using TFG2021API_2.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace TFG2021API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoLineaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<PedidoLinea>> oRespuesta = new Respuesta<List<PedidoLinea>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    var lst = db.PedidoLineas.ToList();
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
        public IActionResult Add(PedidoLineaRequest model)
        {
            Respuesta<List<PedidoLinea>> oRespuesta = new Respuesta<List<PedidoLinea>>();
            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    PedidoLinea oPedidoLinea = new PedidoLinea();
                    oPedidoLinea.LineaPedidoId = model.LineaPedidoID;
                    oPedidoLinea.PedidoPedidoLinea = model.Pedido_PedidoLinea;
                    oPedidoLinea.ProductoPedidoLinea = model.Producto_PedidoLinea;
                    oPedidoLinea.Cantidad = model.Cantidad;
                    oPedidoLinea.PrecioFinal = model.PrecioFinal;
                    
                    oPedidoLinea.PedidoPedidoLineaNavigation = db.Pedidos.Find(model.Pedido_PedidoLinea);
                    oPedidoLinea.ProductoPedidoLineaNavigation = db.Productos.Find(model.Producto_PedidoLinea);

                    db.PedidoLineas.Add(oPedidoLinea);
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
        public IActionResult Edit(PedidoLineaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    PedidoLinea oPedidoLinea = db.PedidoLineas.Find(model.LineaPedidoID);
                    oPedidoLinea.LineaPedidoId = model.LineaPedidoID;
                    oPedidoLinea.PedidoPedidoLinea = model.Pedido_PedidoLinea;
                    oPedidoLinea.ProductoPedidoLinea = model.Producto_PedidoLinea;
                    oPedidoLinea.Cantidad = model.Cantidad;
                    oPedidoLinea.PrecioFinal = model.PrecioFinal;

                    oPedidoLinea.PedidoPedidoLineaNavigation = db.Pedidos.Find(model.Pedido_PedidoLinea);
                    oPedidoLinea.ProductoPedidoLineaNavigation = db.Productos.Find(model.Producto_PedidoLinea);


                    db.Entry(oPedidoLinea).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    PedidoLinea oPedidoLinea = db.PedidoLineas.Find(Id);
                    db.Remove(oPedidoLinea);
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
