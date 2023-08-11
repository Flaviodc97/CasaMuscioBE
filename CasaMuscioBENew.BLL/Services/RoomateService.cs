using AutoMapper;
using CasaMuscioBENew.BLL.IServices;
using CasaMuscioBENew.BLL.Models;
using CasaMuscioBENew.DAL.Entities;
using CasaMuscioBENew.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace CasaMuscioBENew.BLL.Services
{
    public class RoomateService : IRoomateService
    {
        private readonly IRoomateRepository _roomaterepository;
        private readonly IMapper _mapper;
        public RoomateService(IRoomateRepository repository, IMapper mapper) 
        { 
        
            _roomaterepository = repository;
            _mapper = mapper;

        }
        public async Task<int> Create(RoomateDTO roomateDTO)
        {
            try 
            {
                var roomateToCreate = _mapper.Map<Roomate>(roomateDTO);
                var id = await _roomaterepository.Create(roomateToCreate);
                return id;
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
                return await _roomaterepository.Delete(id);
            }
            catch (Exception ex) 
            {
                throw ex;
            }

        }

        public async Task<RoomateDTO> Get(int id)
        {
            try 
            {
                var roomate = await _roomaterepository.FindById(id);
                var roomateToSend = _mapper.Map<RoomateDTO>(roomate);
                return roomateToSend;

            }
            catch(Exception ex) 
            {
                throw ex;
            }
            
        }

        public async Task<IEnumerable<RoomateDTO>> GetAll()
        {
            try 
            {
                var allRoomates = await _roomaterepository.GetAll();
                var roomatesToSend = allRoomates.Select(roomate => _mapper.Map<RoomateDTO>(roomate)).ToList();
                return roomatesToSend;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> Update(RoomateDTO roomateDTO)
        {
            try 
            {
                var roomateToUpdate = _mapper.Map<Roomate>(roomateDTO);
                await _roomaterepository.Update(roomateToUpdate);
                return roomateToUpdate.ID;
            } 
            catch (Exception ex) 
            {
                throw ex; 
            }
            
               
        }
    }
}
