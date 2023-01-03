using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Api.Contracts;
using Sat.Recruitment.Api.Domain;
using Sat.Recruitment.Api.Domain.Models;
using Sat.Recruitment.Api.DTO;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IDomainManager _domainManager;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            IDomainManager domainManager,
            IMapper mapper,
            ILogger<UsersController> logger)
        {
            _domainManager = domainManager;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        [Route("add-user")]
        public IActionResult AddUser([FromBody] UserDto user)
        {
            try
            {
                var newUser = _mapper.Map<UserDto, User>(user);
                var domainResponse = _domainManager.AddUser(newUser);

                if (!domainResponse.IsSuccess) {
                    return StatusCode(500, string.Join(". ", domainResponse.Errors));
                }

                return Ok(domainResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal Server Error -- {ex.Message}");
                _logger.LogError($"Stacktrace -- {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
