using Business.Abstract;
using Business.Constants;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
        public class AuthController : Controller
        {
            private IAuthService _authService;

            public AuthController(IAuthService authService)
            {
                _authService = authService;
            }

            [HttpPost("login")]
            public ActionResult Login(UserForLoginDTO userForLoginDto)
            {
                var userToLogin = _authService.Login(userForLoginDto);
                if (!userToLogin.Success)
                {
                    return BadRequest(userToLogin.Message);
                }

                var result = _authService.CreateAccessToken(userToLogin.Data);
                if (result.Success)
                {
                    return Ok(result.Data);
                }

                return BadRequest(result.Message);
            }

            [HttpPost("register")]
            public ActionResult Register(UserForRegisterDTO userForRegisterDto)
            {
                var userExists = _authService.UsernameExists(userForRegisterDto.Username);
                var emailExists = _authService.EmailExists(userForRegisterDto.Email);

                if (!userExists.Success)
                {
                    return BadRequest(userExists.Message);
                }

                if (!emailExists.Success)
                {
                    return BadRequest(emailExists.Message);
                }

                var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
                var result = _authService.CreateAccessToken(registerResult.Data);
                if (result.Success)
                {
                    return Ok(result.Data);
                }

                return BadRequest(result.Message);
            }
        }
    }
