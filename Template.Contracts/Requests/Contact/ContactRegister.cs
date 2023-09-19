using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Contracts.Requests.Contact
{
    public record ContactRegister(string FirstName, string LastName, int accountId, string emailAddress);

}
