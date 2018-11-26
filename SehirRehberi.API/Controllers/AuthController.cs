using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SehirRehberi.API.CustomActionFilter;
using SehirRehberi.API.Data;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    [ServiceFilter(typeof(TokenAttribute))]
    public class AuthController : Controller
    {
        private ICacheServices _cache;
        private IAuthRepository _authRepository;
        private IConfiguration _configuration;
        private DataContext _context;

        public AuthController(IAuthRepository authRepository, IConfiguration configuration, DataContext context, ICacheServices memoryCache)
        {
            _cache = memoryCache;
            _context = context;
            _authRepository = authRepository;
            _configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]GetMovisRequestDTO userForRegisterDto)
        {
            if (await _authRepository.UserExists(userForRegisterDto.Email))
            {
                ModelState.AddModelError("UserName","Username already exists");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToCreate = new User
            {
                NickName = userForRegisterDto.Email,
                Email = userForRegisterDto.Email,
                SurName = userForRegisterDto.Surname,
                Name = userForRegisterDto.Name,
                SystemInsertUser = "api",
                SystemInsertTime = DateTime.Now,
                IsActive = true,
                RememberMe=true,
                BirthDate=DateTime.Now
            };
            var createdUser = await _authRepository.Register(userToCreate, userForRegisterDto.Password);
            createdUser.PasswordSalt = null;
            createdUser.PasswordHash = null;
            return StatusCode(201, createdUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] GetMovisRequestDTO userForLoginDto)
        {
            var user = await _authRepository.Login(userForLoginDto.Email, userForLoginDto.Password);

            if (user==null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.NickName)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                    , SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            userForLoginDto.Token = tokenString;
            userForLoginDto.Name = user.Name;
            userForLoginDto.Surname = user.SurName;
            userForLoginDto.Password = "";
            CacheModel cacheModel = new CacheModel();
            cacheModel.Email = user.Email;
            cacheModel.Name = user.Name;
            cacheModel.Surname = user.Name;
            cacheModel.Token = tokenString;
            user.PasswordHash = null;
            user.PasswordSalt = null;
            cacheModel.TokenTime = DateTime.Now;
            _cache.SetCache(cacheModel);
            return Ok(user);
        }
    

    }
}