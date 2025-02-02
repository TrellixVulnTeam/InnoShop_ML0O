import { Component, OnInit } from '@angular/core';
import {ProductoService} from '../../../../../../../../services/producto.service';
import {UsuarioService} from '../../../../../../../../services/usuario.service';
import {Usuario} from '../../../../../../../../models/usuario';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-agregar-material-m',
  templateUrl: './agregar-material-m.component.html',
  styleUrls: ['./agregar-material-m.component.css']
})
export class AgregarMaterialMComponent implements OnInit {

  constructor(public productoService: ProductoService,
              public usuarioService: UsuarioService,
              public toastr: ToastrService) {
  }

  ngOnInit(): void {
    this.productoService.listarMateriales();
  }

  registrarDetalle(): void  {
    this.usuarioService.obtenerPerfil().subscribe(
      res => {
        this.productoService.DetalleMaterial = this.productoService.formularioRegistroDetalleMaterial.value;
        this.productoService.DetalleMaterial.IdUsuario = (res as Usuario).Id;
        this.productoService.RegistrarDetalleMaterial().subscribe(
          (respuesta: any) => {
            this.toastr.success('Se registró el material exitosamente', 'Registro material');
            this.productoService.ListarDetalleMaterial(this.productoService.DetalleMaterial.IdProducto);
            this.productoService.tablaDetalleMateriales = true;
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
