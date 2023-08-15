﻿using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Mappers;

public static class StuffMapper
{
    public static void UpdateStuff(this Stuff stuff, UpdateStuffRequest request)
    {
        stuff.FullName = request.FullName;      
        stuff.Salary = request.Salary;
        stuff.PersonalData = request.PersonalData;      
    }

    public static GetStuffResponse ToResponseStuff(this Stuff stuff)
   => new GetStuffResponse
   {
       FullName = stuff.FullName,
       Id = stuff.Id,
       Salary = stuff.Salary,
       PersonalData = stuff.PersonalData,     
   };

    public static Stuff ToCreateStuff(this CreateStuffRequest stuff)
    => new Stuff
    {
        FullName = stuff.FullName,
       
        Salary = stuff.Salary,
        PersonalData = stuff.PersonalData
    };
}
