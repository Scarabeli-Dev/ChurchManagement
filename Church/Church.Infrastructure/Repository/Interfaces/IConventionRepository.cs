using Church.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church.Infrastructure.Repository.Interfaces
{
    public interface IConventionRepository
    {
        Task<Convention> GetConventionById(Guid id);
        Task<List<Convention>> GetAllConventions();
    }
}
