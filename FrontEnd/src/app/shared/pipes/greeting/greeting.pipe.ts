import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'greeting',
})
export class GreetingPipe implements PipeTransform {
  transform(name: string, gender: string = 'M', role: string = 'Usuario'): any {
    //const grt = (gender ==='F'? 'Bienvenida' : 'Bienvenido');
    let grt = '';

    switch (gender) {
      case 'F':
        grt = 'Bienvenida';
        break;
      case 'M':
        grt = 'Bienvenido';
        break;
      default:
        grt = 'Bienvenid@';
        break;
    }

    return `${grt} ${name}, tienes permisos de ${role}`;
  }
}
