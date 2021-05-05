import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { UsuariosModule}from './components/usuarios/usuarios.module';
import { ClientesModule } from './components/usuarios/clientes/clientes.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ListaUsuariosComponent } from './components/admin/usuarios/lista-usuarios/lista-usuarios.component';
import { RegistroUsuarioComponent } from './components/admin/usuarios/registro-usuario/registro-usuario.component';
import { VistasAdminComponent } from './components/admin/vistas-admin.component';
import { InicioadminComponent } from './components/admin/inicioadmin/inicioadmin.component';
import { UsuarioService } from './services/usuario.service';
import { ConfiguracionService } from './services/configuracion.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './auth/auth.interceptor';
import { GestionUsuarioComponent } from './components/admin/usuarios/gestion-usuario/gestion-usuario.component';
import { DetalleUsuarioComponent} from './components/admin/usuarios/detalle-usuario/detalle-usuario.component';
import { GestionProductosComponent } from './components/admin/productos/gestion-productos/gestion-productos.component';
import { DetalleProductosComponent } from './components/admin/productos/detalle-productos/detalle-productos.component';
import { RegistroEditarProductosComponent } from './components/admin/productos/registro-editar-productos/registro-editar-productos.component';
import { ListaProductosComponent } from './components/admin/productos/lista-productos/lista-productos.component';
import { GestionIvaComponent } from './components/admin/productos/iva/gestion-iva/gestion-iva.component';
import { RegistrarIvaComponent } from './components/admin/productos/iva/registrar-iva/registrar-iva.component';
import { ListarIvaComponent } from './components/admin/productos/iva/listar-iva/listar-iva.component';
import { RegistrarPrecioComponent } from './components/admin/productos/precio/registrar-precio/registrar-precio.component';
import { ListarImagenComponent } from './components/admin/productos/imagen/listar-imagen/listar-imagen.component';
import { RegistrarImagenComponent } from './components/admin/productos/imagen/registrar-imagen/registrar-imagen.component';
import { ListarPrecioComponent } from './components/admin/productos/precio/listar-precio/listar-precio.component';
import { RegistroDetalleMaterialComponent } from './components/admin/productos/registro-detalle-material/registro-detalle-material.component';
import { ListarDetalleMaterialComponent } from './components/admin/productos/listar-detalle-material/listar-detalle-material.component';
import { ListarEntradasComponent } from './components/admin/productos/Entrada/listar-entradas/listar-entradas.component';
import { RegistrarEntradaComponent } from './components/admin/productos/Entrada/registrar-entrada/registrar-entrada.component';
import { OwlModule } from 'ngx-owl-carousel';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { SolicitudesModule} from './components/admin/solicitudes/solicitudes.module'
import { ListarPorcentajesComponent } from './components/admin/descuentos/listar-porcentajes/listar-porcentajes.component';
import { GestionRuletaComponent } from './components/admin/descuentos/gestion-ruleta/gestion-ruleta.component';
import { RegistrarPorcentajeComponent } from './components/admin/descuentos/registrar-porcentaje/registrar-porcentaje.component';
import { ListarValorRuletaComponent } from './components/admin/descuentos/listar-valor-ruleta/listar-valor-ruleta.component';
import { RegistrarValorRuletaComponent } from './components/admin/descuentos/registrar-valor-ruleta/registrar-valor-ruleta.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import{DescuentosModule}from './components/admin/descuentos/descuentos.module'
import{VentasModule}from './components/admin/ventas/ventas.module'


@NgModule({
  declarations: [
    AppComponent,
    ListaUsuariosComponent,
    RegistroUsuarioComponent,
    VistasAdminComponent,
    InicioadminComponent,
    GestionUsuarioComponent,
    DetalleUsuarioComponent,
    GestionProductosComponent,
    DetalleProductosComponent,
    RegistroEditarProductosComponent,
    ListaProductosComponent,
    GestionIvaComponent,
    RegistrarIvaComponent,
    ListarIvaComponent,
    RegistrarPrecioComponent,
    ListarImagenComponent,
    RegistrarImagenComponent,
    ListarPrecioComponent,
    RegistroDetalleMaterialComponent,
    ListarDetalleMaterialComponent,
    ListarEntradasComponent,
    RegistrarEntradaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UsuariosModule,
    ClientesModule,
    FormsModule,
    ReactiveFormsModule,
    OwlModule,
    CarouselModule,
    SolicitudesModule,
    BrowserAnimationsModule,
    DescuentosModule,
    VentasModule
  ],
  providers: [UsuarioService, ConfiguracionService,{
    provide:HTTP_INTERCEPTORS,
    useClass:AuthInterceptor,
    multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
