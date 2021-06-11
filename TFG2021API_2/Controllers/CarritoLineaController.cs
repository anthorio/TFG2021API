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
    public class CarritoLineaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<CarritoLinea>> oRespuesta = new Respuesta<List<CarritoLinea>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    var lst = db.CarritoLineas.ToList();
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
        public IActionResult Add(CarritoLineaRequest model)
        {
            Respuesta<List<CarritoLinea>> oRespuesta = new Respuesta<List<CarritoLinea>>();
            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    CarritoLinea oCarritoLinea = new CarritoLinea();
                    oCarritoLinea.LineaCarritoId = model.LineaCarritoID;
                    oCarritoLinea.CarritoCarritoLinea = model.Carrito_CarritoLinea;
                    oCarritoLinea.ProductoCarritoLinea = model.Producto_CarritoLinea;
                    oCarritoLinea.Cantidad = model.Cantidad;
                    oCarritoLinea.CarritoCarritoLineaNavigation = db.Carritos.Find(model.Carrito_CarritoLinea);
                    oCarritoLinea.ProductoCarritoLineaNavigation = db.Productos.Find(model.Producto_CarritoLinea);

                    db.CarritoLineas.Add(oCarritoLinea);
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
        public IActionResult Edit(CarritoLineaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    CarritoLinea oCarritoLinea = db.CarritoLineas.Find(model.LineaCarritoID);
                    oCarritoLinea.LineaCarritoId = model.LineaCarritoID;
                    oCarritoLinea.CarritoCarritoLinea = model.Carrito_CarritoLinea;
                    oCarritoLinea.ProductoCarritoLinea = model.Producto_CarritoLinea;
                    oCarritoLinea.Cantidad = model.Cantidad;
                    oCarritoLinea.CarritoCarritoLineaNavigation = db.Carritos.Find(model.Carrito_CarritoLinea);
                    oCarritoLinea.ProductoCarritoLineaNavigation = db.Productos.Find(model.Producto_CarritoLinea);


                    db.Entry(oCarritoLinea).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    CarritoLinea oCarritoLinea = db.CarritoLineas.Find(Id);
                    db.Remove(oCarritoLinea);
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
