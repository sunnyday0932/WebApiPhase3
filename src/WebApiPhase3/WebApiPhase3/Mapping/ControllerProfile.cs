using AutoMapper;
using WebApiPhase3.Parameters;
using WebApiPhase3.ViewModels;
using WebApiPhase3.ViewModles;
using WebApiPhase3Common.Model;
using WebApiPhase3Service.Dtos;
using WebApiPhase3Service.InfoModels;

namespace WebApiPhase3.Mapping
{
    public class ControllerProfile : Profile
    {
        public ControllerProfile()
        {
            this.CreateMap<AccountDto, AccountViewModel>();
            this.CreateMap<AccountParameter, AccountInfoModel>();
            this.CreateMap<AccountParameter, RemoveAccountInfoModel>();
            this.CreateMap<ResultDto, ResultViewModel>();
            this.CreateMap<PagingParameter, PagingInfoModel>();
            this.CreateMap<PagingParameter, PageViewModel>();
        }
    }
}