using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApiPhase3Common.Model;
using WebApiPhase3Repository.Conditions;
using WebApiPhase3Repository.DataModels;
using WebApiPhase3Repository.Interface;
using WebApiPhase3Service.Dtos;
using WebApiPhase3Service.Implement;
using WebApiPhase3Service.InfoModels;
using WebApiPhase3Service.Mapping;

namespace WebApiPhase3ServiceTests
{
    [TestClass]
    public class AccountServiceTest
    {
        private IAccountRepository _accountRepository;
        private IMapper _mapper
        {
            get
            {
                var config = new MapperConfiguration(options => { options.AddProfile<ServiceProfile>(); });
                return config.CreateMapper();
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            this._accountRepository = Substitute.For<IAccountRepository>();
        }

        private AccountService GetSystemUnderTest()
        {
            var sut = new AccountService(this._accountRepository, this._mapper);
            return sut;
        }

        #region AddAccount

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "AddAccount")]
        public async Task AddAccount_傳入Model為空_應回傳ArgumentNullException()
        {
            //assert
            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                async () => await sut.AddAccount(null));

            //arrange
            exception.Message.Contains("不可為空");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "AddAccount")]
        public async Task AddAccount_Account為空_應回傳ArgumentException()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var fixture = new Fixture();
            var info = fixture.Build<AccountInfoModel>()
                .Without(x => x.Account)
                .Create();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
                async () => await sut.AddAccount(info));

            //arrange
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Account");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "AddAccount")]
        public async Task AddAccount_Account長度超過30_應回傳ArgumentException()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var fixture = new Fixture();
            var info = fixture.Build<AccountInfoModel>()
                .With(x => x.Account, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
                async () => await sut.AddAccount(info));

            //arrange
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Account");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "AddAccount")]
        public async Task AddAccount_Password為空_應回傳ArgumentException()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var fixture = new Fixture();
            var info = fixture.Build<AccountInfoModel>()
                .Without(x => x.Password)
                .Create();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
                async () => await sut.AddAccount(info));

            //arrange
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Password");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "AddAccount")]
        public async Task AddAccount_Password長度超過50_應回傳ArgumentException()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var fixture = new Fixture();
            var info = fixture.Build<AccountInfoModel>()
                .With(x => x.Password, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
                async () => await sut.AddAccount(info));

            //arrange
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Password");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "AddAccount")]
        public async Task AddAccount_Phone為空_應回傳ArgumentException()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var fixture = new Fixture();
            var info = fixture.Build<AccountInfoModel>()
                .Without(x => x.Phone)
                .Create();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
                async () => await sut.AddAccount(info));

            //arrange
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Phone");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "AddAccount")]
        public async Task AddAccount_Phone長度超過20_應回傳ArgumentException()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var fixture = new Fixture();
            var info = fixture.Build<AccountInfoModel>()
                .With(x => x.Phone, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
                async () => await sut.AddAccount(info));

            //arrange
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Phone");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "AddAccount")]
        public async Task AddAccount_Email為空_應回傳ArgumentException()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var fixture = new Fixture();
            var info = fixture.Build<AccountInfoModel>()
                .Without(x => x.Email)
                .Create();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
                async () => await sut.AddAccount(info));

            //arrange
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Email");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "AddAccount")]
        public async Task AddAccount_Email長度超過20_應回傳ArgumentException()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var fixture = new Fixture();
            var info = fixture.Build<AccountInfoModel>()
                .With(x => x.Email, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
                async () => await sut.AddAccount(info));

            //arrange
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Email");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "AddAccount")]
        public async Task AddAccount_使用者帳號重複_應回傳錯誤訊息()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var fixture = new Fixture();

            var info = fixture.Build<AccountInfoModel>()
                .Create();

            var data = fixture.Build<AccountDataModel>()
                .Create();

            var expect = new ResultDto
            {
                Success = false,
                Message = "該使用者帳號已存在，請確認！"
            };

            this._accountRepository.GetAccount(Arg.Any<string>()).Returns(data);

            //act
            var actual = await sut.AddAccount(info);

            //arrange
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "AddAccount")]
        public async Task AddAccount_密碼長度低於6碼_應回傳錯誤訊息()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var fixture = new Fixture();
            var info = fixture.Build<AccountInfoModel>()
                .With(x => x.Password, "1234")
                .Create();

            var expect = new ResultDto
            {
                Success = false,
                Message = "使用者密碼長度不可低於6碼！"
            };

            //act
            var actual = await sut.AddAccount(info);

            //arrange
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "AddAccount")]
        public async Task AddAccount_輸入信箱格式不正確_應回傳錯誤訊息()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var fixture = new Fixture();
            var info = fixture.Build<AccountInfoModel>()
                .With(x => x.Email, "test#gmail.com")
                .Create();

            var expect = new ResultDto
            {
                Success = false,
                Message = "請確認信箱格式！"
            };

            //act
            var actual = await sut.AddAccount(info);

            //arrange
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "AddAccount")]
        public async Task AddAccount_新增成功_應回傳正確訊息()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var fixture = new Fixture();
            var info = fixture.Build<AccountInfoModel>()
                .With(x => x.Email, "test1@gmail.com")
                .Create();

            this._accountRepository.AddAccount(Arg.Any<AccountCondition>()).Returns(true);

            var expect = new ResultDto
            {
                Success = true,
                Message = "新增成功"
            };

            //act
            var actual = await sut.AddAccount(info);

            //arrange
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "AddAccount")]
        public async Task AddAccount_新增失敗_應回傳錯誤訊息()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var fixture = new Fixture();
            var info = fixture.Build<AccountInfoModel>()
                .With(x => x.Email, "test@gmail.com")
                .Create();

            this._accountRepository.AddAccount(Arg.Any<AccountCondition>()).Returns(false);

            var expect = new ResultDto
            {
                Success = false,
                Message = "新增失敗"
            };

            //act
            var actual = await sut.AddAccount(info);

            //arrange
            actual.Should().BeEquivalentTo(expect);
        }
        #endregion AddAccount

        #region GetAccount
        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "GetAccount")]
        public async Task GetAccount_Account為Null_應回傳ArgumentNullException()
        {
            //arrange
            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(
            async () => await sut.GetAccount(null));

            //assert
            exception.Message.Contains("不可為Null");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "GetAccount")]
        public async Task GetAccount_Account為空_應回傳ArgumentException()
        {
            //arrange
            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.GetAccount(string.Empty));

            //assert
            exception.Message.Contains("不可為空");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "GetAccount")]
        public async Task GetAccount_Account有資料_應回傳正確資訊()
        {
            //arrange
            var fixure = new Fixture();
            var data = fixure.Build<AccountDataModel>()
                .With(x => x.CreateDate, DateTime.Now)
                .With(x => x.ModifyDate, DateTime.Now)
                .With(x => x.Phone, "0918777777")
                .Create();

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccount("test123").Returns(data);

            var expect = this._mapper.Map<AccountDto>(data);
            expect.Phone = "091877****";

            //act
            var actual = await sut.GetAccount("test123");

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "GetAccount")]
        public async Task GetAccount_Account無資料_應回傳空值()
        {
            //arrange
            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccount("test123").Returns(default(AccountDataModel));

            //act
            var actual = await sut.GetAccount("test123");

            //assert
            actual.Should().BeNull();
        }
        #endregion GetAccount

        #region GetAccountList
        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "GetAccountList")]
        public async Task GetAccountList_無資料_應回傳空值()
        {
            //arrange
            var sut = this.GetSystemUnderTest();
            await this._accountRepository.GetAccountList();

            //act
            var actual = await sut.GetAccountList(default(PagingInfoModel));

            //assert
            actual.Should().BeNull();
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "GetAccountList")]
        public async Task GetAccountList_有資料沒有按照欄位排序_應回傳正確結果()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountDataModel>()
                .With(x => x.ModifyDate, DateTime.Now)
                .With(x => x.CreateDate, DateTime.Now)
                .With(x => x.Phone, "0918777777")
                .CreateMany();

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccountList().Returns(data);

            var expect = this._mapper.Map<IEnumerable<AccountDto>>(data);
            expect.ToList().ForEach(x => x.Phone = "091877****");

            var paging = new PagingInfoModel
            {
                OrderColumName = "",
                PageIndex = 1,
                PageSize = 10,
                Descending = false
            };

            //act
            var actual = await sut.GetAccountList(paging);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "GetAccountList")]
        public async Task GetAccountList_有資料按照Account排序_應回傳正確結果()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountDataModel>()
                .With(x => x.ModifyDate, DateTime.Now)
                .With(x => x.CreateDate, DateTime.Now)
                .With(x => x.Phone, "0918777777")
                .CreateMany();

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccountList().Returns(data);

            var expect = this._mapper.Map<IEnumerable<AccountDto>>(data);
            expect.ToList().ForEach(x => x.Phone = "091877****");
            expect = expect.OrderByDescending(x => x.Account);

            var paging = new PagingInfoModel
            {
                OrderColumName = "account",
                PageIndex = 1,
                PageSize = 10,
                Descending = true
            };

            //act
            var actual = await sut.GetAccountList(paging);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "GetAccountList")]
        public async Task GetAccountList_有資料按照Phone排序_應回傳正確結果()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountDataModel>()
                .With(x => x.ModifyDate, DateTime.Now)
                .With(x => x.CreateDate, DateTime.Now)
                .With(x => x.Phone, "0918777777")
                .CreateMany();

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccountList().Returns(data);

            var expect = this._mapper.Map<IEnumerable<AccountDto>>(data);
            expect.ToList().ForEach(x => x.Phone = "091877****");
            expect = expect.OrderByDescending(x => x.Phone);

            var paging = new PagingInfoModel
            {
                OrderColumName = "phone",
                PageIndex = 1,
                PageSize = 10,
                Descending = true
            };

            //act
            var actual = await sut.GetAccountList(paging);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "GetAccountList")]
        public async Task GetAccountList_有資料按照Email排序_應回傳正確結果()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountDataModel>()
                .With(x => x.ModifyDate, DateTime.Now)
                .With(x => x.CreateDate, DateTime.Now)
                .With(x => x.Phone, "0918777777")
                .CreateMany();

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccountList().Returns(data);

            var expect = this._mapper.Map<IEnumerable<AccountDto>>(data);
            expect.ToList().ForEach(x => x.Phone = "091877****");
            expect = expect.OrderByDescending(x => x.Email);

            var paging = new PagingInfoModel
            {
                OrderColumName = "email",
                PageIndex = 1,
                PageSize = 10,
                Descending = true
            };

            //act
            var actual = await sut.GetAccountList(paging);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "GetAccountList")]
        public async Task GetAccountList_有資料按照CreateDate排序_應回傳正確結果()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountDataModel>()
                .With(x => x.ModifyDate, DateTime.Now)
                .With(x => x.CreateDate, DateTime.Now)
                .With(x => x.Phone, "0918777777")
                .CreateMany();

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccountList().Returns(data);

            var expect = this._mapper.Map<IEnumerable<AccountDto>>(data);
            expect.ToList().ForEach(x => x.Phone = "091877****");
            expect = expect.OrderByDescending(x => x.CreateDate);

            var paging = new PagingInfoModel
            {
                OrderColumName = "createDate",
                PageIndex = 1,
                PageSize = 10,
                Descending = true
            };

            //act
            var actual = await sut.GetAccountList(paging);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "GetAccountList")]
        public async Task GetAccountList_有資料按照ModifyDate排序_應回傳正確結果()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountDataModel>()
                .With(x => x.ModifyDate, DateTime.Now)
                .With(x => x.CreateDate, DateTime.Now)
                .With(x => x.Phone, "0918777777")
                .CreateMany();

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccountList().Returns(data);

            var expect = this._mapper.Map<IEnumerable<AccountDto>>(data);
            expect.ToList().ForEach(x => x.Phone = "091877****");
            expect = expect.OrderByDescending(x => x.ModifyDate);

            var paging = new PagingInfoModel
            {
                OrderColumName = "modifyDate",
                PageIndex = 1,
                PageSize = 10,
                Descending = true
            };

            //act
            var actual = await sut.GetAccountList(paging);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "GetAccountList")]
        public async Task GetAccountList_有資料按照ModifyUser排序_應回傳正確結果()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountDataModel>()
                .With(x => x.ModifyDate, DateTime.Now)
                .With(x => x.CreateDate, DateTime.Now)
                .With(x => x.Phone, "0918777777")
                .CreateMany();

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccountList().Returns(data);

            var expect = this._mapper.Map<IEnumerable<AccountDto>>(data);
            expect.ToList().ForEach(x => x.Phone = "091877****");
            expect = expect.OrderByDescending(x => x.ModifyUser);

            var paging = new PagingInfoModel
            {
                OrderColumName = "modifyUser",
                PageIndex = 1,
                PageSize = 10,
                Descending = true
            };

            //act
            var actual = await sut.GetAccountList(paging);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }


        #endregion GetAccountList

        #region RemoveAccount
        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "RemoveAccount")]
        public async Task RemoveAccount_傳入的model為空_應回傳ArgumentNullException()
        {
            //arrange
            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(
            async () => await sut.RemoveAccount(null));

            //assert
            exception.Message.Contains("不可為Null");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "RemoveAccount")]
        public async Task RemoveAccount_傳入的Account為空_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<RemoveAccountInfoModel>()
                .Without(x => x.Account)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.RemoveAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Account");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "RemoveAccount")]
        public async Task RemoveAccount_傳入的Account長度超過30_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<RemoveAccountInfoModel>()
                .With(x => x.Account, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.RemoveAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Account");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "RemoveAccount")]
        public async Task RemoveAccount_傳入的Phone為空_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<RemoveAccountInfoModel>()
                .Without(x => x.Phone)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.RemoveAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Phone");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "RemoveAccount")]
        public async Task RemoveAccount_傳入的Phone長度超過20_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<RemoveAccountInfoModel>()
                .With(x => x.Phone, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.RemoveAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Phone");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "RemoveAccount")]
        public async Task RemoveAccount_傳入的Email為空_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<RemoveAccountInfoModel>()
                .Without(x => x.Email)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.RemoveAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Email");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "RemoveAccount")]
        public async Task RemoveAccount_傳入的Email長度超過20_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<RemoveAccountInfoModel>()
                .With(x => x.Email, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.RemoveAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Email");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "RemoveAccount")]
        public async Task RemoveAccount_查無帳號_應回傳錯誤訊息()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<RemoveAccountInfoModel>()
                .Create();

            var expect = new ResultDto
            {
                Success = false,
                Message = "請確認要刪除的帳號！"
            };

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccount("test111122").Returns(default(AccountDataModel));

            //act
            var actual = await sut.RemoveAccount(data);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "RemoveAccount")]
        public async Task RemoveAccount_輸入Email與資料不一致_應回傳錯誤訊息()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<RemoveAccountInfoModel>()
                .With(x => x.Account, "test111122")
                .With(x => x.Email, "test22@gmail.com")
                .Create();

            var checkInfo = fixture.Build<AccountDataModel>()
                .With(x => x.Account, "test111122")
                .With(x => x.Email, "test123@gmail.com")
                .Create();

            var expect = new ResultDto
            {
                Success = false,
                Message = "請確認輸入的EMail是否與註冊時一致！"
            };

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccount("test111122").Returns(checkInfo);

            //act
            var actual = await sut.RemoveAccount(data);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "RemoveAccount")]
        public async Task RemoveAccount_輸入電話與資料不一致_應回傳錯誤訊息()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<RemoveAccountInfoModel>()
                .With(x => x.Account, "test111122")
                .With(x => x.Email, "test123@gmail.com")
                .With(x => x.Phone, "0988123412")
                .Create();

            var checkInfo = fixture.Build<AccountDataModel>()
                .With(x => x.Account, "test111122")
                .With(x => x.Email, "test123@gmail.com")
                .With(x => x.Phone, "0988123456")
                .Create();

            var expect = new ResultDto
            {
                Success = false,
                Message = "請確認輸入的電話是否與註冊時一致！"
            };

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccount("test111122").Returns(checkInfo);

            //act
            var actual = await sut.RemoveAccount(data);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "RemoveAccount")]
        public async Task RemoveAccount_刪除失敗_應回傳錯誤訊息()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<RemoveAccountInfoModel>()
                .With(x => x.Account, "test111122")
                .With(x => x.Email, "test123@gmail.com")
                .With(x => x.Phone, "0988123456")
                .Create();

            var checkInfo = fixture.Build<AccountDataModel>()
                .With(x => x.Account, "test111122")
                .With(x => x.Email, "test123@gmail.com")
                .With(x => x.Phone, "0988123456")
                .Create();

            var expect = new ResultDto
            {
                Success = false,
                Message = "刪除失敗"
            };

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccount("test111122").Returns(checkInfo);
            this._accountRepository.RemoveAccount("test111122").Returns(false);

            //act
            var actual = await sut.RemoveAccount(data);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "RemoveAccount")]
        public async Task RemoveAccount_刪除成功_應回傳正確訊息()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<RemoveAccountInfoModel>()
                .With(x => x.Account, "test111122")
                .With(x => x.Email, "test123@gmail.com")
                .With(x => x.Phone, "0988123456")
                .Create();

            var checkInfo = fixture.Build<AccountDataModel>()
                .With(x => x.Account, "test111122")
                .With(x => x.Email, "test123@gmail.com")
                .With(x => x.Phone, "0988123456")
                .Create();

            var expect = new ResultDto
            {
                Success = true,
                Message = "刪除成功"
            };

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccount("test111122").Returns(checkInfo);
            this._accountRepository.RemoveAccount("test111122").Returns(true);

            //act
            var actual = await sut.RemoveAccount(data);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        #endregion RemoveAccount

        #region UpdateAccount
        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "UpdateAccount")]
        public async Task UpdateAccount_輸入model為null_應回傳ArgumentNullException()
        {
            //arrange
            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(
            async () => await sut.UpdateAccount(null));

            //assert
            exception.Message.Contains("不可為Null");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "UpdateAccount")]
        public async Task UpdateAccount_輸入Account為空_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .Without(x => x.Account)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.UpdateAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Account");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "UpdateAccount")]
        public async Task UpdateAccount_輸入Account長度超過30_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .With(x => x.Account, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.UpdateAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Account");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "UpdateAccount")]
        public async Task UpdateAccount_輸入Password為空_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .Without(x => x.Password)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.UpdateAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Password");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "UpdateAccount")]
        public async Task UpdateAccount_輸入Password長度超過50_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .With(x => x.Password, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.UpdateAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Password");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "UpdateAccount")]
        public async Task UpdateAccount_輸入Phone為空_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .Without(x => x.Phone)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.UpdateAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Phone");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "UpdateAccount")]
        public async Task UpdateAccount_輸入Phone長度超過20_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .With(x => x.Phone, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.UpdateAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Phone");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "UpdateAccount")]
        public async Task UpdateAccount_輸入Email為空_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .Without(x => x.Email)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.UpdateAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Email");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "UpdateAccount")]
        public async Task UpdateAccount_輸入Email長度超過20_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .With(x => x.Email, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.UpdateAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Email");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "UpdateAccount")]
        public async Task UpdateAccount_找無輸入帳號之密碼資訊_應回傳錯誤訊息()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .Create();

            var expect = new ResultDto()
            {
                Success = false,
                Message = "請確認要更新的帳號！"
            };

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccountPassword("test2").Returns("");

            //act
            var actual = await sut.UpdateAccount(data);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "UpdateAccount")]
        public async Task UpdateAccount_輸入之密碼與註冊時不一致_應回傳錯誤訊息()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .With(x => x.Account, "test2")
                .Create();

            var expect = new ResultDto()
            {
                Success = false,
                Message = "請確認輸入的密碼是否與註冊時一致！"
            };

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccountPassword("test2").Returns("9GYVaHLoOg+y+V/HHwKtkzBH3y8XWn14h8ifWP");

            //act
            var actual = await sut.UpdateAccount(data);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "UpdateAccount")]
        public async Task UpdateAccount_更新失敗_應回傳錯誤訊息()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .With(x => x.Account, "test2")
                .With(x => x.Password, "12371324")
                .Create();

            var expect = new ResultDto()
            {
                Success = false,
                Message = "更新失敗"
            };

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccountPassword("test2").Returns("9GYVaHLoOg+y+V/HHwKtkzBH3y8XWn14h8ifWPYViLc=");
            this._accountRepository.UpdateAccount(Arg.Any<UpdateAccountCondition>()).Returns(false);

            //act
            var actual = await sut.UpdateAccount(data);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "UpdateAccount")]
        public async Task UpdateAccount_更新成功使用AutoFixture_應回傳正確訊息()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .With(x => x.Account, "test2")
                .With(x => x.Password, "12371324")
                .Create();

            var expect = new ResultDto()
            {
                Success = true,
                Message = "更新成功"
            };

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccountPassword("test2").Returns("9GYVaHLoOg+y+V/HHwKtkzBH3y8XWn14h8ifWPYViLc=");
            this._accountRepository.UpdateAccount(Arg.Any<UpdateAccountCondition>()).Returns(true);

            //act
            var actual = await sut.UpdateAccount(data);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }
        #endregion UpdateAccount

        #region ForgetPassword
        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ForgetPassword")]
        public async Task ForgetPassword_輸入model為null_應回傳ArgumentNullException()
        {
            //arrange
            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(
            async () => await sut.ForgetPassword(null));

            //assert
            exception.Message.Contains("不可為Null");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ForgetPassword")]
        public async Task ForgetPassword_輸入Account為空_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .Without(x => x.Account)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.ForgetPassword(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Account");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ForgetPassword")]
        public async Task ForgetPassword_輸入Account長度超過30_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .With(x => x.Account, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.ForgetPassword(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Account");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ForgetPassword")]
        public async Task ForgetPassword_輸入Password為空_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .Without(x => x.Password)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.ForgetPassword(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Password");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ForgetPassword")]
        public async Task ForgetPassword_輸入Password長度超過50_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .With(x => x.Password, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.ForgetPassword(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Password");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ForgetPassword")]
        public async Task ForgetPassword_輸入Phone為空_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .Without(x => x.Phone)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.ForgetPassword(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Phone");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ForgetPassword")]
        public async Task ForgetPassword_輸入Phone長度超過20_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .With(x => x.Phone, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.ForgetPassword(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Phone");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ForgetPassword")]
        public async Task ForgetPassword_輸入Email為空_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .Without(x => x.Email)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.ForgetPassword(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Email");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ForgetPassword")]
        public async Task ForgetPassword_輸入Email長度超過20_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .With(x => x.Email, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.ForgetPassword(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("Email");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ForgetPassword")]
        public async Task ForgetPassword_找無輸入之帳號資訊_應回傳錯誤訊息()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .Create();

            var expect = new ResultDto()
            {
                Success = false,
                Message = "請確認輸入之帳號！"
            };

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccount("test2").Returns(default(AccountDataModel));

            //act
            var actual = await sut.ForgetPassword(data);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ForgetPassword")]
        public async Task ForgetPassword_輸入之Email與註冊不一致_應回傳錯誤訊息()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .With(x => x.Account, "test2")
                .With(x => x.Password, "12371324")
                .With(x => x.Phone, "0988123456")
                .Create();

            var returnData = fixture.Build<AccountDataModel>()
                .With(x => x.Account, "test2")
                .With(x => x.Phone, "0988123456")
                .Create();

            var expect = new ResultDto()
            {
                Success = false,
                Message = "請確認輸入的Email，是否與註冊時一致！"
            };

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccount("test2").Returns(returnData);

            //act
            var actual = await sut.ForgetPassword(data);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ForgetPassword")]
        public async Task ForgetPassword_輸入之電話與註冊不一致_應回傳錯誤訊息()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .With(x => x.Account, "test2")
                .With(x => x.Email, "test123@gmail.com")
                .With(x => x.Password, "12371324")
                .With(x => x.Phone, "0988123456")
                .Create();

            var returnData = fixture.Build<AccountDataModel>()
                .With(x => x.Account, "test2")
                .With(x => x.Phone, "0988123477")
                .With(x => x.Email, "test123@gmail.com")
                .Create();

            var expect = new ResultDto()
            {
                Success = false,
                Message = "請確認輸入的電話，是否與註冊時一致！"
            };

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccount("test2").Returns(returnData);

            //act
            var actual = await sut.ForgetPassword(data);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ForgetPassword")]
        public async Task ForgetPassword_更新失敗_應回傳錯誤訊息()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .With(x => x.Account, "test2")
                .With(x => x.Email, "test123@gmail.com")
                .With(x => x.Password, "12371324")
                .With(x => x.Phone, "0988123456")
                .Create();

            var returnData = fixture.Build<AccountDataModel>()
                .With(x => x.Account, "test2")
                .With(x => x.Phone, "0988123456")
                .With(x => x.Email, "test123@gmail.com")
                .Create();

            var expect = new ResultDto()
            {
                Success = false,
                Message = "更新密碼失敗"
            };

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccount("test2").Returns(returnData);
            this._accountRepository.ForgetPassword(Arg.Any<ForgetAccountCondition>()).Returns(false);

            //act
            var actual = await sut.ForgetPassword(data);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ForgetPassword")]
        public async Task ForgetPassword_更新成功_應回傳錯誤訊息()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<AccountInfoModel>()
                .With(x => x.Account, "test2")
                .With(x => x.Email, "test123@gmail.com")
                .With(x => x.Password, "12371324")
                .With(x => x.Phone, "0988123456")
                .Create();

            var returnData = fixture.Build<AccountDataModel>()
                .With(x => x.Account, "test2")
                .With(x => x.Phone, "0988123456")
                .With(x => x.Email, "test123@gmail.com")
                .Create();

            var expect = new ResultDto()
            {
                Success = true,
                Message = "更新密碼成功"
            };

            var sut = this.GetSystemUnderTest();
            this._accountRepository.GetAccount("test2").Returns(returnData);
            this._accountRepository.ForgetPassword(Arg.Any<ForgetAccountCondition>()).Returns(true);

            //act
            var actual = await sut.ForgetPassword(data);

            //assert
            actual.Should().BeEquivalentTo(expect);
        }
        #endregion ForgetPassword

        #region Private and Internal Function
        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ConverPassword")]
        public void ConverPassword_輸入密碼_應回傳加密結果()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var expect = "9GYVaHLoOg+y+V/HHwKtkzBH3y8XWn14h8ifWPYViLc=";

            //act
            var actual = sut.ConverPassword("test2", "12371324");

            //arrange
            actual.Should().Be(expect);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "CheckMailFormate")]
        public void CheckMailFormate_輸入錯誤格式Mail_應回傳False()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var method = sut.GetType().GetMethod("CheckMailFormate", BindingFlags.Instance | BindingFlags.NonPublic);

            //act
            var actual = method.Invoke(sut, new[] { "fff#gmail.com" });

            //arrange
            actual.Should().Be(false);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "CheckMailFormate")]
        public void CheckMailFormate_輸入正確格式Mail_應回傳True()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var method = sut.GetType().GetMethod("CheckMailFormate", BindingFlags.Instance | BindingFlags.NonPublic);

            //act
            var actual = method.Invoke(sut, new[] { "fff@gmail.com" });

            //arrange
            actual.Should().Be(true);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ConvertPhoneNumber")]
        public void ConvertPhoneNumber_輸入空字串_應直接回傳空字串()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var method = sut.GetType().GetMethod("ConvertPhoneNumber", BindingFlags.Instance | BindingFlags.NonPublic);

            //act
            var actual = method.Invoke(sut, new[] { string.Empty });

            //arrange
            actual.Should().Be(string.Empty);
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ConvertPhoneNumber")]
        public void ConvertPhoneNumber_輸入電話號碼_應回傳轉換後結果()
        {
            //assert
            var sut = this.GetSystemUnderTest();
            var method = sut.GetType().GetMethod("ConvertPhoneNumber", BindingFlags.Instance | BindingFlags.NonPublic);
            var expect = "091877****";

            //act
            var actual = method.Invoke(sut, new[] { "0918777888" });

            //arrange
            actual.Should().Be(expect);
        }
        #endregion
    }
}
