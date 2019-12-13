using System;
using System.Collections.Generic;

namespace Oncologia.Domain.Entities {
  public class FormValidation {
    public int FormFieldId { get; set; }
    public int ValidationdId { get; set; }

    public FormField FormField { get; set; }    
    public Validation Validation { get; set; }
  }
}