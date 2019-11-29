using AutoMapper;
using Oncologia.Application.Common.Mappings;
using Oncologia.Domain.Entities;

namespace Oncologia.Application.Pacientes.Queries.GetPacienteDetail {
    public class PacienteDetailVm : IMapFrom<Paciente> {
        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Cedula { get; set; }
        public char TipoCedula { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Paciente, PacienteDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.PacienteId));
        }
    }
}