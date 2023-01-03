using Sat.Recruitment.Api.Common;
using System;
using System.Linq;
using System.Collections.Generic;
using Sat.Recruitment.Api.Constants;
using Sat.Recruitment.Api.Domain.Models;
using Sat.Recruitment.Api.Contracts;

namespace Sat.Recruitment.Api.Domain
{
    /// <summary>
    /// Manages the business logic
    /// </summary>
    public class DomainManager : IDomainManager
    {
        private List<User> _userList;
        private readonly IDataService _dataService;

        public DomainManager(IDataService dataService) {
            _dataService = dataService;
        }

        public List<User> UsersContainer {
            get {
                if (_userList == null)
                {
                    _userList = _dataService.GetUsers();
                    return _userList;
                }
                else
                    return _userList;
            }
        }
        /// <summary>
        /// Validates a user and adds it to the list of users
        /// </summary>
        /// <param name="user">User to be validated and added</param>
        /// <returns>A <see cref="Result"/> object containing the result of the operation</returns>
        public Result AddUser(User user) 
        {
            var result = new Result();
            try
            {
                var duplicatedUser = ValidateUser(user);
                if (!duplicatedUser.IsSuccess)
                {
                    result.IsSuccess = false;
                    result.Errors = duplicatedUser.Errors;
                    return result;
                }

                _dataService.Save(user);
                result.IsSuccess = true;
                result.Errors = null;

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private Result ValidateUser(User user)
        {
            var result = new Result
            {
                IsSuccess = true,
                Errors = new List<string>()
            };

            // Same Email or Phone?
            if (UsersContainer.Exists(u => u.Email == user.Email))
                result.Errors.Add(ErrorMessages.DUPLICATED_USER_BY_EMAIL);
            
            if (UsersContainer.Exists(u => u.Phone == user.Phone))
                result.Errors.Add(ErrorMessages.DUPLICATED_USER_BY_PHONE);

            // same Name and Address
            if (UsersContainer.Exists(u => u.Name == user.Name && u.Address == user.Address))
                result.Errors.Add(ErrorMessages.DUPLICATED_USER_BY_NAME_AND_ADDRESS);

            result.IsSuccess = !result.Errors.Any();

            return result;
        }
    }
}
