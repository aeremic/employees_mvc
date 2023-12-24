using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Options
{
    public class RcVaultOptionsSetup : IConfigureOptions<RcVaultOptions>
    {
        private const string SectionName = "ExternalServices:RcVault";
        private readonly IConfiguration _configuration;

        public RcVaultOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(RcVaultOptions options)
        {
            _configuration
                .GetSection(SectionName)
                .Bind(options);
        }
    }
}
