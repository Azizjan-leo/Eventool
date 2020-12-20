using Eventool.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventool.Db.Services
{
    public class GenericDataService<T> : IDataService<T>
    {
        private ApplicationDbContextFactory _contextFactory;

        public GenericDataService(ApplicationDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {

            }
            throw new NotImplementedException();
        }

        public async Task<T> Delete(object Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(object Id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
