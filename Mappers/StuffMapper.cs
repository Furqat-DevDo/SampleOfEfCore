using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Mappers;

public static class StuffMapper
{
    public static void UpdateStuff(this Stuff stuff, UpdateStuffRequest request)
    {
        stuff.FullName = request.FullName;
        stuff.Role = request.Role;
        stuff.Salary = request.Salary;
        stuff.PersonalData = request.PersonalData;
        stuff.UpdatedDate = DateTime.UtcNow;
    }

    public static GetStuffResponse ResponseStuff(this Stuff entity)
    => new GetStuffResponse
    {

            Id = entity.Id,
            FullName = entity.FullName,
            CreatedDate = entity.CreatedDate,
            UpdatedDate = entity.UpdatedDate,
            Role = entity.Role,
            PersonalData = entity.PersonalData,
            Salary = entity.Salary,
    };

    public static Stuff CreateStuff(this CreateStuffRequest entity)
    => new Stuff
    {
        FullName = entity.FullName,
        Role = entity.Role,
        PersonalData = entity.PersonalData,
        Salary = entity.Salary,
    };
}
