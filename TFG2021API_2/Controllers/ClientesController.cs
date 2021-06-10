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
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Cliente>> oRespuesta = new Respuesta<List<Cliente>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    var lst = db.Clientes.ToList();
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
        public IActionResult Add(ClienteRequest model)
        {
            Respuesta<List<Cliente>> oRespuesta = new Respuesta<List<Cliente>>();
            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.ClienteId = model.ClienteID;
                    oCliente.Descuento = model.Descuento;
                    oCliente.UsuarioIdCliente = model.UsuarioID_Cliente;
                    oCliente.UsuarioIdClienteNavigation = db.Usuarios.Find(model.UsuarioID_Cliente);

                    db.Clientes.Add(oCliente);
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
        public IActionResult Edit(ClienteRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Cliente oCliente = db.Clientes.Find(model.ClienteID);
                    oCliente.ClienteId = model.ClienteID;
                    oCliente.Descuento = model.Descuento;
                    oCliente.UsuarioIdCliente = model.UsuarioID_Cliente;

                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Cliente oCliente= db.Clientes.Find(Id);
                    db.Remove(oCliente);
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
