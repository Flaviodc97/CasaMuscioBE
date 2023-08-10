using CasaMuscioBE.DAL.Entities;
using CasaMuscioBE.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaMuscioBE.DAL.Repositories
{
    public class RoomateRepository : AbstractRepository<Roomate> 
    {
        public RoomateRepository(DbContext context) : base(context) 
        {
            
        }
    }
}
