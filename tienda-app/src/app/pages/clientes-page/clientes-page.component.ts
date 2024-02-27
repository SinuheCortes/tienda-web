import { Component, DestroyRef, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import {
  MatDialog,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';

import { Cliente } from '../../interfaces/cliente.interface';
import { ClienteService } from '../../services/clientes.service';
import { FormularioClienteComponent } from '../../components/formulario-cliente/formulario-cliente.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'store-clientes-page',
  standalone: true,
  imports: [
    MatCardModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
  ],
  templateUrl: './clientes-page.component.html',
  styleUrl: './clientes-page.component.scss',
})
export class ClientesPageComponent implements OnInit {
  public readonly columnas = ['nombre', 'apellidos', 'direccion', 'id'];
  public clientes!: MatTableDataSource<Cliente>;
  private referenciaFormularioCliente!: MatDialogRef<FormularioClienteComponent>;

  constructor(
    private readonly _clienteService: ClienteService,
    private readonly _destructor: DestroyRef,
    private readonly _dialogo: MatDialog,
    private readonly _notificador: MatSnackBar
  ) {}

  public ngOnInit(): void {
    this.obtener();
  }

  public mostrarFormulario(idCliente?: string): void {
    this.referenciaFormularioCliente = this._dialogo.open(
      FormularioClienteComponent,
      {
        data: idCliente,
        minWidth: '90%',
      }
    );

    this.referenciaFormularioCliente
      .afterClosed()
      .pipe(takeUntilDestroyed(this._destructor))
      .subscribe((requiereActualizacionClientes: boolean) => {
        if (requiereActualizacionClientes) {
          this.obtener();
        }
      });
  }

  public confirmarEliminacion(idCliente: string): void {
    const snackBarRef = this._notificador.open(
      'Eliminando Cliente',
      'Cancelar'
    );

    snackBarRef.afterDismissed().subscribe((dismissedEvent) => {
      if (dismissedEvent.dismissedByAction) {
        this._notificador.open('Operación cancelada', 'Entendido');
      } else {
        this.eliminar(idCliente);
      }
    });
  }

  private obtener(): void {
    this._clienteService
      .obtener()
      .pipe(takeUntilDestroyed(this._destructor))
      .subscribe({
        next: (clientes) => {
          this.clientes = new MatTableDataSource<Cliente>(clientes);
        },
      });
  }

  private eliminar(idCliente: string): void {
    this._clienteService
      .eliminar(idCliente)
      .pipe(takeUntilDestroyed(this._destructor))
      .subscribe({
        next: () => {
          this.obtener();
        },
        error: () => {
          this._notificador.open('Ocurrió un error', 'Entendido');
        },
      });
  }
}
