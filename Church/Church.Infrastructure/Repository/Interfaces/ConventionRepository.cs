using Church.Domain.Entities;
using Church.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church.Infrastructure.Repository.Interfaces
{
    public class ConventionRepository : IConventionRepository
    {
        private readonly ChurchContext _churchContext;
        public ConventionRepository(ChurchContext churchContext)
        {
            _churchContext = churchContext;
        }
        public async Task<List<Convention>> GetAllConventions()
        {
            return await _churchContext.Conventions.Include(x => x.Church).ToListAsync();
        }

        public Task<Convention> GetConventionById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
