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
    public class FamiliaProductoController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<FamiliaProducto>> oRespuesta = new Respuesta<List<FamiliaProducto>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    var lst = db.FamiliaProductos.ToList();
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
        public IActionResult Add(FamiliaProductoRequest model)
        {
            Respuesta<List<FamiliaProducto>> oRespuesta = new Respuesta<List<FamiliaProducto>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    FamiliaProducto oFamilia = new FamiliaProducto();
                    oFamilia.FamiliaId = model.FamiliaID;
                    oFamilia.Nombre = model.Nombre;
                    oFamilia.Descripcion = model.Descripcion;

                    db.FamiliaProductos.Add(oFamilia);
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
        public IActionResult Edit(FamiliaProductoRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    FamiliaProducto oFamilia = db.FamiliaProductos.Find(model.FamiliaID);
                    oFamilia.FamiliaId = model.FamiliaID;
                    oFamilia.Nombre = model.Nombre;
                    oFamilia.Descripcion = model.Descripcion;

                    db.Entry(oFamilia).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    FamiliaProducto oFamilia = db.FamiliaProductos.Find(Id);
                    db.Remove(oFamilia);
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
