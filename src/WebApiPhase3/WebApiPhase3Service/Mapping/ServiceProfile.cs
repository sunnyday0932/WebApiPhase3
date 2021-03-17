using AutoMapper;
using WebApiPhase3Repository.Conditions;
using WebApiPhase3Repository.DataModels;
using WebApiPhase3Service.Dtos;
using WebApiPhase3Service.InfoModels;

namespace WebApiPhase3Service.Mapping
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            this.CreateMap<AccountDataModel, AccountDto>()
                .ForMember(x => x.CreateDate, y => y.MapFrom(z => z.CreateDate.HasValue ? z.CreateDate.Value.ToString("yyyy/MM/dd") : null))
                .ForMember(x => x.ModifyDate, y => y.MapFrom(z => z.ModifyDate.HasValue ? z.ModifyDate.Value.ToString("yyyy/MM/dd") : null));

            this.CreateMap<AccountInfoModel, AccountCondition>();
            this.CreateMap<AccountInfoModel, ForgetAccountCondition>();
            this.CreateMap<AccountInfoModel, UpdateAccountCondition>();
        }
    }
}