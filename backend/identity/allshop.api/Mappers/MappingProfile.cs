
using allshop.domain;
using allshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allshop.domain.Entities;
using AutoMapper;
using allshop.domain.Entities.Auth;
using allshop.api.Models.Role;

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
            CreateMap<AuthRole, RoleModel>();
         

        }

        public void FromModelToDomain()
        {
             CreateMap<RoleModel, AuthRole>();

        }
    }


}
