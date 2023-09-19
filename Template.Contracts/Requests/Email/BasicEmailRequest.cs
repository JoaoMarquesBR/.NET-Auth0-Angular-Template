using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Contracts.Requests.Email;

public record BasicEmailRequest(string email, string msgBody);
