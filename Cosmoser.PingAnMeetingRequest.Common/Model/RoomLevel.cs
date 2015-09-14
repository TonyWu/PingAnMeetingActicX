using System;
using System.Collections.Generic;

using System.Text;

namespace Cosmoser.PingAnMeetingRequest.Common.Model
{
    public class RoomLevel
    {
        public string LevelName { get; set; }
        public string LevelId { get; set; }

        public override string ToString()
        {
            return this.LevelName;
        }
    }
}
