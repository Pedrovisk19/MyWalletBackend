using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWallet.BaseCollections
{
    public class BaseService<T>
    {
        protected readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<T>> ListContent()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task FillContentAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public virtual async Task UpdateContentAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task DeleteContentAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
