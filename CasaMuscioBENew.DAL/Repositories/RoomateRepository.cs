using CasaMuscioBENew.DAL.Context;
using CasaMuscioBENew.DAL.Entities;
using CasaMuscioBENew.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaMuscioBENew.DAL.Repositories
{
    public class RoomateRepository : IRepository<Roomate>, IRoomateRepository
    {
        private readonly AppDBContext _context;
        public RoomateRepository(AppDBContext context) 
        {
            _context = context;
            
        }
        public async Task<int> Create(Roomate entity)
        {
            try
            {
                await _context.Roomate.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var roomateToDelete = await _context.Roomate.FirstOrDefaultAsync(x => x.ID == id);
                _context.Entry(roomateToDelete).State = EntityState.Deleted;
                return (await _context.SaveChangesAsync() > 0) ? true : false;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<Roomate> FindById(int id)
        {
            try 
            {
                var roomateToFind = await _context.Roomate.FirstOrDefaultAsync(x => x.ID == id);
                return roomateToFind;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Roomate>> GetAll()
        {
            try 
            {
                return await _context.Roomate.ToListAsync();    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(Roomate entity)
        {
            try 
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity.ID;
            }
            catch (Exception ex) 
            { 
                    throw ex;
            }
        }
    }
}
