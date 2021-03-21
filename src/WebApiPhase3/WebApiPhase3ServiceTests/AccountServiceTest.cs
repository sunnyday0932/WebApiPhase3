using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
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

        
        #endregion GetAccountList
    }
}
