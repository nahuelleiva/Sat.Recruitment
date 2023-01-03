using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Sat.Recruitment.Api.Contracts;
using Sat.Recruitment.Api.Domain.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Sat.Recruitment.Api.DataService
{
    public class DataService : IDataService
    {
        private readonly CsvConfiguration _config;
        private List<User> _users;
        private readonly string _path;

        public DataService(IConfiguration configuration)
        {
            _path = Directory.GetCurrentDirectory() + configuration["DataSource:Path"];
            _config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = bool.Parse(configuration["DataSource:HasHeader"])
            };

            LoadUsers();
        }

        class UserMap : ClassMap<User>
        {
            public UserMap()
            {
                Map(p => p.Name).Index(0);
                Map(p => p.Email).Index(1);
                Map(p => p.Phone).Index(2);
                Map(p => p.Address).Index(3);
                Map(p => p.UserType).Index(4);
                Map(p => p.Money).Index(5);
            }
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public void Save(User user)
        {
            _users.Add(user);
            SaveUsers();
        }

        private void LoadUsers()
        {
            using (var reader = new StreamReader(_path))
            using (var csv = new CsvReader(reader, _config))
            {
                csv.Context.RegisterClassMap<UserMap>();
                var records = csv.GetRecords<User>();
                _users = records.ToList();
            }
        }

        private void SaveUsers()
        {
            using (var writer = new StreamWriter(_path))
            using (var csv = new CsvWriter(writer, _config))
            {
                csv.Context.RegisterClassMap<UserMap>();
                csv.WriteRecords(_users);
            }
        }
    }
}
