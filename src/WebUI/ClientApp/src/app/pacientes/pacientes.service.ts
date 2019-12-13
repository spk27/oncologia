import { Injectable }       from '@angular/core';
import { QuestionBase } from '../shared/dynamic-forms/question-base';
import { DropdownQuestion } from '../shared/dynamic-forms/ControlTypes/question-dropdown';
import { TextboxQuestion } from '../shared/dynamic-forms/ControlTypes/question-textbox';
import { FormsClient, FormListVm } from 'src/app/oncologia-api';

@Injectable()
export class PacientesService {
    private _formClient: FormsClient;

    getForm() {
        let resultForm: FormListVm;
        
        this._formClient.get('createPaciente').subscribe(result => {
            resultForm = result;
          }, error => console.error(error));

        return resultForm;
    }

  upsertPacienteQuestion() {
    let pacienteUpsertForm: QuestionBase<any>[] = [];
    let form = this.getForm();

    form.formulario.forEach(question => {
        let field: QuestionBase<any>;
        switch (question.controlType) {
            case 'textbox':
                field = new TextboxQuestion({
                    key: question.keyField,
                    label: question.label,
                    value: question.valueField,
                    validators: question.validations,
                    order: question.order
                })
                break;
            case 'dropdown':
                
                break;
        
            default:
                break;
        }
    });
    /*
    let pacienteTemp = new UpsertPacienteCommand ({
        primerNombre: "",
        segundoNombre: "",
        primerApellido: "",
        segundoApellido: "",
        cedula: "",
        tipoCedula: 'C'
    });

    const attributes = Object.getOwnPropertyNames(pacienteTemp);

    attributes.forEach(attr => {
        var field: QuestionBase<any>;
        console.log(typeof pacienteTemp[attr]);
        switch (typeof(pacienteTemp[attr])) {
            case 'number':
                field = new TextboxQuestion({
                    key: attr,
                    label: attr,
                    value: 0,
                    validators: {
                        required: true,
                        maxLength: 10
                    },
                    order: 1
                })
                break;
        
            default: // String
                field = new TextboxQuestion({
                    key: attr,
                    label: attr,
                    value: 0,
                    validators: {
                        required: true,
                        maxLength: 10
                    },
                    order: 1
                })
                break;
        }

        pacienteUpsertForm.push(field);
    });
*/
    return pacienteUpsertForm.sort((a, b) => a.order - b.order);
  }
}