using EfCore.Data;
using EfCore.Models.Requests;
using EfCore.Service.Interface;

namespace EfCore.Service
{
    public abstract class GenericService : IShopService
    {
        public Task<GetShopResponse> CreateAsync(CreatedShopRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetShopResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetShopResponse?> GetShopByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetShopResponse> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
