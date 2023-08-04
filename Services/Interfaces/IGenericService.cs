namespace EfCore.Services.Interfaces;

public interface IGenericService<T1, T2, T3>
    where T1 : class
    where T2:class 
    where T3:struct
{
    Task<T1> CreateAsync(T2 model);
    Task<T1> GetByIdAsync(T3 id);
    Task<List<T1>> GetAllAsync();
    Task<T3> DeleteAsync(T3 id);
}