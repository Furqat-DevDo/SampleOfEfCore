using EfCore.Data;
using EfCore.Entities;
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
            var staff = new Staff()
            {
               FullName = request.FullName,
               Role = request.Role,
               PersonalData = request.PersonalData,
               Salary = request.Salary
            };

            var newStaff = await _context.Staffs.AddAsync(staff);
            await _context.SaveChangesAsync();
            return new GetStaffResponse(newStaff.Entity);
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
                staffs.Select(s => new GetStaffResponse(s))
                : new List<GetStaffResponse>();
        }

        public async Task<GetStaffResponse?> GetStaffByIdAsync(int id)
        {
            var staff = await _context.Staffs
           .FirstOrDefaultAsync(s => s.Id == id);

            return staff is null ? null : new GetStaffResponse(staff);
        }

        public async Task<GetStaffResponse?> UpdateStaffAsync(int id, UpdateStaffRequest request)
        {
            var staff = await _context.Staffs.FirstOrDefaultAsync(s => s.Id == id);
            if (staff is null) return null;

            staff.FullName = request.FullName;
            staff.UpdatedDate = DateTime.UtcNow;
            staff.PersonalData = request.PersonalData;
            staff.Salary = request.Salary;
            staff.Role = request.Role;  


            _context.Staffs.Update(staff);
            _context.SaveChanges();
            return new GetStaffResponse(staff);
        }
    }
}
