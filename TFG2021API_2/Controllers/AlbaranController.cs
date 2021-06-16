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
    public class AlbaranController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Albaran>> oRespuesta = new Respuesta<List<Albaran>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    var lst = db.Albarans.ToList();
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
        public IActionResult Add(AlbaranRequest model)
        {
            Respuesta<List<Albaran>> oRespuesta = new Respuesta<List<Albaran>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Albaran oAlbaran = new Albaran();
                    oAlbaran.AlbaranId = model.AlbaranID;
                    oAlbaran.PedidoAlbaran = model.Pedido_Albaran;
                    oAlbaran.FechaEntrega = model.FechaEntrega;
                    oAlbaran.PedidoAlbaranNavigation = db.Pedidos.Find(model.Pedido_Albaran);

                    db.Albarans.Add(oAlbaran);
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
        public IActionResult Edit(AlbaranRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Albaran oAlbaran = db.Albarans.Find(model.AlbaranID);
                    oAlbaran.AlbaranId = model.AlbaranID;
                    oAlbaran.PedidoAlbaran = model.Pedido_Albaran;
                    oAlbaran.FechaEntrega = model.FechaEntrega;
                    oAlbaran.PedidoAlbaranNavigation = db.Pedidos.Find(model.Pedido_Albaran);

                    db.Entry(oAlbaran).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Albaran oAlbaran = db.Albarans.Find(Id);
                    db.Remove(oAlbaran);
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
