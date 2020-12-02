using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SEProject.UdemyJwtProject.Business.Interfaces;
using SEProject.UdemyJwtProject.Entities.Concrete;
using SEProject.UdemyJwtProject.Entities.Dtos.AppUserDtos;
using SEProject.UdemyJwtProject.WebApi.CustomFilters;
using System.Threading.Tasks;

namespace SEProject.UdemyJwtProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public AuthController(IJwtService jwtService, IAppUserService appUserService, IMapper mapper)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {

            var appUser = await _appUserService.FindByUserName(appUserLoginDto.UserName);

            if (appUser == null)
            {
                return BadRequest("kullanıcı adı veya şifre hatalı");
            }
            else
            {
                if (await _appUserService.CheckPassword(appUserLoginDto))
                {
                    var roles = await _appUserService.GetRolesByUserName(appUserLoginDto.UserName);

                    var token = _jwtService.GenerateJwt(appUser, roles);

                    return Created("", token);
                }

                return BadRequest("kullanıcı adı veya şifre hatalı");
            }
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto)
        {
            var appUser = await _appUserService.FindByUserName(appUserAddDto.UserName);

            if (appUser != null)
            {
                return BadRequest($"{appUserAddDto.UserName} kullanıcı adı zaten kayıtlı");
            }

            await _appUserService.Add(_mapper.Map<AppUser>(appUserAddDto));

            return Created("", appUserAddDto);
        }
    }
}