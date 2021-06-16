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
    public class AlbaranLineaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<AlbaranLinea>> oRespuesta = new Respuesta<List<AlbaranLinea>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    var lst = db.AlbaranLineas.ToList();
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
        public IActionResult Add(AlbaranLineaRequest model)
        {
            Respuesta<List<AlbaranLinea>> oRespuesta = new Respuesta<List<AlbaranLinea>>();
            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    AlbaranLinea oAlbaranLinea = new AlbaranLinea();
                    oAlbaranLinea.LineaAlbaranId = model.LineaAlbaranID;
                    oAlbaranLinea.AlabaranAlbaranLinea = model.Alabaran_AlbaranLinea;
                    oAlbaranLinea.PedidoLineaAlbaranLinea = model.PedidoLinea_AlbaranLinea;
                    oAlbaranLinea.Cantidad = model.Cantidad;
                    oAlbaranLinea.Importe = model.Importe;
                    
                    oAlbaranLinea.AlabaranAlbaranLineaNavigation = db.Albarans.Find(model.Alabaran_AlbaranLinea);
                    oAlbaranLinea.PedidoLineaAlbaranLineaNavigation = db.PedidoLineas.Find(model.PedidoLinea_AlbaranLinea);

                    db.AlbaranLineas.Add(oAlbaranLinea);
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
        public IActionResult Edit(AlbaranLineaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    AlbaranLinea oAlbaranLinea = db.AlbaranLineas.Find(model.LineaAlbaranID);
                    oAlbaranLinea.LineaAlbaranId = model.LineaAlbaranID;
                    oAlbaranLinea.AlabaranAlbaranLinea = model.Alabaran_AlbaranLinea;
                    oAlbaranLinea.PedidoLineaAlbaranLinea = model.PedidoLinea_AlbaranLinea;
                    oAlbaranLinea.Cantidad = model.Cantidad;
                    oAlbaranLinea.Importe = model.Importe;

                    oAlbaranLinea.AlabaranAlbaranLineaNavigation = db.Albarans.Find(model.Alabaran_AlbaranLinea);
                    oAlbaranLinea.PedidoLineaAlbaranLineaNavigation = db.PedidoLineas.Find(model.PedidoLinea_AlbaranLinea);


                    db.Entry(oAlbaranLinea).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    AlbaranLinea oAlbaranLinea = db.AlbaranLineas.Find(Id);
                    db.Remove(oAlbaranLinea);
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
