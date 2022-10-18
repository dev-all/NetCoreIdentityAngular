
using allshop.domain;
using allshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allshop.domain.Entities;
using AutoMapper;

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

         
        }

        public void FromModelToDomain()
        {
          

        }
    }


}
