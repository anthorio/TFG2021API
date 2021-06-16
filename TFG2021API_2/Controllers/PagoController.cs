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
    public class PagoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Pago>> oRespuesta = new Respuesta<List<Pago>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    var lst = db.Pagos.ToList();
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
        public IActionResult Add(PagoRequest model)
        {
            Respuesta<List<Pago>> oRespuesta = new Respuesta<List<Pago>>();
            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Pago oPago = new Pago();
                    oPago.PagoId = model.PagoID;
                    oPago.FacturaPago = model.Factura_Pago;
                    oPago.Fecha = model.Fecha;
                    oPago.Cantidad = model.Cantidad;
                    oPago.Observaciones = model.Observaciones;
                    oPago.FacturaPagoNavigation = db.Facturas.Find(model.Factura_Pago);

                    db.Pagos.Add(oPago);
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
        public IActionResult Edit(PagoRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Pago oPago = db.Pagos.Find(model.PagoID);
                    oPago.PagoId = model.PagoID;
                    oPago.FacturaPago = model.Factura_Pago;
                    oPago.Fecha = model.Fecha;
                    oPago.Cantidad = model.Cantidad;
                    oPago.Observaciones = model.Observaciones;
                    oPago.FacturaPagoNavigation = db.Facturas.Find(model.Factura_Pago);

                    db.Entry(oPago).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Pago oPago= db.Pagos.Find(Id);
                    db.Remove(oPago);
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
