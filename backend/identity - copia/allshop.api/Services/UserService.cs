using allshop.Models.Request;
using allshop.Models.Response;
using Microsoft.EntityFrameworkCore;
using allshop.Models.Common;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using AutoMapper;
using allshop.repository.Contracts;
using System;
using allshop.api.Models;
using allshop.api.Tools;
using allshop.domain.Entities;
using allshop.api.Services.Contracts;

namespace allshop.api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
       // private readonly AppSettings _appSettings;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserService( IUserRepository repository, IMapper mapper, IConfiguration configuration )
        {
            _configuration = configuration;
            _repository = repository;
            _mapper= mapper;
        }

        public async Task<UserModel> SingIn(string email)
        {
            return _mapper.Map<UserModel>( await _repository.SignIn(email) );
        }
        public string GenerateJWTToken(Guid userId, bool rememberMe)
        {
            // IdentityOptions options = new IdentityOptions();
            // We will setup the parameters of token generation

            var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]);
            SecurityTokenDescriptor tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]{
                        new Claim("userId", userId.ToString())
                    }
                ),
                Expires = rememberMe ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(securityToken);
        }
        public async Task<UserModel> ExistEmailAsync(string email)
        {
            var model =await _repository.ExistEmail(email);
            
            return _mapper.Map<UserModel>(model);
        }
                      
        public string GenerateJWTTokenByEmail(string email)
        {
            //IdentityOptions options = new IdentityOptions();
            // We will setup the parameters of token generation
            //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]);
            SecurityTokenDescriptor tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]{
                        new Claim("email", email)
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(1), //24hs
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(securityToken);
        }
       
        public string GetToken(UserModel model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, model.FullName.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task AddAsync(UserModel model)
        {
             await _repository.AddAsync(_mapper.Map<User>(model));
        }

        public Task<UserModel> UpdateAsync(UserModel model)
        {
           return  _mapper.Map<Task<UserModel>>(_repository.UpdateAsync(_mapper.Map<User>(model)));
        }

        public Task<UserModel> Get(Guid id) { 
            return _mapper.Map<Task<UserModel>>(_repository.Get(id));
        }

        public async Task<UserModel> AddGetAsync(UserModel model)
        {
            var result = await _repository.AddGetAsync(_mapper.Map<User>(model));
           
            return  _mapper.Map<UserModel>(result);
        }
  
    }

}
