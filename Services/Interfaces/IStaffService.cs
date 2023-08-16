using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Services.Interfaces
{
    public interface IStaffService
    {
        Task<GetStaffResponse> CreateStaffAsync(CreateStaffRequest request);
        Task<IEnumerable<GetStaffResponse>> GetAllStaffAsync();
        Task<GetStaffResponse?> GetStaffByIdAsync(int id);
        Task<GetStaffResponse?> UpdateStaffAsync(int id,UpdateStaffRequest request);
        Task<bool> DeleteStaffAsync(int id);
    }
}
