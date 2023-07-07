using Membership.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Shared.Interfaces;
public interface IValidator<T>
{
     IEnumerable<MembershipError> Validate(T value);
     IEnumerable<MembershipError> ValidateProperty(T entity, string propertyName);
}
