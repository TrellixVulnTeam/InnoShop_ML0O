import {Component, OnInit} from '@angular/core';
import {Usuario} from 'src/app/models/usuario';
import {SolicitudesPersonalizadasService} from 'src/app/services/solicitudes-personalizadas.service';
import {UsuarioService} from 'src/app/services/usuario.service';

@Component({
  selector: 'app-listar-mis-solicitudes-personalizadas',
  templateUrl: './listar-mis-solicitudes-personalizadas.component.html',
  styleUrls: ['./listar-mis-solicitudes-personalizadas.component.css']
})
export class ListarMisSolicitudesPersonalizadasComponent implements OnInit {

  constructor(public solicitudesPersonalizadasService: SolicitudesPersonalizadasService,
              public usuarioService: UsuarioService) {
  }

  ngOnInit(): void {
    this.usuarioService.obtenerPerfil().subscribe(
      res => {
        this.solicitudesPersonalizadasService.ListarMisSolicitudPersonalizada((res as Usuario).Id);
        console.log(this.solicitudesPersonalizadasService.listaSolicitudPersonalizada);
      },
      err => {
        console.log(err);
      }
    );
  }

}
