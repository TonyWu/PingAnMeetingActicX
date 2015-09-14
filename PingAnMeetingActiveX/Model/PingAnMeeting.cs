using System;
using System.Collections.Generic;
using System.Text;
using Cosmoser.PingAnMeetingRequest.Common.Model;

namespace PingAnMeetingActiveX.Model
{
    public class PingAnMeetingResponse:ResponseBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public string Password { get; set; }
        public string Memo { get; set; }
        public string MainRoom { get; set; }
       
        /// <summary>
        /// 会议状态 0：正在申请；1：预定成功；2：MCU正在处理中；3：正在进行；4：会议结束；6：待审批；7：会议被删除，详情显示
        /// </summary>
        public string Status { get; set; }

        public string StatusStr
        {
            get
            {
                switch (int.Parse(this.Status))
                {
                    case 0:
                        return "正在申请";
                    case 1:
                        return "预定成功";
                    case 2:
                        return "MCU正在处理";
                    case 3:
                        return "正在召开";
                    case 4:
                        return "会议结束";
                    case 6:
                        return "待审批";
                    case 7:
                        return "会议删除";
                    default:
                        return "未知";
                }
            }
        }

        public ConferenceType ConfType { get; set; }
        public MideaType ConfMideaType { get; set; }
        public string Rooms { get; set; }

    }
}
