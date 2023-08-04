using System.Runtime.InteropServices.ComTypes;
using EfCore.Data;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EfCore.Services;

// public class GenericService<T1,T2,T3> : IGenericService<T1,T2,T3>
// where T1:class
// where T2:class
// where T3:struct
// {
//     private readonly ShopDbContext _shopDbContext;
//     public GenericService(ShopDbContext _shopDbContext)
//     {
//         _shopDbContext = this._shopDbContext;
//     }
    // public Task<T1> CreateAsync(T2 model)
    // {
    //    _shopDbContext.Add<T2>;
    // }
    //
    // Task<T1> GetByIdAsync(T3 id);
    // Task<List<T1>> GetAllAsync();
    //
    // Task<T3> DeleteAsync(T3 id)
    // {
    //     throw new NotImplementedException();
    // }
//}