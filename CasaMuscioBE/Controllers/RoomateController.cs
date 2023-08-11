using CasaMuscioBENew.BLL.IServices;
using CasaMuscioBENew.BLL.Models;
using CasaMuscioBENew.DAL.Entities;
using CasaMuscioBENew.DAL.IRepositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Results;

namespace CasaMuscioBE.API.Controllers
{
    [EnableCors("default")]
    [ApiController]
    [Route("api/Roomate")]
    public class RoomateController : ControllerBase
    {
        private readonly IRoomateService _roomateService;
        
        public RoomateController(IRoomateService roomateService)
        {
            _roomateService = roomateService;
           
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(RoomateDTO roomateDTO)
        {
            try
            {
                var id = await _roomateService.Create(roomateDTO);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(RoomateDTO roomateDTO)
        {
            try 
            {
                var id = await _roomateService.Update(roomateDTO);
                return Ok(id);
            } 
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
         
        }
        [HttpGet("Find")]
        public async Task<IActionResult> Find(int id)
        {
            try
            { 
                return Ok(await _roomateService.Get(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("FindAll")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(_roomateService.GetAll());

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try 
            {
                return Ok(_roomateService.Delete(id));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
