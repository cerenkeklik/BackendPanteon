using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
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
            var user = User.Identity.Name;
            var res = _buildingService.GetAll();
            if(res.Success)
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

        [HttpGet("getbyusername")]
        public IActionResult GetByUsername(string username)
        {
            var res = _buildingService.GetByUsername(username);
            if (res.Success)
                return Ok(res.Data);

            return BadRequest(res.Message);
        }

        [HttpGet("getavailabletypes")]
        public IActionResult GetAvailableTypes(string username)
        {
            var res = _buildingService.GetAvailableTypes(username);
            if (res.Success)
                return Ok(res.Data);

            return BadRequest(res.Message);
        }
    }
}
