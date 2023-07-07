using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Abstractions.Entities
{
    public class ExternalUserCredentials
    {
        public string LoginProvider { get; }
        public string ProviderUser { get; }

        public ExternalUserCredentials(string loginProvider, string providerUser)
        {
            LoginProvider = loginProvider;
            ProviderUser = providerUser;
        }
    }
}
