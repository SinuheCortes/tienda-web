import { Component, DestroyRef, Inject, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBar } from '@angular/material/snack-bar';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { FormularioCliente } from '../../interfaces/formulario-cliente.interface';
import { ClienteService } from '../../services/clientes.service';
import { Cliente } from '../../interfaces/cliente.interface';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'store-formulario-cliente',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatDialogModule,
  ],
  templateUrl: './formulario-cliente.component.html',
  styleUrl: './formulario-cliente.component.scss',
})
export class FormularioClienteComponent implements OnInit {
  public formulario!: FormGroup<FormularioCliente>;

  constructor(
    @Inject(MAT_DIALOG_DATA) public readonly idCliente: string | undefined,
    private readonly _clienteService: ClienteService,
    private readonly _notificador: MatSnackBar,
    private readonly _destructor: DestroyRef,
    private readonly _dialogo: MatDialogRef<FormularioClienteComponent>
  ) {}
  public ngOnInit(): void {
    this.definirFormulario();
    this.obtenerDatosIniciales();
  }

  public validar(): void {
    if (this.formulario.invalid) {
      this._notificador.open('¡Complete el formulario!', 'Entendido');
      return;
    }
    const datos = this.formulario.getRawValue() as Cliente;

    this.idCliente
      ? this.actualizar(datos, this.idCliente)
      : this.guardar(datos);
  }

  private obtenerDatosIniciales(): void {
    if (this.idCliente) {
      this._clienteService
        .obtenerUnico(this.idCliente)
        .pipe(takeUntilDestroyed(this._destructor))
        .subscribe({
          next: (cliente) => {
            this.definirFormulario(cliente);
          },
        });
    }
  }

  private definirFormulario(cliente?: Cliente): void {
    this.formulario = new FormGroup<FormularioCliente>({
      id: new FormControl<string>('00000000-0000-0000-0000-000000000000'),
      nombre: new FormControl<string | null>('', [
        Validators.required,
        Validators.maxLength(60),
      ]),
      apellidos: new FormControl<string>('', [
        Validators.required,
        Validators.maxLength(60),
      ]),
      direccion: new FormControl<string>('', [
        Validators.required,
        Validators.maxLength(150),
      ]),
    });

    if (cliente) {
      this.formulario.patchValue(cliente);
    }
  }

  private guardar(cliente: Cliente): void {
    this._clienteService
      .guardar(cliente)
      .pipe(takeUntilDestroyed(this._destructor))
      .subscribe({
        next: () => {
          this._notificador.open('Datos guardados', 'Entendido');
          this._dialogo.close(true);
        },
        error: () => {
          this._notificador.open('Ocurrió un error', 'Entendido');
        },
      });
  }

  private actualizar(cliente: Cliente, idCliente: string): void {
    this._clienteService
      .actualizar(cliente, idCliente)
      .pipe(takeUntilDestroyed(this._destructor))
      .subscribe({
        next: () => {
          this._notificador.open('Datos actualizados', 'Entendido');
          this._dialogo.close(true);
        },
        error: () => {
          this._notificador.open('Ocurrió un error', 'Entendido');
        },
      });
  }
}
