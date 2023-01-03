using Moq;
using Sat.Recruitment.Api.Domain;
using Xunit;
using Sat.Recruitment.Api.Constants;
using Sat.Recruitment.Api.Domain.Models;
using Sat.Recruitment.Api.Contracts;
using System.Collections.Generic;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        private readonly IDomainManager _domainManagerMock;
        private readonly Mock<IDataService> _dataServiceMock = new Mock<IDataService>();

        public UnitTest1() {
            _dataServiceMock.Setup(x => x.GetUsers()).Returns(GetUsers());
            _domainManagerMock = new DomainManager(_dataServiceMock.Object);
        }

        private List<User> GetUsers()
        {
            var _users = new List<User>
            {
                new User() { 
                    Name = "Nahuel Leiva", 
                    Email = "nleiva@gmail.com", 
                    Phone = "+5493446604239", 
                    Address = "Bolivar 1047",
                    UserType = UserRoles.NORMAL,
                    Money = 1234 
                },
                new User() { 
                    Name = "Charles Xavier", 
                    Email = "cx@gmail.com", 
                    Phone = "0101", 
                    Address = "Estados Unidos",
                    UserType = UserRoles.SUPER_USER,
                    Money = 10 
                },
                new User()
                {
                    Name = "Agustina",
                    Email = "Agustina@gmail.com",
                    Phone = "+349 1122354215",
                    Address = "Av. Juan G",
                    UserType = UserRoles.NORMAL,
                    Money = 124
                }
            };

            return _users;
        }

        [Fact]
        public void AddUserSuccess_Test()
        {
            var dto = new User()
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "San Juan",
                Phone = "101",
                UserType = UserRoles.NORMAL,
                Money = 124
            };

            var result = _domainManagerMock.AddUser(dto);

            Assert.True(result.IsSuccess);
            Assert.Null(result.Errors);
        }

        [Fact]
        public void DuplicatedUser_Test()
        {
            var user = new User()
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Phone = "+349 1122354215",
                Address = "Av. Juan G",
                UserType = UserRoles.NORMAL,
                Money = 124
            };

            var result = _domainManagerMock.AddUser(user);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.Errors);
        }
    }
}
