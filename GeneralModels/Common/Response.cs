using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralModels.Common
{
    public class Response
    {
        public bool status { get; set; }
        public string message { get; set; }
        public object res { get; set; }

        public Response(bool status, string message, object res)
        {
            this.status = status;
            this.message = message;
            this.res = res;
        }
    }
}
