using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Digi.Core.Entities;

namespace Digi.Infra.Records.Maps
{
    public class DomainToRecordProfile : Profile
    {
        public DomainToRecordProfile()
        {
            CreateMap<Tamer, TamerRecord>().ReverseMap();
        }
    }
}