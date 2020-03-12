using System;
using System.Collections.Generic;

namespace Oncologia.Domain.Entities {
  public class Paciente {

    public int PacienteId { get; set; }
    public string PrimerNombre { get; set; }
    public string SegundoNombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public string Cedula { get; set; }
    public string TipoCedula { get; set; }

    public override string ToString() {
      return $"{PrimerNombre} {SegundoNombre} {PrimerApellido} {SegundoApellido}";
    }

    public string NombreCorto() {
      var Apellido = string.IsNullOrEmpty(PrimerApellido) ? "" : PrimerApellido.Substring(0, 1);
      return $"{PrimerNombre} {Apellido}.";
    }
  }
}