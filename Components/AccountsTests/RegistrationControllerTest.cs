using Accounts;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Users;
using Users.Data;
using Xunit;

namespace AccountsTests
{
    public class RegistrationControllerTest
    {
        private readonly Mock<IRegistrationService> _service;
        private readonly RegistrationController _controller;

        public RegistrationControllerTest()
        {
            _service = new Mock<IRegistrationService>();
            _controller = new RegistrationController(_service.Object);
        }

        [Fact]
        public void TestPost()
        {
            _service.Setup(s => s.CreateUserWithAccount("aUser")).Returns(new UserRecord(123, "aUser"));

            var response = _controller.Create(new UserInfo(-1, "aUser", ""));
            var body = (UserInfo) ((ObjectResult) response).Value;

            Assert.IsType<CreatedResult>(response);

            Assert.Equal(123, body.Id);
            Assert.Equal("aUser", body.Name);
            Assert.Equal("registration info", body.Info);
        }
    }
}