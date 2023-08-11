using AutoMapper;
using CasaMuscioBENew.BLL.Models;
using CasaMuscioBENew.DAL.Entities;

namespace CasaMuscioBE.API.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Roomate, RoomateDTO>().ReverseMap();

        }
    }
}
