using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Eventool.Domain.Interfaces
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object Id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(object Id);
    }
}
