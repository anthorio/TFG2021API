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
    public class ProveedorController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Proveedor>> oRespuesta = new Respuesta<List<Proveedor>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    var lst = db.Proveedors.ToList();
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
        public IActionResult Add(ProveedorRequest model)
        {
            Respuesta<List<Proveedor>> oRespuesta = new Respuesta<List<Proveedor>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Proveedor oProveedor = new Proveedor();
                    oProveedor.ProveedorId = model.ProveedorID;
                    oProveedor.Nombre = model.Nombre;
                    oProveedor.Descripcion = model.Descripcion;
                    oProveedor.Direccion = model.Direccion;
                    oProveedor.CodigoPostal = model.CodigoPostal;
                    oProveedor.Telefono = model.Telefono;
                    oProveedor.Email = model.Email;

                    db.Proveedors.Add(oProveedor);
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
        public IActionResult Edit(ProveedorRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Proveedor oProveedor = db.Proveedors.Find(model.ProveedorID);
                    oProveedor.ProveedorId = model.ProveedorID;
                    oProveedor.Nombre = model.Nombre;
                    oProveedor.Descripcion = model.Descripcion;
                    oProveedor.Direccion = model.Direccion;
                    oProveedor.CodigoPostal = model.CodigoPostal;
                    oProveedor.Telefono = model.Telefono;
                    oProveedor.Email = model.Email;

                    db.Entry(oProveedor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Proveedor oProveedor = db.Proveedors.Find(Id);
                    db.Remove(oProveedor);
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
