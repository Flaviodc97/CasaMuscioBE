using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaMuscioBE.BLL.IServices
{
    public interface IRoomateService
    {
        Task<int> Create(RoomateDTO);

    }
}
