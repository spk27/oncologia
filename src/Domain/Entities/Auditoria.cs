
using System;

namespace Oncologia.Domain.Entities {
  public class Auditoria {
    public int Id { get; set; }
    public DateTime FechaYHora { get; set; }
    public string Usuario { get; set; }
    public string Accion { get; set; }
    public bool EsError { get; set; }
    public string Mensaje { get; set; }
  }
}