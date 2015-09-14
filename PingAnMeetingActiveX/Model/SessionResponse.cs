using System;
using System.Collections.Generic;
using System.Text;

namespace PingAnMeetingActiveX.Model
{
    public class SessionResponse:ResponseBase
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
    }
}
