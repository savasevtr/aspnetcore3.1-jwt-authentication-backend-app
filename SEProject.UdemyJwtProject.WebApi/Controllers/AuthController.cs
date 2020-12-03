using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEProject.UdemyJwtProject.Business.Interfaces;
using SEProject.UdemyJwtProject.Business.StringInfos;
using SEProject.UdemyJwtProject.Entities.Concrete;
using SEProject.UdemyJwtProject.Entities.Dtos.AppUserDtos;
using SEProject.UdemyJwtProject.Entities.Token;
using SEProject.UdemyJwtProject.WebApi.CustomFilters;
using System.Linq;
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

        public object JwtAccessToken { get; private set; }

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

                    JwtAccessToken jwtAccessToken = new JwtAccessToken();
                    jwtAccessToken.Token = _jwtService.GenerateJwt(appUser, roles);

                    return Created("", jwtAccessToken);
                }

                return BadRequest("kullanıcı adı veya şifre hatalı");
            }
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto, [FromServices] IAppUserRoleService appUserRoleService, [FromServices] IAppRoleService appRoleService)
        {
            var appUser = await _appUserService.FindByUserName(appUserAddDto.UserName);

            if (appUser != null)
            {
                return BadRequest($"{appUserAddDto.UserName} kullanıcı adı zaten kayıtlı");
            }

            await _appUserService.Add(_mapper.Map<AppUser>(appUserAddDto));

            var user = await _appUserService.FindByUserName(appUserAddDto.UserName);
            var role = await appRoleService.FindByName(RoleInfo.Member);

            await appUserRoleService.Add(new AppUserRole
            {
                AppRoleId = role.Id,
                AppUserId = user.Id
            });

            return Created("", appUserAddDto);
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _appUserService.FindByUserName(User.Identity.Name);
            var roles = await _appUserService.GetRolesByUserName(User.Identity.Name);

            AppUserDto appUserDto = new AppUserDto
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Roles = roles.Select(I => I.Name).ToList()
            };

            return Ok(appUserDto);
        }
    }
}