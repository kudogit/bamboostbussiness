using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Bamboo.Util
{
    public class ConfigSettings
    {
        private readonly IConfiguration _configuration;

        public ConfigSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string UploadFileUrl => _configuration.GetSection("Files")["upload"];
    }
}
