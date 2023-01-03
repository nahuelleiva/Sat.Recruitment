using AutoMapper;
using Sat.Recruitment.Api.Constants;
using Sat.Recruitment.Api.Domain.Models;
using Sat.Recruitment.Api.DTO;
using System;

namespace Sat.Recruitment.Api.Mapping
{
    /// <summary>
    /// Class to map DTO objects into business logic objects
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<UserDto, User>();

            CreateMap<UserDto, User>().ForMember(dest => dest.Money,
                mce => mce.MapFrom(src => CalculateMoneyAmountBasedOnRole(src.UserType.ToLowerInvariant(), src.Money)));
        }

        private decimal CalculateMoneyAmountBasedOnRole(string role, decimal currentMoneyAmount)
        {
            decimal percentage = 0;

            switch (role) {
                case UserRoles.SUPER_USER:
                    percentage = Convert.ToDecimal(0.20);
                    break;
                case UserRoles.NORMAL:
                    percentage = currentMoneyAmount > 100 ? Convert.ToDecimal(0.12) : Convert.ToDecimal(0.8);
                    break;
                case UserRoles.PREMIUM:
                    percentage = 2;
                    break;
            }

            currentMoneyAmount += (currentMoneyAmount * percentage);

            return currentMoneyAmount;
        }
    }
}
