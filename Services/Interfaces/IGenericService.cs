namespace Conference_Management_System.Services.Interfaces
{
    public interface IGenericService<TVM, TEntity> where TVM : class where TEntity : class
    {
        Task<IEnumerable<TVM>> GetAllAsync();
        Task<TVM> GetByIdAsync(int id);
        Task<TVM> AddAsync(TVM viewModel);
        Task<TVM> UpdateAsync(TVM viewModel);
        Task<bool> DeleteAsync(int id);

    }
}
