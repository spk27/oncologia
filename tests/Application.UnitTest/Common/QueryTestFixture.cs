using System;
using AutoMapper;
using Oncologia.Application.Common.Mappings;
using Oncologia.Persistence;
using Xunit;

namespace Oncologia.Application.UnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public OncologiaDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = OncologiaContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            OncologiaContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}