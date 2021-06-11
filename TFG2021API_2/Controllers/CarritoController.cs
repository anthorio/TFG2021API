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
    public class CarritoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Carrito>> oRespuesta = new Respuesta<List<Carrito>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    var lst = db.Carritos.ToList();
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
        public IActionResult Add(CarritoRequest model)
        {
            Respuesta<List<Carrito>> oRespuesta = new Respuesta<List<Carrito>>();
            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Carrito oCarrito = new Carrito();
                    oCarrito.CarritoId = model.CarritoID;
                    oCarrito.UsuarioCarrito = model.Usuario_Carrito;
                    oCarrito.UsuarioCarritoNavigation = db.Usuarios.Find(model.Usuario_Carrito);

                    db.Carritos.Add(oCarrito);
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
        public IActionResult Edit(CarritoRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Carrito oCarrito = db.Carritos.Find(model.CarritoID);
                    oCarrito.CarritoId = model.CarritoID;
                    oCarrito.UsuarioCarrito = model.Usuario_Carrito;
                    oCarrito.UsuarioCarritoNavigation = db.Usuarios.Find(model.Usuario_Carrito);

                    db.Entry(oCarrito).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Carrito oCarrito= db.Carritos.Find(Id);
                    db.Remove(oCarrito);
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
