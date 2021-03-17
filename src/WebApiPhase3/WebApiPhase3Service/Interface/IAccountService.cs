using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiPhase3Service.Dtos;
using WebApiPhase3Service.InfoModels;

namespace WebApiPhase3Service.Interface
{
    public interface IAccountService
    {
        /// <summary>
        /// 取得單筆帳號資訊
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Task<AccountDto> GetAccount(string account);

        /// <summary>
        /// 取得帳號列表
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AccountDto>> GetAccountList();

        /// <summary>
        /// 新增帳號
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task<ResultDto> AddAccount(AccountInfoModel info);

        /// <summary>
        /// 刪除帳號
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task<ResultDto> RemoveAccount(RemoveAccountInfoModel info);

        /// <summary>
        /// 更新帳號資訊
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task<ResultDto> UpdateAccount(AccountInfoModel info);

        /// <summary>
        /// 忘記密碼
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task<ResultDto> ForgetPassword(AccountInfoModel info);
    }
}