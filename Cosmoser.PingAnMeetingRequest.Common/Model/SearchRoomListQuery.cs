using System;
using System.Collections.Generic;

using System.Text;

namespace Cosmoser.PingAnMeetingRequest.Common.Model
{
    public class SearchRoomListQuery
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public string roomName { get; set; }
        public string alias { get; set; }
        /// <summary>
        /// 是否视频or本地会议室，-1：全部，1：视频，0：本地
        /// </summary>
        public string roomType { get; set; }
    }
}
