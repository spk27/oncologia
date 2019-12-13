using System;
using System.Collections.Generic;

namespace Oncologia.Domain.Entities {
  public class Validation {

    public Validation()
    {
        FormValidation = new List<FormValidation>();
    }
    public int ValidationId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string ValidationValue { get; set; }
    public string Regex { get; set; }

    public List<FormValidation> FormValidation { get; private set; }
  }
}