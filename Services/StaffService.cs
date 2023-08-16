using EfCore.Data;
using EfCore.Entities;
using EfCore.Mappers;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Services
{
    public class StaffService : IStaffService
    {
        private readonly ShopDbContext _context;
        public StaffService(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<GetStaffResponse> CreateStaffAsync(CreateStaffRequest request)
        {
            var staff = request.StaffCreate();

            var newStaff = await _context.Staffs.AddAsync(staff);
            await _context.SaveChangesAsync();

            return newStaff.Entity.StaffResponse();
        }

        public async Task<bool> DeleteStaffAsync(int id)
        {
            var staff = await _context
                .Staffs
                .FirstOrDefaultAsync(s => s.Id == id);
            if (staff is null) return false;

            staff.IsDeleted = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<GetStaffResponse>> GetAllStaffAsync()
        {
            var staffs = await _context.Staffs.ToListAsync();
            return staffs.Any() ?
                staffs.Select(s => s.StaffResponse())
                : new List<GetStaffResponse>();
        }

        public async Task<GetStaffResponse?> GetStaffByIdAsync(int id)
        {
            var staff = await _context.Staffs
           .FirstOrDefaultAsync(s => s.Id == id);

            return staff is null ? null : new GetStaffResponse();
        }

        public async Task<GetStaffResponse?> UpdateStaffAsync(int id, UpdateStaffRequest request)
        {
            var staff = await _context.Staffs.FirstOrDefaultAsync(s => s.Id == id);
            if (staff is null) return null;

            _context.Staffs.Update(staff);
            _context.SaveChanges();
            return staff.StaffResponse();
        }
    }
}
