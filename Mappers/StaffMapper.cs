using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Mappers;

public static class StaffMapper
{
    public static GetStaffResponse GetStaffResponse(this Staff staff)
    {
        if (staff is null)
            throw new ArgumentNullException(nameof(staff));

        return new GetStaffResponse(staff)
        {
            Id = staff.Id,
            FullName = staff.FullName,
            Role = staff.Role,
            PersonalData = staff.PersonalData,
            Salary = staff.Salary
        };
    }
    public static Staff ToStaff(this CreateStaffRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        return new Staff
        {
            FullName = request.FullName,
            Role = request.Role,
            PersonalData = request.PersonalData,
            Salary = request.Salary
        };
    }
    public static void UpdateStaff(this UpdateStaffRequest request, Staff staff)
    {
        if (request is null || staff is null) return;

        staff.FullName = request.FullName;
        staff.UpdatedDate = DateTime.UtcNow;
        staff.PersonalData = request.PersonalData;
        staff.Salary = request.Salary;
        staff.Role = request.Role;
    }
}
