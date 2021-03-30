using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService.WebServices
{
    public class Response
    {
        public bool Success { get; set; }

        public int ResponseCode { get; set; }

        public String ErrororSuccessMessage { get; set; }

    }
}
