﻿using Back.Clases.Productos;
using Back.Models.Abstratos;
using Back.Models.Entidades.Productos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private IserviciosProductos _context;
        

        public ProductosController(IserviciosProductos context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleProducto>>> GetProductos() =>  await _context.listarProductos();
        
        [HttpGet]
        [Route("Categorias")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria() => await _context.listarCategorias();

        [HttpGet]
        [Route("ProductosPorCategoria/{idCategoria}")]
        public async Task<ActionResult<IEnumerable< DetalleProducto>>> listaProductosPorCategoria(int idCategoria)
        {
            return await _context.ListarProductosPorCategoria(idCategoria);
        }
        
        [HttpPost]
        [Route("Registro")]
        public async Task<Object> RegistroProducto(DetalleProducto Rproducto)
        {
                try
                {
                    Producto producto = new Producto()
                    {
                        Nombre = Rproducto.Nombre,
                        Estado = Rproducto.Estado,
                        Ancho = Rproducto.Ancho,
                        Largo = Rproducto.Largo,
                        Fondo = Rproducto.Fondo,
                        TipoPuerta = Rproducto.TipoPuerta,
                        Descripcion = Rproducto.Descripcion,
                        Ruedas = Rproducto.Ruedas,
                        IdUsuario = Rproducto.IdUsuario,
                        Puntos = Rproducto.Puntos,
                        IdCategoria = Rproducto.IdCategoria,
                        GarantiaMeses = Rproducto.GarantiaMeses
                    };

                    producto = await _context.AgregarProducto(producto);

                    PrecioProducto precioP = new PrecioProducto()
                    {
                        Precio = Rproducto.Precio,
                        FechaInicio = DateTime.Now,
                        IdProducto = producto.IdProducto,
                        IdUsuario = producto.IdUsuario
                    };
                    await _context.AgregarPrecioProducto(precioP);

                    return Ok(new { mensaje = "Registro exitoso" });
                }
                catch (Exception e)
                {

                    return e.Message;
                }         
        }


        [HttpPut]
        [Route("Editar")]
        public async Task<Object> Editarproducto(Producto producto)
        {
            try
            {
                await _context.EditarProducto(producto);
                return Ok(new { mensaje = "edición exitosa" });
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        [HttpGet]
        [Route("ProductoPorId/{idProducto}")]
        public async Task<Producto> ProductoPorId(int idProducto)
        {
            return await _context.BuscarProductoPorId(idProducto);
        }



        [HttpGet]
        [Route("Detalle/{id}")]
        public async Task<DetalleProducto> DetalleProducto(int id)
        {
            try
            {
                return await _context.DetalleProducto(id);
            }
            catch (Exception)
            {

                throw;
            }
        }



        

        [HttpPost]
        [Route("Imagen")]
        public async Task<Object> GuardarImagen([FromForm] FileImagenProducto imagen)
        {
            try
            {
                if (imagen.Imagen!=null)
                {
                    await _context.AgregarImagen(imagen);
                    return Ok(new { mensaje = "exito" });
                }
                else
                {
                    return BadRequest(new { mensaje = "No se detecto archivo" });
                }
                
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

       [HttpGet]
       [Route("ListaImagenes/{id}")]
       public async Task<ActionResult<IEnumerable<Imagen>>> GetImagenes(int id)
        {
            try
            {
                if (id != 0)
                {
                    return await _context.ListaImagenesProducto(id);
                }
                else
                {
                    return BadRequest(new { mensaje = "error al listar las imagenes" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("ListaDetalleMateriales/{idProducto}")]
        public async Task<ActionResult<IEnumerable<DetalleMaterialNombres>>> listaDetalleMateriales(int idProducto)
        {
            return await _context.ListarMaterialesProducto(idProducto);
        }

        [HttpPost]
        [Route("AgregarDetalleMaterial")]
        public async Task<Object> AgregarDetalleMaterial(DetalleMaterial detalleMaterial)
        {
            try
            {
                await _context.AgregarDetalleMaterialProducto(detalleMaterial);
                return Ok(new { mensaje = "Registro exitoso"});
            }
            catch (Exception)
            {

                throw;
            }
            
        }


        [HttpGet]
        [Route("ListarIva")]
        public async Task<ActionResult<IEnumerable<Iva>>> listarIva() => await _context.listarIva();

        [HttpPut]
        [Route("AgregarIva")]
        public async Task<Object> AgregarIva(Iva iva)
        {
            try
            {
                await _context.AgregarIva(iva);
                return Ok(new { mensaje = "Iva agregado exitosamente" });
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        [HttpGet]
        [Route("listaPrecioProducto/{idProducto}")]
        public async Task<ActionResult<IEnumerable<PrecioProducto>>> ListaPrecioProducto(int idProducto)
        {
            return await _context.ListaPrecioProducto(idProducto);
        }
            


        
    }
}