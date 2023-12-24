using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Options
{
    public class RcVaultOptions
    {
        public string? ApiUrl { get; init; }
        public string? GetTimeEntriesEndpoint { get; init; }
        public string? GetTimeEntriesAuthorizationCode { get; init; }

    }
}
