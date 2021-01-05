import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FilmesComponent } from './filmes/filmes.component';

const routes: Routes = [
  {
    path: 'filmes',
    component: FilmesComponent,
    data: { title: 'Lista de Filmes' }
  },
  { path: '', redirectTo: '/filmes', pathMatch: 'full' },
 
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 
  
}
