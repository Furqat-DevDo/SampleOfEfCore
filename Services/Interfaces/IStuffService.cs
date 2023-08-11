using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Services.Interfaces
{
    public interface IStuffService
    {
        Task<IEnumerable<GetStuffRespons>> GetStuff();
        Task<GetStuffRespons> GetStuffRespons(int id);
        Task<GetStuffRespons> CreateStuff(CreateStuffRequest request);
        Task<GetStuffRespons> UpdateStuff(int id,UpdateStuffRequest request);
        Task<GetStuffRespons> DeleteStuf(int id);
    }
}
