using System;
using Oncologia.Persistence;

namespace Oncologia.Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly OncologiaDbContext _context;

        public CommandTestBase()
        {
            _context = OncologiaContextFactory.Create();
        }

        public void Dispose()
        {
            OncologiaContextFactory.Destroy(_context);
        }
    }
}