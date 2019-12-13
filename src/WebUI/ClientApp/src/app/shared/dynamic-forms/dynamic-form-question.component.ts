import { Component, Input } from '@angular/core';
import { FormGroup }        from '@angular/forms';

import { QuestionBase }     from './question-base';

@Component({
  selector: 'app-question',
  templateUrl: './dynamic-form-question.component.html'
})
export class DynamicFormQuestionComponent {
  @Input() question: QuestionBase<any>;
  @Input() form: FormGroup;
  get isValid() { return this.form.controls[this.question.key].valid; }
  get errors() { 
    if(!this.isValid) {
      let errs: String = '';
      let formErrors = this.form.controls[this.question.key].errors;
      let validations = Object.getOwnPropertyNames(formErrors);
      // console.log(JSON.stringify(formErrors));
      validations.forEach(val => {
        switch (val) {
          case 'required':
            errs += 'Este elemento es requerido\n';
          break;
          case 'maxlength':
            errs += 'Ha superado el límite de caracteres permitidos\n';
          break;
          case 'minlength':
            errs += 'Muy pocos caracteres\n';
          break;
          case 'max':
              errs += 'Ha superado el valor permitido\n';
            break;
          case 'min':
              errs += 'Monto o valor no cumple el mínimo permitido\n';
            break;
          default:
            break;
        }
      });

      return errs;
    }

    return null;
  }

  set errors(val) {
    this.errors = val;
  }
}