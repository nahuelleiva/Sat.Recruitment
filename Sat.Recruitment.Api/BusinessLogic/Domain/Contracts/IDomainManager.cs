using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Api.Domain.Models;

namespace Sat.Recruitment.Api.Contracts
{
    public interface IDomainManager
    {
        Result AddUser(User user);
    }
}
