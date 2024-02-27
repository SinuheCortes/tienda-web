import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    title: 'Inicio',
    loadComponent: () =>
      import('../app/pages/home-page/home-page.component').then(
        (c) => c.HomePageComponent
      ),
    children: [
      {
        path: 'clientes',
        title: 'Clientes',
        loadComponent: () =>
          import('../app/pages/clientes-page/clientes-page.component').then(
            (c) => c.ClientesPageComponent
          ),
      },
      {
        path: 'articulos',
        title: 'Articulos',
        loadComponent: () =>
          import('../app/pages/articulos-page/articulos-page.component').then(
            (c) => c.ArticulosPageComponent
          ),
      },
    ],
  },
];
