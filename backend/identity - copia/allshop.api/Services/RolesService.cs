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
    public class RolesService : IRolesService
    {
        private readonly IRoleRepository _repository = null;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        public RolesService(IOptions<AppSettings> appSettings, IRoleRepository repository, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _repository = repository;
            _mapper= mapper;
        }

        public async Task<RoleModel> GetRolesByUserId(Guid roleId)
        {
            var role = await _repository.GetAsync(roleId);
            return _mapper.Map<RoleModel>(role);
        }
    }

}
