using EfCore.Models.Requests;

namespace EfCore.Service.Interface
{
    public interface IShopService
    {
        public Task<GetShopResponse> CreateAsync(CreatedShopRequest request);

        public Task<GetShopResponse> UpdateAsync(int id);
        public Task<bool> DeleteAsync(int id);
        public Task<GetShopResponse?> GetShopByIdAsync(int id);
        public Task<IEnumerable<GetShopResponse>> GetAllAsync();

    }
}
