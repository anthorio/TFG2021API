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
    public class FacturaLineaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<FacturaLinea>> oRespuesta = new Respuesta<List<FacturaLinea>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    var lst = db.FacturaLineas.ToList();
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
        public IActionResult Add(FacturaLineaRequest model)
        {
            Respuesta<List<FacturaLinea>> oRespuesta = new Respuesta<List<FacturaLinea>>();
            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    FacturaLinea oFacturaLinea = new FacturaLinea();
                    oFacturaLinea.LineaFacturaId = model.LineaFacturaID;
                    oFacturaLinea.FacturaFacturaLinea = model.Factura_FacturaLinea;
                    oFacturaLinea.ProductoFacturaLinea = model.Producto_FacturaLinea;
                    oFacturaLinea.Cantidad = model.Cantidad;
                    oFacturaLinea.Importe = model.Importe;
                    
                    oFacturaLinea.FacturaFacturaLineaNavigation = db.Facturas.Find(model.Factura_FacturaLinea);
                    oFacturaLinea.ProductoFacturaLineaNavigation = db.Productos.Find(model.Producto_FacturaLinea);

                    db.FacturaLineas.Add(oFacturaLinea);
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
        public IActionResult Edit(FacturaLineaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    FacturaLinea oFacturaLinea = db.FacturaLineas.Find(model.LineaFacturaID);
                    oFacturaLinea.LineaFacturaId = model.LineaFacturaID;
                    oFacturaLinea.FacturaFacturaLinea = model.Factura_FacturaLinea;
                    oFacturaLinea.ProductoFacturaLinea = model.Producto_FacturaLinea;
                    oFacturaLinea.Cantidad = model.Cantidad;
                    oFacturaLinea.Importe = model.Importe;

                    oFacturaLinea.FacturaFacturaLineaNavigation = db.Facturas.Find(model.Factura_FacturaLinea);
                    oFacturaLinea.ProductoFacturaLineaNavigation = db.Productos.Find(model.Producto_FacturaLinea);

                    db.Entry(oFacturaLinea).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    FacturaLinea oFacturaLinea = db.FacturaLineas.Find(Id);
                    db.Remove(oFacturaLinea);
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
