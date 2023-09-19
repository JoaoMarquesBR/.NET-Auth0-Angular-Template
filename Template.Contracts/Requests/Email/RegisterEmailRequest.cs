using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Contracts.Requests.Email;

public record RegisterEmailRequest(int accountId,List<int>contactsId,string email, string msgBody,string title,DateTime sendDate);
