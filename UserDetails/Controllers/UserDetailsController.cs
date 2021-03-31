using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserDetails.Domain.Models;
using UserDetails.Domain.Services;
using UserDetails.Extensions;
using UserDetails.Resources;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : Controller
    {
        private readonly IUserDetailService _userDetailService;
        private readonly IMapper _mapper;
        public UserDetailsController(IUserDetailService userDetailService,IMapper mapper)
        {
            _userDetailService = userDetailService;
            _mapper = mapper;
        }
        // GET: api/<UserDetailsController>
        [HttpGet]
         public async Task<IEnumerable<UserDetailResource>> GetAllAsync()
        {
            var userinfo = await _userDetailService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserDetailResource>>(userinfo);
            return resources;
        }
       
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserDetailResource saveResource)
        {
            if (!ModelState.IsValid)
		        return BadRequest(ModelState.GetErrorMessages());
            var user = _mapper.Map<SaveUserDetailResource, User>(saveResource);
            var result = await _userDetailService.SaveAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserDetailResource>(result.User);
            return Ok(userResource);
        }

        // PUT api/<UserDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
