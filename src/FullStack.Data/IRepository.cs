using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack.Data
{
    public interface IRepository<T>
    {
        Task<int> Create(T values);

        Task<bool> Delete(int id);

        Task<T> Get(int id);

        Task<IEnumerable<T>> List(IDictionary<string, object> filters);

        Task<bool> Update(int id, T values);
    }
}