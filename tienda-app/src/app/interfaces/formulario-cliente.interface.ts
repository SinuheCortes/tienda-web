import { FormControl } from '@angular/forms';

export interface FormularioCliente {
  id: FormControl<string | null>;
  nombre: FormControl<string | null>;
  apellidos: FormControl<string | null>;
  direccion: FormControl<string | null>;
}
