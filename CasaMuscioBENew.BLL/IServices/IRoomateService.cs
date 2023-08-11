using CasaMuscioBENew.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaMuscioBENew.BLL.IServices
{
    public interface IRoomateService
    {
        Task<int> Create(RoomateDTO roomateDTO);
        Task<int> Update(RoomateDTO roomateDTO);
        Task<bool> Delete(int id);
        Task<IEnumerable<RoomateDTO>> GetAll();
        Task<RoomateDTO> Get(int id);



    }
}
