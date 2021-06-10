import { Component, OnInit } from '@angular/core';
import {UsuarioService} from '../../../../../../../../services/usuario.service';
import {ActivatedRoute, Router} from '@angular/router';
import {ProductoService} from '../../../../../../../../services/producto.service';
import {ConfiguracionService} from '../../../../../../../../services/configuracion.service';
import {SolicitudesPersonalizadasService} from '../../../../../../../../services/solicitudes-personalizadas.service';
import {Usuario} from '../../../../../../../../models/usuario';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-agregar-precio-m',
  templateUrl: './agregar-precio-m.component.html',
  styleUrls: ['./agregar-precio-m.component.css']
})
export class AgregarPrecioMComponent implements OnInit {

  constructor(public usuarioService: UsuarioService, private router: Router,
              public productoService: ProductoService, public configuracion: ConfiguracionService,
              private rutaActiva: ActivatedRoute,
              public solicitudesPersonalizadasService: SolicitudesPersonalizadasService,
              public toastr: ToastrService) {
  }

  id: number = this.rutaActiva.snapshot.params.IdMontaje;
  ngOnInit(): void {
    this.productoService.formularioRegistroPrecio.patchValue(this.productoService.precio);
  }

  registro(): void {
    this.usuarioService.obtenerPerfil().subscribe(
      res => {
        this.productoService.precio = this.productoService.formularioRegistroPrecio.value;
        this.productoService.precio.IdUsuario = (res as Usuario).Id;
        this.productoService.registroPrecio().subscribe(
          (respuesta: any) => {
            this.toastr.success('Se registró el precio exitosamente', 'Registro precio');
            this.productoService.formularioRegistroPrecio.reset();
            this.productoService.FormularioPrecio = false;
            this.productoService.listarPrecios(this.productoService.precio.IdProducto);
            this.productoService.buscarProductoIdDetalle(this.productoService.precio.IdProducto);
            this.solicitudesPersonalizadasService.BuscarMontajes(this.id);
          }, error => {
            alert(error);
            console.log(error);
          });
      },
      err => {
        console.log(err);
      }
    );
  }

}
