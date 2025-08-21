using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories.Interfaces
{
    public interface IGeneralRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        Task<T> GetByIdAsync<T>(Guid id) where T : class;
        Task<List<T>> GetAllAsync<T>() where T : class;
        Task<bool> SaveChangesAsync();
    }
}
