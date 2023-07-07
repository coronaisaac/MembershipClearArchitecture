using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Abstractions.Entities
{
    public class ExternalUserEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderUserID { get; set; }

        public ExternalUserEntity(string email, string firstName, string lastName, string loginProvider, string providerUserID)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            LoginProvider = loginProvider;
            ProviderUserID = providerUserID;
        }

    }
}
