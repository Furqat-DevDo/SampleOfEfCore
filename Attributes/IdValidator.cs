using EfCore.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EfCore.Attributes;

//public class IdValidator : ValidationAttribute
//{
//    private readonly ShopDbContext _dbContext;

//    public IdValidator(ShopDbContext dbContext)
//    {
//        _dbContext = dbContext;
//    }

//    public bool IsValid(int Id)
//    {
//        return _dbContext.Products.Any(p => p.Id == Id);
//    }

//    public override string FormatErrorMessage(string name)
//    {
//        return $"Id {name} does not exists in db !!!";
//    }
//}

//public class EntityExistsChecker<T> where T : class
//{
//    private readonly ShopDbContext _context;

//    public EntityExistsChecker(ShopDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<bool> ExistsAsync(long id)
//    {
//        return await _context.Set<T>().AnyAsync(e => EF.Property<long>(e, "Id") == id);
//    }
//}

//// Usage
//var dbContext = new YourDbContext(); // Replace with your actual DbContext instantiation
//var entityExistsChecker = new EntityExistsChecker<YourEntityType>(dbContext);
//bool entityExists = await entityExistsChecker.ExistsAsync(someId);
