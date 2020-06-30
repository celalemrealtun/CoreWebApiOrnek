using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoreWebApiOrnek.BL.Concrete.EfCore.UnitOfWork;
using CoreWebApiOrnek.DTO.UserDto;
using CoreWebApiOrnek.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace CoreWebApiOrnek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public UserController(IUnitOfWork uow, IConfiguration config, IMapper mapper)
        {
            _uow = uow;
            _config = config;
            _mapper = mapper;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody]DtoUserLogin userdto)
        {
            var user = await _uow.Users.CheckUserAsync(userdto);
            if (user != null)
            {
                return Created("", this.GenerateJSONWebToken(user));
            }
            return BadRequest("kullanıcı adı veya şifre hatalı");

        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ActiveUser()
        {
            return Ok(_mapper.Map<List<DtoUser>>(await _uow.Users.GetAllAsync()));
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Jwt:Key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.NameId,1.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
            new Claim(ClaimTypes.Role, userInfo.IsAdmin == true ? "Admin":"User"),

            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(20),
                signingCredentials: credentials);
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
    }
}