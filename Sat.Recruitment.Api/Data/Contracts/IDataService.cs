using Sat.Recruitment.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Contracts
{
    public interface IDataService
    {
        List<User> GetUsers();
        void Save(User user);
    }
}
