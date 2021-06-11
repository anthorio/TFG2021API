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
    public class ProductoController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Producto>> oRespuesta = new Respuesta<List<Producto>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    var lst = db.Productos.ToList();
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
        public IActionResult Add(ProductoRequest model)
        {
            Respuesta<List<Producto>> oRespuesta = new Respuesta<List<Producto>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Producto oProducto = new Producto();
                    oProducto.ProductoId = model.ProductoID;
                    oProducto.FamiliaProducto = model.Familia_Producto;
                    oProducto.ProveedorProducto = model.Proveedor_Producto;
                    oProducto.Nombre = model.Nombre;
                    oProducto.Descripcion = model.Descripcion;
                    oProducto.Cantidad = model.Cantidad;
                    oProducto.Precio = model.Precio;
                    oProducto.UrlImagen = model.URL_imagen;
                    oProducto.FamiliaProductoNavigation = db.FamiliaProductos.Find(model.Familia_Producto);
                    oProducto.ProveedorProductoNavigation= db.Proveedors.Find(model.Proveedor_Producto);

                    db.Productos.Add(oProducto);
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
        public IActionResult Edit(ProductoRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Producto oProducto = db.Productos.Find(model.ProductoID);
                    oProducto.ProductoId = model.ProductoID;
                    oProducto.FamiliaProducto = model.Familia_Producto;
                    oProducto.ProveedorProducto = model.Proveedor_Producto;
                    oProducto.Nombre = model.Nombre;
                    oProducto.Descripcion = model.Descripcion;
                    oProducto.Cantidad = model.Cantidad;
                    oProducto.Precio = model.Precio;
                    oProducto.UrlImagen = model.URL_imagen;
                    oProducto.FamiliaProductoNavigation = db.FamiliaProductos.Find(model.Familia_Producto);
                    oProducto.ProveedorProductoNavigation = db.Proveedors.Find(model.Proveedor_Producto);

                    db.Entry(oProducto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Producto oProducto = db.Productos.Find(Id);
                    db.Remove(oProducto);
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
