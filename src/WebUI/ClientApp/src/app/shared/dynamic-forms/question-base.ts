export class QuestionBase<T> {
    value: T;
    key: string;
    label: string;
    validators: {
        type: string;
        value: string;
    }[];
    order: number;
    controlType: string;
  
    constructor(options: {
        value?: T,
        key?: string,
        label?: string,
        validators?: {
            type: string;
            value: string;
        }[],
        order?: number,
        controlType?: string
      } = {}) {
      this.value = options.value;
      this.key = options.key || '';
      this.label = options.label || '';
      // this.required = !!options.required;
      this.order = options.order === undefined ? 1 : options.order;
      this.controlType = options.controlType || '';
      this.validators = options.validators;
      /*
      this.validators = options.validators === undefined ? null : {
        required: !!options.validators.required,
        maxLength: options.validators.maxLength === undefined ? undefined : options.validators.maxLength,
        minLength: options.validators.minLength == undefined ? undefined : options.validators.minLength,
        max: options.validators.max === undefined ? undefined : options.validators.max,
        min: options.validators.min === undefined ? undefined : options.validators.min
      };
      */
    }
  }