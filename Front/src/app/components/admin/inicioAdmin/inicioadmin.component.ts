import {
  Component,
  OnInit
} from '@angular/core';
import {
  Router
} from '@angular/router';
import {
  PerfilUsuario
} from 'src/app/models/perfil-usuario';
import {
  ConfiguracionService
} from 'src/app/services/configuracion.service';
import {
  UsuarioService
} from 'src/app/services/usuario.service';

@Component({
  selector: 'app-inicioadmin',
  templateUrl: './inicioadmin.component.html',
  styleUrls: ['./inicioadmin.component.css']
})
export class InicioadminComponent implements OnInit {
  constructor(private router: Router, private usuarioService: UsuarioService, public configuracionService: ConfiguracionService) {}
  perfilUsuario: PerfilUsuario
  ngOnInit() {
    this.usuarioService.obtenerPerfil().subscribe(
      res => {
        this.perfilUsuario = < PerfilUsuario > res;
        this.perfilUsuario = < PerfilUsuario > res;
        if (this.perfilUsuario.IdRol == 2)
          this.router.navigate(['/usuarios/inicio']);
        if (!this.perfilUsuario.Estado) {
          alert("Usuario Inactivo")
          this.configuracionService.cerrarSesion()
        }
      },
      err => {
        console.log(err);
      }
    );
  }
 Usuarios=false;
datos=false;


  GestionUsuario(){
    this.Usuarios=true;
    this.datos=false;
    
  }
  cambioDatosP(){
    this.Usuarios=false;
    this.datos=true;
  }

}