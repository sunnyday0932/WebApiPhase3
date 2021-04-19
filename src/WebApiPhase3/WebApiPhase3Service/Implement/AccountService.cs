using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApiPhase3Common;
using WebApiPhase3Common.Helper;
using WebApiPhase3Common.Model;
using WebApiPhase3Repository.Conditions;
using WebApiPhase3Repository.Interface;
using WebApiPhase3Service.Dtos;
using WebApiPhase3Service.InfoModels;
using WebApiPhase3Service.Interface;

namespace WebApiPhase3Service.Implement
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;
        private IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="accountRepository">The account repository.</param>
        /// <param name="mapper">The mapper.</param>
        public AccountService(
            IAccountRepository accountRepository,
            IMapper mapper)
        {
            this._accountRepository = accountRepository;
            this._mapper = mapper;
        }

        private static readonly Dictionary<string, Func<AccountDto, object>> _accountListColumMap =
            new Dictionary<string, Func<AccountDto, object>>
            {
                ["account"] = row => row.Account,
                ["phone"] = row => row.Phone,
                ["email"] = row => row.Email,
                ["createDate"] = row => row.CreateDate,
                ["modifyDate"] = row => row.ModifyDate,
                ["modifyUser"] = row => row.ModifyUser
            };

        /// <summary>
        /// 新增帳號
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ResultDto> AddAccount(AccountInfoModel info)
        {
            //a、驗證輸入欄位。
            ModelValidator.Validate(info, nameof(info));

            var condition = this._mapper.Map<AccountCondition>(info);

            //b、使用者帳號不可重複。
            var checkAccount = await this._accountRepository.GetAccount(condition.Account);
            if (checkAccount != null)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "該使用者帳號已存在，請確認！"
                };
            }

            //c、密碼長度不可低於6碼。
            if (condition.Password.Length < 6)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "使用者密碼長度不可低於6碼！"
                };
            }

            //d、密碼需透過加密處理存入資料庫。
            condition.Password = this.ConverPassword(condition.Account, condition.Password);

            //e、檢查信箱是否合法。
            var checkMail = this.CheckMailFormate(condition.Email);
            if (checkMail.Equals(false))
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "請確認信箱格式！"
                };
            }

            //補上其他欄位
            condition.CreateDate = DateTime.Now;
            condition.ModifyDate = DateTime.Now;
            condition.ModifyUser = "System";

            var result = await this._accountRepository.AddAccount(condition);

            return new ResultDto
            {
                Success = result,
                Message = result ? "新增成功" : "新增失敗"
            };
        }

        /// <summary>
        /// 密碼加密
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal string ConverPassword(string account, string password)
        {
            var sha256 = new SHA256CryptoServiceProvider();
            var source = Encoding.Default.GetBytes(account + password);
            var crypto = sha256.ComputeHash(source);
            var result = Convert.ToBase64String(crypto);

            return result;
        }

        /// <summary>
        /// 確認信箱格式
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool CheckMailFormate(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 忘記密碼
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ResultDto> ForgetPassword(AccountInfoModel info)
        {
            ModelValidator.Validate(info, nameof(info));

            var checkInfo = await this._accountRepository.GetAccount(info.Account);
            if (checkInfo == null)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "請確認輸入之帳號！"
                };
            }

            if (checkInfo.Email != info.Email)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "請確認輸入的Email，是否與註冊時一致！"
                };
            }

            if (checkInfo.Phone != info.Phone)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "請確認輸入的電話，是否與註冊時一致！"
                };
            }

            var condition = this._mapper.Map<ForgetAccountCondition>(info);
            condition.ModifyDate = DateTime.Now;
            condition.ModifyUser = condition.Account;
            condition.Password = this.ConverPassword(condition.Account, condition.Password);

            var result = await this._accountRepository.ForgetPassword(condition);

            return new ResultDto
            {
                Success = result,
                Message = result ? "更新密碼成功" : "更新密碼失敗"
            };
        }

        /// <summary>
        /// 取得單筆帳號資訊
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        /// <exception cref="Exception">Account 不可為空 !</exception>
        public async Task<AccountDto> GetAccount(string account)
        {
            account.CheckNotNullOrEmpty(nameof(account));

            var data = await this._accountRepository.GetAccount(account);
            var result = this._mapper.Map<AccountDto>(data);
            if (result != null)
            {
                result.Phone = this.ConvertPhoneNumber(result.Phone);
            }
            return result;
        }

        /// <summary>
        /// 轉換電話號碼
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private string ConvertPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return phoneNumber;
            }
            else
            {
                return (phoneNumber.Substring(0, 6) + new string('*', phoneNumber.Length - 6));
            }
        }

        /// <summary>
        /// 取得帳號列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AccountDto>> GetAccountList(PagingInfoModel paging)
        {
            IEnumerable<AccountDto> result;
            var data = await this._accountRepository.GetAccountList();
            if (data != null &&
                data.Any())
            {
                result = data.Select(rows => new AccountDto
                {
                    Phone = ConvertPhoneNumber(rows.Phone),
                    Account = rows.Account,
                    CreateDate = rows?.CreateDate.Value.ToString("yyyy/MM/dd"),
                    Email = rows.Email,
                    ModifyDate = rows?.ModifyDate.Value.ToString("yyyy/MM/dd"),
                    ModifyUser = rows.ModifyUser
                });

                if (string.IsNullOrWhiteSpace(paging.OrderColumName))
                {
                    result = result.Order(ref paging);
                }
                else
                {
                    result = result.Order(_accountListColumMap[paging.OrderColumName], ref paging);
                }
            }
            else
            {
                result = null;
            }

            return result;
        }

        /// <summary>
        /// 刪除帳號
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        /// <exception cref="Exception">請檢查輸入欄位，缺一不可！</exception>
        public async Task<ResultDto> RemoveAccount(RemoveAccountInfoModel info)
        {
            ModelValidator.Validate(info, nameof(info));

            var checkInfo = await this._accountRepository.GetAccount(info.Account);

            if (checkInfo == null)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "請確認要刪除的帳號！"
                };
            }

            if (checkInfo.Email != info.Email)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "請確認輸入的EMail是否與註冊時一致！"
                };
            }

            if (checkInfo.Phone != info.Phone)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "請確認輸入的電話是否與註冊時一致！"
                };
            }

            var result = await this._accountRepository.RemoveAccount(info.Account);

            return new ResultDto
            {
                Success = result,
                Message = result ? "刪除成功" : "刪除失敗"
            };
        }

        /// <summary>
        /// 更新帳號資訊
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        /// <exception cref="Exception">請檢查輸入欄位，缺一不可！</exception>
        public async Task<ResultDto> UpdateAccount(AccountInfoModel info)
        {
            ModelValidator.Validate(info, nameof(info));

            var checkPassword = await this._accountRepository.GetAccountPassword(info.Account);

            if (string.IsNullOrWhiteSpace(checkPassword))
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "請確認要更新的帳號！"
                };
            }

            var convertPassword = this.ConverPassword(info.Account, info.Password);

            if (checkPassword != convertPassword)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "請確認輸入的密碼是否與註冊時一致！"
                };
            }

            var condition = this._mapper.Map<UpdateAccountCondition>(info);
            condition.ModifyDate = DateTime.Now;
            condition.ModifyUser = info.Account;

            var result = await this._accountRepository.UpdateAccount(condition);

            return new ResultDto
            {
                Success = result,
                Message = result ? "更新成功" : "更新失敗"
            };
        }
    }
}
