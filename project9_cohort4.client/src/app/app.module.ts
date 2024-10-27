import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, NgForm } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './batool/home/home.component';
import { NavBarComponent } from './batool/nav-bar/nav-bar.component';
import { GetAllComponent } from './batool/get-all/get-all.component';
import { RouterModule } from '@angular/router';
import { GetByIdComponent } from './batool/get-by-id/get-by-id.component';
import { AddAnimalComponent } from './batool/add-animal/add-animal.component';
import { UpdateInfoComponent } from './batool/update-info/update-info.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavBarComponent,
    GetAllComponent,
    GetByIdComponent,
    AddAnimalComponent,
    UpdateInfoComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    FormsModule,
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    RouterModule.forRoot([

      { path: "", component: HomeComponent, pathMatch: "full" },

      { path : "getAllUsers" , component : GetAllComponent},
      { path : "getbyId/:id11" , component : GetByIdComponent},
      { path : "addAnimal" , component : AddAnimalComponent},
      { path: "UpdateAnimal/:id", component: UpdateInfoComponent },
      { path: "login", component: LoginComponent },
      { path: "register", component:RegisterComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
