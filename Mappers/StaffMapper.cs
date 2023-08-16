using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Mappers;

public static class StaffMapper
{
    public static GetStaffResponse StaffResponse(this Staff staff)
    => new GetStaffResponse()
    {
        Id = staff.Id,
        FullName = staff.FullName,
        Role = staff.Role,
        PersonalData = staff.PersonalData,
        Salary = staff.Salary,
        CreatedDate = staff.CreatedDate,
        UpdatedDate = staff.UpdatedDate,
    };

    public static Staff StaffCreate(this CreateStaffRequest request)
    => new Staff
    {
        FullName = request.FullName,
        Role = request.Role,
        PersonalData = request.PersonalData,
        Salary = request.Salary,
    };

    public static void StaffUpdate(this Staff staff, UpdateStaffRequest request )
    {
        staff.FullName = request.FullName;
        staff.UpdatedDate = DateTime.UtcNow;
        staff.PersonalData = request.PersonalData;
        staff.Salary = request.Salary;
        staff.Role = request.Role;
    }
}
