using Church.Domain.Entities;
using Church.Infrastructure.Context;
using Church.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church.Infrastructure.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly ChurchContext _churchContext;

        public AssetRepository(ChurchContext churchContext)
        {
            _churchContext = churchContext;
        }

        public async Task<Asset> GetAssetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Asset ID cannot be empty.", nameof(id));

            var asset = await _churchContext.Assets
                                             .Include(a => a.Type)
                                             .FirstOrDefaultAsync(x => x.Id == id);

            if (asset == null)
                throw new KeyNotFoundException($"Asset with ID {id} not found.");

            return asset;
        }

        public async Task<List<Asset>> GetAllAssetsAsync()
        {
            return await _churchContext.Assets.Include(a => a.Type)
                                              .ToListAsync();
        }

    }
}
