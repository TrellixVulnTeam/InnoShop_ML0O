import { Component, OnInit } from '@angular/core';
import { ConfiguracionService } from 'src/app/servicios/configuracion.service';
import { UsuarioService } from 'src/app/servicios/usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-restablecimiento',
  templateUrl: './restablecimiento.component.html',
  styleUrls: ['./restablecimiento.component.css']
})
export class RestablecimientoComponent implements OnInit {

  constructor(public usuarioService:UsuarioService, public configuracion:ConfiguracionService, private router:Router) { }

  ngOnInit(): void {
  }

  restablecer(){

    this.usuarioService.restablecimientoContrasena().subscribe(
      (res)=>{
        console.log(res);
        alert("se envio el codigo al correo");
  
      },
      error =>{
        if(error.status == 200){
          this.router.navigateByUrl('usuarios/verificacion');
        }else{
          alert("Error");
        }

      })
  }
}