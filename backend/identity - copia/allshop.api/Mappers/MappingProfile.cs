
using allshop.domain;
using allshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allshop.domain.Entities;
using AutoMapper;
using allshop.api.Models;

namespace allshop.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            FromDomainToModel();
            FromModelToDomain();
        }
  
        public void FromDomainToModel()
        {

            CreateMap<User, UserModel>();
            CreateMap<Role, RoleModel>();
            CreateMap<Tenant, TenantModel>();
        }

        public void FromModelToDomain()
        {
            CreateMap<UserModel, User>();
            CreateMap<RoleModel, Role>();
            CreateMap<TenantModel, Tenant>();

        }
    }


}
