using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiPhase3.Infrastructure;
using WebApiPhase3.Infrastructure.Validator;
using WebApiPhase3.Infrastructure.Validator.Account;
using WebApiPhase3.Parameters;
using WebApiPhase3.ViewModles;
using WebApiPhase3Service.InfoModels;
using WebApiPhase3Service.Interface;

namespace WebApiPhase3.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        private IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="accountService">The account service.</param>
        /// <param name="mapper">The mapper.</param>
        public AccountController(
            IAccountService accountService,
            IMapper mapper)
        {
            this._accountService = accountService;
            this._mapper = mapper;
        }

        /// <summary>
        /// 取得單筆帳號資訊
        /// </summary>
        /// <returns></returns>
        [Route("{account}")]
        [HttpGet]
        public async Task<AccountViewModel> GetAccount(string account)
        {
            var data = await this._accountService.GetAccount(account);
            var result = this._mapper.Map<AccountViewModel>(data);

            return result;
        }

        /// <summary>
        /// 取得帳號列表
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<AccountViewModel>> GetAccountList()
        {
            var data = await this._accountService.GetAccountList();
            var result = this._mapper.Map<IEnumerable<AccountViewModel>>(data);

            return result;
        }

        /// <summary>
        /// 新增帳號
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        [ValidatorParameter(typeof(InsertUpdateValidator))]
        public async Task<ResultViewModel> AddAccount([FromBody] AccountParameter parameter)
        {
            var info = this._mapper.Map<AccountInfoModel>(parameter);
            var data = await this._accountService.AddAccount(info);
            var result = this._mapper.Map<ResultViewModel>(data);

            return result;
        }

        /// <summary>
        /// 刪除帳號
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [Route("")]
        [HttpDelete]
        [ValidatorParameter(typeof(RemoveValidator))]
        public async Task<ResultViewModel> RemoveAccount([FromBody] AccountParameter parameter)
        {
            var info = this._mapper.Map<AccountInfoModel>(parameter);
            var data = await this._accountService.RemoveAccount(info);
            var result = this._mapper.Map<ResultViewModel>(data);

            return result;
        }

        /// <summary>
        /// 更新帳號資訊
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPatch]
        [ValidatorParameter(typeof(InsertUpdateValidator))]
        public async Task<ResultViewModel> UpdateAccount([FromBody] AccountParameter parameter)
        {
            var info = this._mapper.Map<AccountInfoModel>(parameter);
            var data = await this._accountService.UpdateAccount(info);
            var result = this._mapper.Map<ResultViewModel>(data);

            return result;
        }

        /// <summary>
        /// 忘記密碼
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [Route("forget")]
        [HttpPatch]
        [ValidatorParameter(typeof(InsertUpdateValidator))]
        public async Task<ResultViewModel> ForgetPassword([FromBody] AccountParameter parameter)
        {
            var info = this._mapper.Map<AccountInfoModel>(parameter);
            var data = await this._accountService.ForgetPassword(info);
            var result = this._mapper.Map<ResultViewModel>(data);

            return result;
        }
    }
}
