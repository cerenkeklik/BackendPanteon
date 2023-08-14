using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //attribute - giving info about class
    public class BuildingsController : ControllerBase
    {
        //IoC container - Inversion of control
        IBuildingService _buildingService;

        public BuildingsController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var res = _buildingService.GetAll();
            if(res.Success)
              return Ok(res.Data);

            return BadRequest(res.Message);
        }

        [HttpGet("getbytype")]
        public IActionResult GetByType(string type)
        {
            var res = _buildingService.GetByType(type);
            if (res.Success)
                return Ok(res.Data);

            return BadRequest(res.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Building building)
        {
            var res = _buildingService.Add(building);
            if (res.Success)
                return Ok(res);

            return BadRequest(res);
        }
    }
}
