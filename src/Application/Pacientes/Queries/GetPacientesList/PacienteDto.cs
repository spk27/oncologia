using AutoMapper;
using Oncologia.Application.Common.Mappings;
using Oncologia.Domain.Entities;

namespace Oncologia.Application.Pacientes.Queries.GetPacientesList
{
    public class PacienteDto : IMapFrom<Paciente>
    {
        public int Id { get; set; }

        public string NombreCorto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Paciente, PacienteDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.PacienteId))
                .ForMember(d => d.NombreCorto, opt => 
                    opt.MapFrom(s => $"{s.PrimerNombre} {s.PrimerApellido.Substring(0, 1)}."));
        }
    }
}
