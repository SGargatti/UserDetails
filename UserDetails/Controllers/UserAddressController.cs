using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserDetails.Domain.Models;
using UserDetails.Domain.Services;
using UserDetails.Extensions;
using UserDetails.Resources;

namespace UserDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private readonly IUserDetailAddressService _userDetailAddressService;
        private readonly IMapper _mapper;

        public UserAddressController(IUserDetailAddressService userDetailAddressService, IMapper mapper)
        {
            _userDetailAddressService = userDetailAddressService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDetailAddressResource>> GetAllAsync()
        {
            var userAddressinfo = await _userDetailAddressService.ListAsync();
            var resources = _mapper.Map<IEnumerable<UserAddressDetail>, IEnumerable<UserDetailAddressResource>>(userAddressinfo);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserAddressDetailResource saveAddressResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var user = _mapper.Map<SaveUserAddressDetailResource, UserAddressDetail>(saveAddressResource);
            var result = await _userDetailAddressService.SaveAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userAddressResource = _mapper.Map<UserAddressDetail, UserDetailAddressResource>(result.UserAddress);
            return Ok(userAddressResource);
        }
    }
}
