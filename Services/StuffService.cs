using EfCore.Data;
using EfCore.Entities;
using EfCore.Exceptions;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Services
{
    public class StuffService : IStuffService
    {
        private readonly ShopDbContext _context;
        public StuffService(ShopDbContext context)
        {
            _context = context;
        }
        public async Task<GetStuffResponse> CreateStuffAsync(CreateStuffRequest request)
        {
            var stuff = new Stuff()
            {  FullName = request.FullName,
               Role = request.Role,
               PersonalData = request.PersonalData,
               Salary = request.Salary
            };

            var newStuff = await _context.Stuffs.AddAsync(stuff);
            await _context.SaveChangesAsync();

            if(newStuff == null) throw new UnableToSaveStuffChangesException();
            return new GetStuffResponse();
        }

        public async Task<bool> DeleteStuffAsync(int id)
        {
            var stuff = await _context
                .Stuffs
                .FirstOrDefaultAsync(s => s.Id == id);
            if (stuff is null) throw new StuffNotFoundExeption();

            stuff.IsDeleted = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<GetStuffResponse>> GetAllStuffAsync()
        {
            var stuffs = await _context.Stuffs.ToListAsync();
            return stuffs.Any() ?
                stuffs.Select(s => new GetStuffResponse())
                : new List<GetStuffResponse>();
        }

        public async Task<GetStuffResponse?> GetStuffByIdAsync(int id)
        {
            var stuff = await _context.Stuffs
           .FirstOrDefaultAsync(s => s.Id == id);

            if (stuff is null) throw new StuffNotFoundExeption();

            return new GetStuffResponse();
        }

        public async Task<GetStuffResponse?> UpdateStuffAsync(int id, UpdateStuffRequest request)
        {
            var stuff = await _context.Stuffs.FirstOrDefaultAsync(s => s.Id == id);
            if (stuff is null) throw new StuffNotFoundExeption();

            stuff.FullName = request.FullName;
            stuff.UpdatedDate = DateTime.UtcNow;
            stuff.PersonalData = request.PersonalData;
            stuff.Salary = request.Salary;
            stuff.Role = request.Role;  


            _context.Stuffs.Update(stuff);
            _context.SaveChanges();

            if(_context.SaveChanges() > 0)
            {
                return new GetStuffResponse();
            }
            throw new UnableToSaveStuffChangesException();
        }
    }
}
