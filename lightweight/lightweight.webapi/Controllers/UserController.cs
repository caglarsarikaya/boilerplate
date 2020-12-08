using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using lightweight.business.Abstract;
using lightweight.data.Model;
using lightweight.webapi.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace lightweight.webapi.Controllers
{
   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
     
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ServiceResponse<User>> Authenticate([FromBody]User userParam)
        {
            var response = new ServiceResponse<User>(null);
            response.Entity = await _userService.Authenticate(userParam.Email, userParam.Password);
            response.IsSuccessful = true;


            return response;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("getAll")]
        public async Task<ServiceResponse<UserDto>> getAllUsers()
        {
            var response = new ServiceResponse<UserDto>(null);

            var s = await _userService.GetAllAsync();

            response.List = _mapper.Map<List<UserDto>>(s);
            response.IsSuccessful = true;


            return response;
        }





    }
}
