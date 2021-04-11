﻿using Back.Models.Abstratos;
using Back.Models.DAL;
using Back.Models.Entidades.Solicitudes;
using Back.Models.Entidades.Solicitudes.Personalizadas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models.Servicios
{
    public class ServiciosSolicitudes : IServiciosSolicitudes
    {
        private readonly DBContext _context;

        public ServiciosSolicitudes(DBContext context) => _context = context;

        public async Task<ActionResult<IEnumerable<CarritoDeCompras>>> ListarCarritoDeCompras() =>
            await _context.CarritoDeCompras.ToListAsync();

        public async Task<CarritoDeCompras> BuscarCarritoDeComprasPorId(int id) =>
            await _context.CarritoDeCompras.FindAsync(id);

        public async Task<CarritoDeCompras> AgregarCarritoDeCompras(CarritoDeCompras carritoDeCompras)
        {
            _context.CarritoDeCompras.Add(carritoDeCompras);
            await _context.SaveChangesAsync();
            return carritoDeCompras;
        }

        public async Task<CarritoDeCompras> EditarCarritoDeCompras(CarritoDeCompras carritoDeCompras)
        {
            _context.CarritoDeCompras.Update(carritoDeCompras);
            await _context.SaveChangesAsync();
            return carritoDeCompras;
        }

        public async Task<ActionResult<IEnumerable<DetalleCarritoDeCompras>>> ListarDetalleCarritoDeCompras() =>
            await _context.DetalleCarritoDeCompras.ToListAsync();

        public async Task<DetalleCarritoDeCompras> BuscarDetalleCarritoDeComprasPorId(int id) =>
            await _context.DetalleCarritoDeCompras.FindAsync(id);

        public async Task<DetalleCarritoDeCompras> AgregarDetalleCarritoDeCompras
            (DetalleCarritoDeCompras detalleCarritoDeCompras)
        {
            _context.DetalleCarritoDeCompras.Add(detalleCarritoDeCompras);
            await _context.SaveChangesAsync();
            return detalleCarritoDeCompras;
        }

        public async Task<DetalleCarritoDeCompras> EditarDetalleCarritoDeCompras
            (DetalleCarritoDeCompras detalleCarritoDeCompras)
        {
            _context.DetalleCarritoDeCompras.Update(detalleCarritoDeCompras);
            await _context.SaveChangesAsync();
            return detalleCarritoDeCompras;
        }

        //--------
        public async Task<DetalleEstadosMontajes> AgregarDetalleEstadosMontajes
            (DetalleEstadosMontajes DetalleEstadosMontajes)
        {
            _context.DetalleEstadosMontajes.Add(DetalleEstadosMontajes);
            await _context.SaveChangesAsync();
            return DetalleEstadosMontajes;
        }

        public async Task<ActionResult<IEnumerable<DetalleEstadosMontajes>>> ListarDetalleEstadosMontajes() =>
            await _context.DetalleEstadosMontajes.ToListAsync();

        public async Task<ActionResult<IEnumerable<DetalleEstadosMontajes>>> ListaDetalleEstadosMontajes(int id) =>
            await _context.DetalleEstadosMontajes.Where(x => x.IdDetalleEstadosMontajes == id).ToListAsync();


        public async Task<DetalleEstadosProductosPersoanlizados> AgregarDetalleEstadosProductosPersoanlizados
            (DetalleEstadosProductosPersoanlizados DetalleEstadosProductosPersoanlizados)
        {
            _context.DetalleEstadosProductosPersoanlizados.Add(DetalleEstadosProductosPersoanlizados);
            await _context.SaveChangesAsync();
            return DetalleEstadosProductosPersoanlizados;
        }

        public async Task<ActionResult<IEnumerable<DetalleEstadosProductosPersoanlizados>>>
            ListarDetalleEstadosProductosPersoanlizados() =>
            await _context.DetalleEstadosProductosPersoanlizados.ToListAsync();

        public async Task<ActionResult<IEnumerable<DetalleEstadosProductosPersoanlizados>>>
            ListaDetalleEstadosProductosPersoanlizados(int id) =>
            await _context.DetalleEstadosProductosPersoanlizados.Where(x =>
            x.IdDetalleEstadosProductosPersoanlizados == id).ToListAsync();

        public async Task<DetalleEstadosSolicitudPersonalizada> AgregarDetalleEstadosSolicitudPersonalizada
            (DetalleEstadosSolicitudPersonalizada DetalleEstadosSolicitudPersonalizada)
        {
            _context.DetalleEstadosSolicitudPersonalizada.Add(DetalleEstadosSolicitudPersonalizada);
            await _context.SaveChangesAsync();
            return DetalleEstadosSolicitudPersonalizada;
        }

        public async Task<ActionResult<IEnumerable<DetalleEstadosSolicitudPersonalizada>>>
            ListarDetalleEstadosSolicitudPersonalizada() =>
            await _context.DetalleEstadosSolicitudPersonalizada.ToListAsync();

        public async Task<ActionResult<IEnumerable<DetalleEstadosSolicitudPersonalizada>>>
            ListaDetalleEstadosSolicitudPersonalizada(int id) =>
            await _context.DetalleEstadosSolicitudPersonalizada.Where(x =>
            x.IdDetalleEstadoSolicitudPersonalizada == id).ToListAsync();

        public async Task<DetalleProductosSolicitud> AgregarDetalleProductosSolicitud
            (DetalleProductosSolicitud DetalleProductosSolicitud)
        {
            _context.DetalleProductosSolicitud.Add(DetalleProductosSolicitud);
            await _context.SaveChangesAsync();
            return DetalleProductosSolicitud;
        }

        public async Task<ActionResult<IEnumerable<DetalleProductosSolicitud>>> ListarDetalleProductosSolicitud() =>
            await _context.DetalleProductosSolicitud.ToListAsync();

        public async Task<ActionResult<IEnumerable<DetalleProductosSolicitud>>> ListaDetalleProductosSolicitud(int id) =>
            await _context.DetalleProductosSolicitud.Where(x => x.IdDetalleProductosSolicitud == id).ToListAsync();

        public async Task EliminarDetalleProductosSolicitud(int id)
        {
            DetalleProductosSolicitud DetalleProductosSolicitud = await _context.DetalleProductosSolicitud.FindAsync(id);
            _context.DetalleProductosSolicitud.Remove(DetalleProductosSolicitud);
            await _context.SaveChangesAsync();
        }

        public async Task<DetallesMaterialesMontajes> AgregarDetallesMaterialesMontajes
            (DetallesMaterialesMontajes DetallesMaterialesMontajes)
        {
            _context.DetallesMaterialesMontajes.Add(DetallesMaterialesMontajes);
            await _context.SaveChangesAsync();
            return DetallesMaterialesMontajes;
        }

        public async Task<ActionResult<IEnumerable<DetallesMaterialesMontajes>>> ListarDetallesMaterialesMontajes() =>
            await _context.DetallesMaterialesMontajes.ToListAsync();

        public async Task<ActionResult<IEnumerable<DetallesMaterialesMontajes>>>ListaDetallesMaterialesMontajes(int id)=>
            await _context.DetallesMaterialesMontajes.Where(x => x.IdDetallesMaterialesMontajes == id).ToListAsync();

        public async Task EliminarDetallesMaterialesMontajes(int id)
        {
            DetallesMaterialesMontajes DetallesMaterialesMontajes = 
                await _context.DetallesMaterialesMontajes.FindAsync(id);
            _context.DetallesMaterialesMontajes.Remove(DetallesMaterialesMontajes);
            await _context.SaveChangesAsync();
        }

        public async Task<DetallesMaterialesSolicitudesPersonalizadas> AgregarDetallesMaterialesSolicitudesPersonalizadas
            (DetallesMaterialesSolicitudesPersonalizadas DetallesMaterialesSolicitudesPersonalizadas)
        {
            _context.DetallesMaterialesSolicitudesPersonalizadas.Add(DetallesMaterialesSolicitudesPersonalizadas);
            await _context.SaveChangesAsync();
            return DetallesMaterialesSolicitudesPersonalizadas;
        }

        public async Task<ActionResult<IEnumerable<DetallesMaterialesSolicitudesPersonalizadas>>> 
            ListarDetallesMaterialesSolicitudesPersonalizadas() =>
            await _context.DetallesMaterialesSolicitudesPersonalizadas.ToListAsync();

        public async Task<ActionResult<IEnumerable<DetallesMaterialesSolicitudesPersonalizadas>>> 
            ListaDetallesMaterialesSolicitudesPersonalizadas(int id) =>
            await _context.DetallesMaterialesSolicitudesPersonalizadas.Where(x => 
            x.IdDetallesMaterialesSolicitudesPersonalizadas == id).ToListAsync();

        public async Task EliminarDetallesMaterialesSolicitudesPersonalizadas(int id)
        {
            DetallesMaterialesSolicitudesPersonalizadas DetallesMaterialesSolicitudesPersonalizadas =
                await _context.DetallesMaterialesSolicitudesPersonalizadas.FindAsync(id);
            _context.DetallesMaterialesSolicitudesPersonalizadas.Remove(DetallesMaterialesSolicitudesPersonalizadas);
            await _context.SaveChangesAsync();
        }

        public async Task<DetallesProductosMontajes> AgregarDetallesProductosMontajes
            (DetallesProductosMontajes DetallesProductosMontajes)
        {
            _context.DetallesProductosMontajes.Add(DetallesProductosMontajes);
            await _context.SaveChangesAsync();
            return DetallesProductosMontajes;
        }

        public async Task<ActionResult<IEnumerable<DetallesProductosMontajes>>> ListarDetallesProductosMontajes() =>
            await _context.DetallesProductosMontajes.ToListAsync();

        public async Task<ActionResult<IEnumerable<DetallesProductosMontajes>>> ListaDetallesProductosMontajes(int id) =>
            await _context.DetallesProductosMontajes.Where(x => x.IdDetallesProductosMontajes == id).ToListAsync();

        public async Task EliminarDetallesProductosMontajes(int id)
        {
            DetallesProductosMontajes DetallesProductosMontajes = await _context.DetallesProductosMontajes.FindAsync(id);
            _context.DetallesProductosMontajes.Remove(DetallesProductosMontajes);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Montajes>>> ListarMontajes() => await _context.Montajes.ToListAsync();

        public async Task<Montajes> BuscarMontajes(int id) => await _context.Montajes.FindAsync(id);

        public async Task<Montajes> AgregarMontajes (Montajes Montajes)
        {
            _context.Montajes.Add(Montajes);
            await _context.SaveChangesAsync();
            return Montajes;
        }

        public async Task<Montajes> EditarMontajes (Montajes Montajes)
        {
            _context.Montajes.Update(Montajes);
            await _context.SaveChangesAsync();
            return Montajes;
        }

        public async Task<PrecioMontajes> AgregarPrecioMontajes (PrecioMontajes PrecioMontajes)
        {
            _context.PrecioMontajes.Add(PrecioMontajes);
            await _context.SaveChangesAsync();
            return PrecioMontajes;
        }

        public async Task<ActionResult<IEnumerable<PrecioMontajes>>> ListarPrecioMontajes() =>
            await _context.PrecioMontajes.ToListAsync();

        public async Task<ActionResult<IEnumerable<PrecioMontajes>>> ListaPrecioMontajes(int id) =>
            await _context.PrecioMontajes.Where(x => x.IdMontaje == id).ToListAsync();

    }
}