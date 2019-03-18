import { ConfiguracionesService } from './services/configuraciones/configuraciones.service';
import { EmpresaServiceService } from './services/empresa/empresa-service.service';
import { FamiliaresComponent } from './components/familiares/familiares.component';
import { PersonalService } from './services/personal/personal.service';
import { AuthenticationGuard } from './services/guards/authentication.guard';
import { LoginServiceService } from './services/login-service/login-service.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule} from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { MainSidebarComponent } from './main-sidebar/main-sidebar.component';
import { SettingsComponent } from './settings/settings.component';
import { LoginComponent } from './login/login.component';
import { PersonalesComponent } from './components/personales/personales.component';
import { TrabajadoresService } from './services/trabajadores/trabajadores.service';
import { EmpresasComponent } from './components/empresas/empresas.component';
import { AumentosComponent } from './components/aumentoSal/aumentoSal.component';
import { SaldofijoComponent } from './components/saldofijo/saldofijo.component';
import { NivelesComponent } from './components/niveles/niveles.component';
import { UsuarioComponent } from './components/usuarios/usuarios.component';
import { FuncionesComponent } from './components/funciones/funciones.component';

const routes = [
  { path: '', component: LoginComponent },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent, canActivate: [AuthenticationGuard] },
  { path: 'personales', component: PersonalesComponent, canActivate: [AuthenticationGuard] },
  { path: 'familiares', component: FamiliaresComponent, canActivate: [AuthenticationGuard] },
  { path: 'empresas', component: EmpresasComponent, canActivate: [AuthenticationGuard] },
  { path: 'historicoSueldos', component: AumentosComponent, canActivate: [AuthenticationGuard] },
  { path: 'saldoFijos', component: SaldofijoComponent, canActivate: [AuthenticationGuard] },
  { path: 'niveles', component: NivelesComponent, canActivate: [AuthenticationGuard] },
  // { path: 'counter', component: CounterComponent,CanActivate:[AuthenticationGuard] },
  // { path: 'fetch-data', component: FetchDataComponent,CanActivate:[AuthenticationGuard] },
  { path: 'usuarios', component: UsuarioComponent, canActivate: [AuthenticationGuard] },
  { path: 'funciones', component: FuncionesComponent, canActivate: [AuthenticationGuard] },
];

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    HeaderComponent,
    FooterComponent,
    MainSidebarComponent,
    SettingsComponent,
    LoginComponent,
    PersonalesComponent,
    FamiliaresComponent,
    EmpresasComponent,
    AumentosComponent,
    SaldofijoComponent,
    NivelesComponent,
    UsuarioComponent,
    FuncionesComponent

    //UsuariosComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [
    LoginServiceService,
    TrabajadoresService,
    EmpresaServiceService,
    ConfiguracionesService,
    AuthenticationGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
