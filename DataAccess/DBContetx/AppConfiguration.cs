using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBContetx
{
   public class AppConfiguration
    {
        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();

            configBuilder.AddJsonFile("appsettings.json", true, true);

            var root = configBuilder.Build();
            var appSetting = root.GetSection("ConnectionStrings:ConnectionBD");
            sqlConnectionString = appSetting.Value;
        }
        public string sqlConnectionString { get; set; }
    }
}
