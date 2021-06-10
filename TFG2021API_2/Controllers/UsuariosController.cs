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
    public class UsuariosController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Usuario>> oRespuesta = new Respuesta<List<Usuario>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    var lst = db.Usuarios.ToList();
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
        public IActionResult Add(UsuarioRequest model)
        {
            Respuesta<List<Usuario>> oRespuesta = new Respuesta<List<Usuario>>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Usuario oUsuario = new Usuario();
                    oUsuario.UsuarioId = model.UsuarioID;
                    oUsuario.Rol = model.Rol;
                    oUsuario.Email = model.Email;
                    oUsuario.Contrasena = model.Contrasena;
                    oUsuario.Nombre = model.Nombre;
                    oUsuario.Apellidos = model.Apellidos;
                    oUsuario.Telefono = model.Telefono;
                    oUsuario.Dni = model.DNI;
                    oUsuario.FechaNacimiento = model.FechaNacimiento;
                    oUsuario.Direccion = model.Direccion;
                    oUsuario.Poblacion = model.Poblacion;
                    oUsuario.CodigoPostal = model.CodigoPostal;
                    oUsuario.Borrado = model.Borrado;

                    db.Usuarios.Add(oUsuario);
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
        public IActionResult Edit(UsuarioRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (TFG2021Context db = new TFG2021Context())
                {
                    Usuario oUsuario = db.Usuarios.Find(model.UsuarioID);
                    oUsuario.Rol = model.Rol;
                    oUsuario.Email = model.Email;
                    oUsuario.Contrasena = model.Contrasena;
                    oUsuario.Nombre = model.Nombre;
                    oUsuario.Apellidos = model.Apellidos;
                    oUsuario.Telefono = model.Telefono;
                    oUsuario.Dni = model.DNI;
                    oUsuario.FechaNacimiento = model.FechaNacimiento;
                    oUsuario.Direccion = model.Direccion;
                    oUsuario.Poblacion = model.Poblacion;
                    oUsuario.CodigoPostal = model.CodigoPostal;
                    oUsuario.Borrado = model.Borrado;

                    db.Entry(oUsuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Usuario oUsuario = db.Usuarios.Find(Id);
                    db.Remove(oUsuario);
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
