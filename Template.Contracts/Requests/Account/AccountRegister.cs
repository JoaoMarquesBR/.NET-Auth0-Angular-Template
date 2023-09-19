using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Contracts.Requests.Account
{
    public record AccountRegister(string username, string password, string firstName, string lastName, string email);

}
