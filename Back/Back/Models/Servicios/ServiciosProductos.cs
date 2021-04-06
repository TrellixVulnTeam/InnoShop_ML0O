﻿using Back.Clases.Productos;
using Back.Models.Abstratos;
using Back.Models.DAL;
using Back.Models.Entidades.Productos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models.Servicios
{
    public class ServiciosProductos : IserviciosProductos
    {
        private readonly DBContext _context;
        private IWebHostEnvironment _environment;

        public ServiciosProductos(DBContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }



        public async Task<ActionResult<IEnumerable<DetalleProducto>>> listarProductos()
        {
            
            await using (_context)
            {
                List<DetalleProducto> ListaProductos = (from producto in _context.Productos
                                                        join categoria in _context.Categorias
                                                        on producto.IdCategoria equals categoria.IdCategoria
                                                        join precioProducto in _context.PrecioProductos
                                                        on producto.IdProducto equals precioProducto.IdProducto

                                                        
                                                        select new DetalleProducto
                                                        {
                                                            IdProducto = producto.IdProducto,
                                                            Nombre = producto.Nombre,
                                                            Estado = producto.Estado,
                                                            Ancho = producto.Ancho,
                                                            Largo = producto.Largo,
                                                            Fondo = producto.Fondo,
                                                            TipoPuerta = producto.TipoPuerta,
                                                            Descripcion = producto.Descripcion,
                                                            Ruedas = producto.Ruedas,
                                                            IdUsuario = producto.IdUsuario,
                                                            IdCategoria = producto.IdCategoria,
                                                            Puntos = producto.Puntos,
                                                            NombreCategoria = categoria.Nombre,
                                                            GarantiaMeses = producto.GarantiaMeses,
                                                            Precio = precioProducto.Precio
                                                        }).ToList();
                return ListaProductos;
            }
           

        }
        public async Task<ActionResult<IEnumerable<Imagen>>> ListaImagenesProducto(int id)
        {
            return await _context.Imagenes.Where(x => x.IdProducto == id).ToListAsync();
        }
        public async Task<ActionResult<IEnumerable<Categoria>>> listarCategorias() => await _context.Categorias.ToListAsync();

        public async Task<ActionResult<IEnumerable<DetalleProducto>>> ListarProductosPorCategoria(int idCategoria)
        {
            await using (_context)
            {
                List<DetalleProducto> listaProductosPorCategoria = (from producto in _context.Productos
                                                               join categoria in _context.Categorias
                                                               on producto.IdCategoria equals categoria.IdCategoria
                                                               join precioProducto in _context.PrecioProductos
                                                               on producto.IdProducto equals precioProducto.IdProducto

                                                                    where producto.IdCategoria == idCategoria
                                                               select new DetalleProducto
                                                               {
                                                                   IdProducto = producto.IdProducto,
                                                                   Nombre = producto.Nombre,
                                                                   Estado = producto.Estado,
                                                                   Ancho = producto.Ancho,
                                                                   Largo = producto.Largo,
                                                                   Fondo = producto.Fondo,
                                                                   TipoPuerta = producto.TipoPuerta,
                                                                   Descripcion = producto.Descripcion,
                                                                   Ruedas = producto.Ruedas,
                                                                   IdUsuario = producto.IdUsuario,
                                                                   IdCategoria = producto.IdCategoria,
                                                                   Puntos = producto.Puntos,
                                                                   NombreCategoria = categoria.Nombre,
                                                                   GarantiaMeses = producto.GarantiaMeses,
                                                                   Precio = precioProducto.Precio
                                                               }).ToList();
                return listaProductosPorCategoria;
            }
        }

        public async Task<ActionResult<IEnumerable<PrecioProducto>>> ListaPrecioProducto(int idProducto)
        {
            return await _context.PrecioProductos.Where(x => x.IdProducto == idProducto).ToListAsync();
        }


        public async Task<Producto> AgregarProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return producto;
        }


        public async Task<Producto> BuscarProductoPorId(int id) => await _context.Productos.FindAsync(id);


        public async Task EditarProducto(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task AgregarImagen(FileImagenProducto archivoImagen)
        {
            string rutaImagen = System.IO.Path.Combine(_environment.ContentRootPath, "Imagenes", archivoImagen.Imagen.FileName);
            await archivoImagen.Imagen.CopyToAsync(new System.IO.FileStream(rutaImagen, System.IO.FileMode.Create));

            Imagen imagen = new()
            {
                RutaImagen = rutaImagen,
                IdProducto = archivoImagen.IdProducto,
                IdUsuario = archivoImagen.IdUsuario
            };
            await _context.Imagenes.AddAsync(imagen);
            await _context.SaveChangesAsync();
        }


        public async Task AgregarDetalleMaterialProducto(DetalleMaterial detalleMaterial)
        {
            _context.DetalleMateriales.Add(detalleMaterial);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DetalleMaterialNombres>> ListarMaterialesProducto(int idProducto)
        {
            await using (_context)
            {
                List<DetalleMaterialNombres> listaMateriales = (from productos in _context.Productos
                                                                join detalleM in _context.DetalleMateriales
                                                                on productos.IdProducto equals detalleM.IdProducto
                                                                join material in _context.Materiales
                                                                on detalleM.IdMaterial equals material.IdMaterial
                                                                where detalleM.IdProducto == idProducto

                                                                select new DetalleMaterialNombres
                                                                {
                                                                    IdDetalleMaterial = detalleM.IdDetalleMaterial,
                                                                    IdMaterial = detalleM.IdMaterial,
                                                                    IdProducto = detalleM.IdProducto,
                                                                    NombreMaterial = material.Nombre,
                                                                    IdUsuario = detalleM.IdUsuario,
                                                                    Descripcion = material.Descripcion
                                                                }).ToList();
                return listaMateriales;
            }
        }

        public async Task AgregarPrecioProducto(PrecioProducto precioProducto)
        {
            _context.PrecioProductos.Add(precioProducto);
             await _context.SaveChangesAsync();
        }

        public async Task<DetalleProducto> DetalleProducto(int id)
        {
            await using (_context)
            {
                List<DetalleProducto> detalleProducto = ( from producto in _context.Productos
                                       join categoria in _context.Categorias
                                       on producto.IdCategoria equals categoria.IdCategoria
                                       join precioProducto in _context.PrecioProductos
                                       on producto.IdProducto equals precioProducto.IdProducto
                                       where producto.IdProducto == id 

                                       select new DetalleProducto
                                       {
                                           IdProducto = producto.IdProducto,
                                           Nombre = producto.Nombre,
                                           Estado = producto.Estado,
                                           Ancho = producto.Ancho,
                                           Largo = producto.Largo,
                                           Fondo = producto.Fondo,
                                           TipoPuerta = producto.TipoPuerta,
                                           Descripcion = producto.Descripcion,
                                           Ruedas = producto.Ruedas,
                                           IdUsuario = producto.IdUsuario,
                                           Puntos = producto.Puntos,
                                           NombreCategoria = categoria.Nombre,
                                           GarantiaMeses = producto.GarantiaMeses,
                                           Precio = precioProducto.Precio
                                       }).ToList();
                return detalleProducto[detalleProducto.Count()-1];
            }

            
        }

        public async Task<ActionResult<IEnumerable<Iva>>> listarIva()=> await _context.Iva.ToListAsync();
        
        public async Task AgregarIva(Iva iva)
        {
             _context.Iva.Add(iva);
            await _context.SaveChangesAsync();
        }
       
        
    }
}