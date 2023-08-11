using CasaMuscioBENew.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaMuscioBENew.DAL.IRepositories
{
    public interface IRepository<T>
    {
        Task<int> Create(T entity);
        Task<int> Update(T entity);
        Task<bool> Delete(int id);
        Task<T> FindById(int id);
        Task<IEnumerable<T>> GetAll();

    }
}
