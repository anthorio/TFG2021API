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
    public class FacturaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Factura>> oRespuesta = new Respuesta<List<Factura>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    var lst = db.Facturas.ToList();
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
        public IActionResult Add(FacturaRequest model)
        {
            Respuesta<List<Factura>> oRespuesta = new Respuesta<List<Factura>>();
            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Factura oFactura = new Factura();
                    oFactura.FacturaId = model.FacturaID;
                    oFactura.PedidoFactura = model.Pedido_Factura;
                    oFactura.InfoPedido = model.InfoPedido;
                    oFactura.FechaFactura = model.FechaFactura;
                    oFactura.Iva = model.IVA;
                    oFactura.Total = model.Total;
                    oFactura.Estado = model.Estado;

                    oFactura.PedidoFacturaNavigation = db.Pedidos.Find(model.Pedido_Factura);

                    db.Facturas.Add(oFactura);
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
        public IActionResult Edit(FacturaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Factura oFactura = db.Facturas.Find(model.FacturaID);
                    oFactura.FacturaId = model.FacturaID;
                    oFactura.PedidoFactura = model.Pedido_Factura;
                    oFactura.InfoPedido = model.InfoPedido;
                    oFactura.FechaFactura = model.FechaFactura;
                    oFactura.Iva = model.IVA;
                    oFactura.Total = model.Total;
                    oFactura.Estado = model.Estado;

                    oFactura.PedidoFacturaNavigation = db.Pedidos.Find(model.Pedido_Factura);

                    db.Entry(oFactura).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Factura oFactura= db.Facturas.Find(Id);
                    db.Remove(oFactura);
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
