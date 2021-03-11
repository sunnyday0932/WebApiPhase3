using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiPhase3Repository.Conditions;
using WebApiPhase3Repository.DataModels;

namespace WebApiPhase3Repository.Interface
{
    public interface IAccountRepository
    {
        /// <summary>
        /// 取得單筆帳號資訊
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Task<AccountDataModel> GetAccount(string account);

        /// <summary>
        /// 取得帳號列表
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AccountDataModel>> GetAccountList();

        /// <summary>
        /// 新增帳號
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<bool> AddAccount(AccountCondition condition);

        /// <summary>
        /// 刪除帳號
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Task<bool> RemoveAccount(string account);

        /// <summary>
        /// 更新帳號資訊
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<bool> UpdateAccount(AccountCondition condition);

        /// <summary>
        /// 取得密碼
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Task<string> GetAccountPassword(string account);

        /// <summary>
        /// 忘記密碼
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<bool> ForgetPassword(AccountCondition condition);
    }
}
