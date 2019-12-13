using System;
using System.Collections.Generic;

namespace Oncologia.Domain.Entities {
  public class FormField {

    public FormField()
    {
        FormValidation = new List<FormValidation>();
    }
    public int FormFieldId { get; set; }
    public string FormName { get; set; }
    public string KeyField { get; set; }
    public string ValueField { get; set; }
    public string Label { get; set; }
    public int? Order { get; set; }
    public int? ColumnsSize { get; set; }
    public string ControlType { get; set; }

    public List<FormValidation> FormValidation { get; private set; }
  }
}