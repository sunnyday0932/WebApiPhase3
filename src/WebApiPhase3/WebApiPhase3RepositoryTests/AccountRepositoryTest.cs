using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApiPhase3Repository.Conditions;
using WebApiPhase3Repository.Implement;
using WebApiPhase3Repository.Infrastructure;
using WebApiPhase3RepositoryTests.TestUtilites;

namespace WebApiPhase3RepositoryTests
{
    [TestClass]
    public class AccountRepositoryTest
    {
        private static readonly string connectionString = TestHook.SampleDbConnection;
        private IDatabaseHelper _databaseHelper { get; set; }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TableCommands.DropTable(connectionString, "Users");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            TableCommands.DropTable(connectionString, "Users");

            var createScript = File.ReadAllText(@"DbScripts\Create.sql");
            TableCommands.CreateTable(connectionString, createScript);

            var insertScript = File.ReadAllText(@"DbScripts\Insert.sql");
            TableCommands.Execute(connectionString, insertScript);

            this._databaseHelper = new DatabaseHelper();
        }

        private AccountRepository GetSystemUnderTest()
        {
            var sut = new AccountRepository(
                connectionString,
                this._databaseHelper);

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
            var info = fixture.Build<AccountCondition>()
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
            var info = fixture.Build<AccountCondition>()
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
            var info = fixture.Build<AccountCondition>()
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
            var info = fixture.Build<AccountCondition>()
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
            var info = fixture.Build<AccountCondition>()
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
            var info = fixture.Build<AccountCondition>()
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
            var info = fixture.Build<AccountCondition>()
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
            var info = fixture.Build<AccountCondition>()
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
        [TestCategory("AccountRepository")]
        [TestProperty("AccountRepository", "AddAccount")]
        public async Task AddAccount_傳入model_建立成功_應回傳True()
        {
            //arrange
            var fixture = new Fixture();
            var condition = fixture.Build<AccountCondition>()
                .With(x => x.Phone, "09111111")
                .With(x => x.Email, "test@yahoo.com")
                .With(x => x.Account, "test2444")
                .With(x => x.Password, "231543214")
                .With(x => x.ModifyUser, "123423")
                .Create();
            var sut = this.GetSystemUnderTest();

            //act
            var actual = await sut.AddAccount(condition);

            //assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("AccountRepository")]
        [TestProperty("AccountRepository", "AddAccount")]
        public async Task AddAccount_傳入model_建立已存在的資料_應回傳SqlException()
        {
            //arrange
            var fixture = new Fixture();
            var condition = fixture.Build<AccountCondition>()
                .With(x => x.Phone, "09111111")
                .With(x => x.Email, "test@yahoo.com")
                .With(x => x.Account, "test2")
                .With(x => x.Password, "231543214")
                .With(x => x.ModifyUser, "123423")
                .Create();
            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<SqlException>(
               async () => await sut.AddAccount(condition));

            //assert
            exception.Message.Contains("Cannot insert duplicate key");
        }
        #endregion AddAccount

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
            var data = fixture.Build<ForgetAccountCondition>()
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
            var data = fixture.Build<ForgetAccountCondition>()
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
            var data = fixture.Build<ForgetAccountCondition>()
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
            var data = fixture.Build<ForgetAccountCondition>()
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
        public async Task ForgetPassword_輸入ModifyDate為空_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<ForgetAccountCondition>()
                .Without(x => x.ModifyDate)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.ForgetPassword(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("ModifyDate");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ForgetPassword")]
        public async Task ForgetPassword_輸入ModifyUser為空_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<ForgetAccountCondition>()
                .Without(x => x.ModifyUser)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.ForgetPassword(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("ModifyUser");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "ForgetPassword")]
        public async Task ForgetPassword_輸入ModifyUser長度超過30_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<ForgetAccountCondition>()
                .With(x => x.ModifyUser, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.ForgetPassword(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("ModifyUser");
        }

        [TestMethod]
        [TestCategory("AccountRepository")]
        [TestProperty("AccountRepository", "ForgetPassword")]
        public async Task ForgetPassword_傳入model_更新成功_應回傳True()
        {
            //arrange
            var fixture = new Fixture();
            var condition = fixture.Build<ForgetAccountCondition>()
                .With(x => x.Account, "test2")
                .With(x => x.Password, "231543214")
                .With(x => x.ModifyUser, "test2")
                .With(x => x.ModifyDate, DateTime.Now)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var actual = await sut.ForgetPassword(condition);

            //assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("AccountRepository")]
        [TestProperty("AccountRepository", "ForgetPassword")]
        public async Task ForgetPassword_傳入model_更新不存在的帳號_應回傳False()
        {
            //arrange
            var fixture = new Fixture();
            var condition = fixture.Build<ForgetAccountCondition>()
                .With(x => x.Account, "test5")
                .With(x => x.Password, "231543214")
                .With(x => x.ModifyUser, "test2")
                .With(x => x.ModifyDate, DateTime.Now)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var actual = await sut.ForgetPassword(condition);

            //assert
            actual.Should().BeFalse();
        }

        #endregion ForgetPassword

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
        [TestCategory("AccountRepository")]
        [TestProperty("AccountRepository", "GetAccount")]
        public async Task GetAccount_輸入存在的帳號_回傳的model不為空()
        {
            //arrange
            var sut = this.GetSystemUnderTest();

            //act
            var actual = await sut.GetAccount("test2");

            //assert
            actual.Should().NotBeNull();
        }

        [TestMethod]
        [TestCategory("AccountRepository")]
        [TestProperty("AccountRepository", "GetAccount")]
        public async Task GetAccount_輸入存在的帳號_應回傳null()
        {
            //arrange
            var sut = this.GetSystemUnderTest();

            //act
            var actual = await sut.GetAccount("test5");

            //assert
            actual.Should().BeNull();
        }
        #endregion GetAccount

        #region GetAccountList
        [TestMethod]
        [TestCategory("AccountRepository")]
        [TestProperty("AccountRepository", "GetAccountList")]
        public async Task GetAccountList_回傳的list應為2()
        {
            //arrange
            var sut = this.GetSystemUnderTest();

            //act
            var actual = await sut.GetAccountList();

            //assert
            actual.Should().NotBeNull();
            actual.Count().Should().Be(2);
        }
        #endregion GetAccountList

        #region GetAccountPassword

        [TestMethod]
        [TestCategory("AccountRepository")]
        [TestProperty("AccountRepository", "GetAccountPassword")]
        public async Task GetAccountPassword_輸入存在的帳號_應回傳password()
        {
            //arrange
            var sut = this.GetSystemUnderTest();

            //act
            var actual = await sut.GetAccountPassword("test2");

            //assert
            actual.Should().NotBeNull();
        }

        [TestMethod]
        [TestCategory("AccountRepository")]
        [TestProperty("AccountRepository", "GetAccountPassword")]
        public async Task GetAccountPassword_帳號為Null_應回傳ArgumentNullException()
        {
            //arrange
            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(
            async () => await sut.GetAccountPassword(null));

            //assert
            exception.Message.Contains("不可為Null");
        }

        [TestMethod]
        [TestCategory("AccountRepository")]
        [TestProperty("AccountRepository", "GetAccountPassword")]
        public async Task GetAccountPassword_輸入不存在的帳號_應回傳null()
        {
            //arrange
            var sut = this.GetSystemUnderTest();

            //act
            var actual = await sut.GetAccountPassword("test6666");

            //assert
            actual.Should().BeNull();
        }

        #endregion GetAccountPassword

        #region RemoveAccount

        [TestMethod]
        [TestCategory("AccountRepository")]
        [TestProperty("AccountRepository", "RemoveAccount")]
        public async Task RemoveAccount_輸入帳號為Null_應回傳ArgumentNullException()
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
        [TestCategory("AccountRepository")]
        [TestProperty("AccountRepository", "RemoveAccount")]
        public async Task RemoveAccount_輸入存在的帳號_刪除成功_應回傳True()
        {
            //arrange
            var sut = this.GetSystemUnderTest();

            //act
            var actual = await sut.RemoveAccount("test2");

            //assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("AccountRepository")]
        [TestProperty("AccountRepository", "RemoveAccount")]
        public async Task RemoveAccount_輸入不存在的帳號_異動0筆_應回傳False()
        {
            //arrange
            var sut = this.GetSystemUnderTest();

            //act
            var actual = await sut.RemoveAccount("test25555");

            //assert
            actual.Should().BeFalse();
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
            var data = fixture.Build<UpdateAccountCondition>()
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
            var data = fixture.Build<UpdateAccountCondition>()
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
        public async Task UpdateAccount_輸入Phone長度超過20_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<UpdateAccountCondition>()
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
        public async Task UpdateAccount_輸入Email長度超過20_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<UpdateAccountCondition>()
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
        public async Task UpdateAccount_輸入ModifyDate為空_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<UpdateAccountCondition>()
                .Without(x => x.ModifyDate)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.UpdateAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("ModifyDate");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "UpdateAccount")]
        public async Task UpdateAccount_輸入ModifyUser為空_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<UpdateAccountCondition>()
                .Without(x => x.ModifyUser)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.UpdateAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("ModifyUser");
        }

        [TestMethod]
        [Owner("Sian")]
        [TestCategory("AccountServiceTest")]
        [TestProperty("AccountServiceTest", "UpdateAccount")]
        public async Task UpdateAccount_輸入ModifyUser長度超過30_應回傳ArgumentException()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.Build<UpdateAccountCondition>()
                .With(x => x.ModifyUser, "123456789123456789123456789123456789123456789123456789123456789")
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            async () => await sut.UpdateAccount(data));

            //assert
            exception.Message.Contains("請檢查輸入欄位");
            exception.ParamName.Should().Be("ModifyUser");
        }

        [TestMethod]
        [TestCategory("AccountRepository")]
        [TestProperty("AccountRepository", "UpdateAccount")]
        public async Task UpdateAccount_更新成功_應回傳True()
        {
            //arrange
            var fixture = new Fixture();
            var condiont = fixture.Build<UpdateAccountCondition>()
                .With(x => x.Account, "test2")
                .With(x => x.Phone, "09111111")
                .With(x => x.Email, "test@yahoo.com")
                .With(x => x.ModifyUser, "123423")
                .With(x => x.ModifyDate, DateTime.Now)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var actual = await sut.UpdateAccount(condiont);

            //assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("AccountRepository")]
        [TestProperty("AccountRepository", "UpdateAccount")]
        public async Task UpdateAccount_輸入不存在的帳號_異動0筆_應回傳False()
        {
            //arrange
            var fixture = new Fixture();
            var condiont = fixture.Build<UpdateAccountCondition>()
                .With(x => x.Account, "test253")
                .With(x => x.Phone, "09111111")
                .With(x => x.Email, "test@yahoo.com")
                .With(x => x.ModifyUser, "123423")
                .With(x => x.ModifyDate, DateTime.Now)
                .Create();

            var sut = this.GetSystemUnderTest();

            //act
            var actual = await sut.UpdateAccount(condiont);

            //assert
            actual.Should().BeFalse();
        }
        #endregion UpdateAccount
    }
}
