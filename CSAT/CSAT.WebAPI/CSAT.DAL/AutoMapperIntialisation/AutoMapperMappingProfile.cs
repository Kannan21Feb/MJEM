using AutoMapper;
using CSAT.DAL.EntityModel;
using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.DAL.AutoMapperIntialisation
{

    public interface IAutomapperConfiguration
    {
        Profile MappingProfile { get; }
    }

    public class AutoMapperConfiguration : IAutomapperConfiguration
    {
        public Profile MappingProfile
        {
            get
            {
                return new DALMappingProfile();
            }
        }
        private class DALMappingProfile : Profile
        {
            protected override void Configure()
            {
                base.Configure();
                CreateMaps();
            }
            private void CreateMaps()
            {
                CreateMap<CustomerMstDTO, CustomersMst>().ReverseMap();
                CreateMap<VechileMstDTO, VechileMst>().ReverseMap();
                CreateMap<MJEMSysLovDTO, MJEMSysLov>().ReverseMap();
                CreateMap<LocationMstDTO, LocationMst>().ReverseMap();
                CreateMap<EmplyoeeMstDTO, EmplyoeeMst>().ReverseMap();
                CreateMap<JobSheetTxnDTO, JobSheetTxn>().ReverseMap();
                CreateMap<JobSheetTxnDetDTO, JobSheetTxnDet>().ReverseMap();
                

            }
        }
    }
    class AutoMapperMappingProfile
    {
    }
}
