using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaMuscioBE.DAL.IRepositories
{
    public abstract class AbstractRepository<T> where T : class
    {
        public readonly DbContext context;

        public AbstractRepository(DbContext context)
        {
            this.context = context;
        }
        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();

        }
    }
}
