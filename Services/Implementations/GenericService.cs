using AutoMapper;
using Conference_Management_System.Models.Common;
using Conference_Management_System.Repositories.Interfaces;
using Conference_Management_System.Services.Interfaces;

namespace Conference_Management_System.Services.Implementations
{
    public class GenericService<TVM, TEntity> : IGenericService<TVM, TEntity>
        where TVM : class
        where TEntity : BaseEntity, new()
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TVM> AddAsync(TVM viewModel)
        {
            var entity = _mapper.Map<TEntity>(viewModel);
            var result = await _repository.AddAsync(entity);
            var vm = _mapper.Map<TVM>(result);
            return vm;

        }

        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);

        public async Task<IEnumerable<TVM>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var viewModels = entities.Select(e => _mapper.Map<TVM>(e));
            return viewModels;
        }

        public async Task<TVM> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }
            var viewModel = _mapper.Map<TVM>(entity);
            return viewModel;

        }

        public async Task<TVM> UpdateAsync(TVM viewModel)
        {
            var entity = _mapper.Map<TEntity>(viewModel);
            var updatedEntity = await _repository.UpdateAsync(entity);
            if (updatedEntity is null)
            {
                throw new KeyNotFoundException($"Entity with id {entity.Id} not found.");
            }
            var vm = _mapper.Map<TVM>(updatedEntity);
            return vm;

        }
    }
}
