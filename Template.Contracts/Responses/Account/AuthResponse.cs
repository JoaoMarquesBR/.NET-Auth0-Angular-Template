using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Contracts.Requests.Account
{
    public class AuthResponse
    {
        public int statusCode { get; set; }

        public string message { get; set; }

        public string token { get; set; }

        public AuthResponse(int statusCode, string message, string token)
        {
            this.statusCode = statusCode;
            this.message = message;
            this.token = token;
        }
    }
}
