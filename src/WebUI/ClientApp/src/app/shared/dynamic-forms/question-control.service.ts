import { Injectable }   from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { QuestionBase } from './question-base';

@Injectable()
export class QuestionControlService {
  constructor() { }

  toFormGroup(questions: QuestionBase<any>[] ) {
    let group: any = {};
    let validations: any = [];
    questions.forEach(question => {
      // let validationsKeys = Object.getOwnPropertyNames(question.validators);
      // console.log(JSON.stringify(validationsKeys));
      question.validators.forEach(val => {
        switch (val.type) {
          case 'required':
              validations.push(Validators.required);
            break;
          case 'maxLength':
              validations.push(Validators.maxLength(parseInt(val.value)));
            break;
          case 'minLength':
              validations.push(Validators.minLength(parseInt(val.value)));
            break;
          case 'max':
              validations.push(Validators.max(parseInt(val.value)));
            break;
          case 'min':
              validations.push(Validators.min(parseInt(val.value)));
            break;
          default:
            break;
        }
      });
      group[question.key] = new FormControl(question.value || '', validations);
    });
    return new FormGroup(group);
  }
}