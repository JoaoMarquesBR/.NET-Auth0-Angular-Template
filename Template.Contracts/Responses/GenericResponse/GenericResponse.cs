using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Contracts.Responses.GenericResponse
{
    public class GenericResponse
    {

        public int Status { get; set; }

        public string Message { get; set; }

        public GenericResponse(int status, string message)
        {
            this.Status = status;
            this.Message = message;
        }

    }
}
