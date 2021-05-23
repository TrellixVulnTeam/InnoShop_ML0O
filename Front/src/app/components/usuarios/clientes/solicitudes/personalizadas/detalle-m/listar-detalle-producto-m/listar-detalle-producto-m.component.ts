import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {SolicitudesPersonalizadasService} from '../../../../../../../services/solicitudes-personalizadas.service';
import {ProductoService} from '../../../../../../../services/producto.service';

@Component({
  selector: 'app-listar-detalle-producto-m',
  templateUrl: './listar-detalle-producto-m.component.html',
  styleUrls: ['./listar-detalle-producto-m.component.css']
})
export class ListarDetalleProductoMComponent implements OnInit {

  constructor(private rutaActiva: ActivatedRoute,
              public solicitudesPersonalizadasService: SolicitudesPersonalizadasService,
              private router: Router, public productoService: ProductoService) {
  }

  id: number = this.rutaActiva.snapshot.params.IdMontaje;

  ngOnInit(): void {
    this.solicitudesPersonalizadasService.ListaDetallesProductosMontajes(this.id);
  }

  detalleProducto(id): void {
    this.productoService.buscarProductoIdDetalle(id);
    this.productoService.listarPrecios(id);
    alert(id);
    this.productoService.listarImagen(id);
    this.productoService.ListarDetalleMaterial(id);
    this.productoService.listarEntradas(id);
  }

}
