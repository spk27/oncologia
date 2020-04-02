using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Oncologia.Application.Common.Interfaces;
using Oncologia.Domain.Entities;
using Oncologia.Persistence;
using Shouldly;
using Xunit;

namespace Persistence.IntegrationTests
{
    public class OncologiaDbContextTests : IDisposable
    {
        private readonly OncologiaDbContext _sut;

        public OncologiaDbContextTests()
        {
            // Con Base de Datos real
            /*
            var SetBasePath = Directory.GetCurrentDirectory();
            var baseWeb = SetBasePath.Split("tests")[0] + "src\\WebUI";
            var config = new ConfigurationBuilder()
                .SetBasePath(baseWeb)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
                
            var options = new DbContextOptionsBuilder<OncologiaDbContext>()
                .UseSqlServer(config["ConnectionStrings:OncologiaDatabase"])
                .Options;
            */

            // Base de datos en memoria
            var options = new DbContextOptionsBuilder<OncologiaDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _sut = new OncologiaDbContext(options);
        }
        
        [Fact]
        public async Task SaveChangesAsync_GivenNewPaciente_ShouldSetPacienteId()
        {
            var paciente = new Paciente {
                PrimerNombre = "Daniel"
                ,PrimerApellido = "Aguilar"
                ,TipoCedula = "CE"
                , Cedula = "1028999"
            };

            _sut.Pacientes.Add(paciente);

            await _sut.SaveChangesAsync();

            paciente.PacienteId.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task SaveChangesAsync_GivenExistingPaciente_ShouldDeleteThem()
        {
            var pacientes = _sut.Pacientes.Where(p => p.Cedula == "1028999").ToList();

            if(pacientes == null) {
                pacientes.Count.ShouldBe(0);
            } else {
                _sut.Pacientes.RemoveRange(pacientes);

                await _sut.SaveChangesAsync();

                var pacientesDeleted = _sut.Pacientes.Where(p => p.Cedula == "1028999").ToList();

                pacientesDeleted.Count.ShouldBe(0);
            }


        }

        public void Dispose()
        {
            _sut?.Dispose();
        }
    }
}