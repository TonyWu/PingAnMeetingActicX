using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Cosmoser.PingAnMeetingRequest.Common.Model;
using Newtonsoft.Json;
using PingAnMeetingActiveX.Model;
using Cosmoser.PingAnMeetingRequest.Common.ClientService;

namespace PingAnMeetingActiveX
{
    [ComVisible(true)]   //允许进行COM注册
    [Guid("774EB7BE-CFAB-4870-870C-919893780F9E")] //标识在注册表中唯一的GUID码。
    [ClassInterface(ClassInterfaceType.AutoDual)]  //标识为某个类生成的类接口的类型。
    public partial class PingAnMeetingControl : UserControl
    {
        private SessionResponse session;
        private HandlerSession hSession;

        public PingAnMeetingControl()
        {
            InitializeComponent();
        }


        public string Login(string username, string password, string IP, string Port)
        {
            hSession = new HandlerSession();
            hSession.UserName = username;
            hSession.IP = IP;
            hSession.Port = Port;

            this.session = new SessionResponse();

            if (ClientServiceFactory.Create().Login(ref hSession))
            {
                this.session.Result = true;
                this.session.UserName = username;
                this.session.Token = hSession.Token;
            }
            else
            {
                this.session.Result = false;
                this.session.UserName = username;
                this.session.Error = "登录失败";
            }

            return JsonConvert.SerializeObject(this.session);
        }

        public string Test()
        {
            label1.Text = "测试成功";

            return "测试成功";
        }

        public string GetSession()
        {
            return JsonConvert.SerializeObject(session);
        }

        public string BookMeeting(string name, string startDateTime, string endDateTime, string roomAlias, string memo)
        {

            string error = string.Empty;
            
            BookMeetingResponse response = new BookMeetingResponse();

            try
            {
                //Get rooms

                DateTime startTime;
                DateTime endTime;
                if (DateTime.TryParse(startDateTime, out startTime) && DateTime.TryParse(endDateTime, out endTime))
                {
                    if (!string.IsNullOrEmpty(roomAlias))
                    {
                        List<MeetingRoom> roomList = this.GetMeetingRooms(roomAlias);
                        if (roomList.Count > 0)
                        {
                            SVCMMeetingDetail detail = new SVCMMeetingDetail()
                            {
                                Name = name,
                                StartTime = DateTime.Parse(startDateTime),
                                EndTime = DateTime.Parse(endDateTime),
                                Memo = memo,
                                ConfMideaType = MideaType.Video,
                                ConfType = ConferenceType.Furture,
                                VideoSet = VideoSet.Audio,
                                Phone = "123",
                                ParticipatorNumber = 3,
                                IPDesc = "123456"
                            };

                            //detail.MobileTermList.Add(new MobileTerm() { RoomId = "13485", RoomName = "dfs" });
                            //detail.MobileTermList.Add(new MobileTerm() { RoomId = "13705", RoomName = "dfs" });

                            foreach (var item in roomList)
                            {
                                detail.Rooms.Add(item);
                            }

                            if (ClientServiceFactory.Create().BookingMeeting(detail, hSession, out error))
                            {
                                response.Result = true;
                                response.MeetingId = detail.Id;
                            }
                            else
                            {
                                response.Result = false;
                                response.MeetingId = "0";
                                response.Error = error;
                            }
                        }
                        else
                        {
                            response.Result = false;
                            response.MeetingId = "0";
                            response.Error = string.Format("不能通过短号 {0} 找到会议室，请重试！", roomAlias);
                        }
                    }
                    else
                    {
                        response.Result = false;
                        response.MeetingId = "0";
                        response.Error = "短号不能为空";// string.Format("不能通过短号 {0} 找到会议室，请重试！", roomAlias);
                    }

                }
                else
                {
                    response.Result = false;
                    response.MeetingId = "0";
                    response.Error = "开始时间或结束时间日期格式不对。";
                }

            }
            catch (Exception ex)
            {
                response.Result = false;
                response.MeetingId = "0";
                response.Error = ex.StackTrace;
            }

            return JsonConvert.SerializeObject(response);
        }

        public string GetMeeting(int meetingId)
        {
            SVCMMeetingDetail meeting;

            if (ClientServiceFactory.Create().TryGetMeetingDetail(meetingId.ToString(), hSession, out meeting))
            {
                return JsonConvert.SerializeObject(new Model.PingAnMeetingResponse()
                {
                    Result = true,
                    Error = string.Empty,
                    Id = meetingId.ToString(),
                    Name = meeting.Name,
                    Status = meeting.Status,
                    StartTime = meeting.StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    EndTime = meeting.EndTime.ToString("yyyy-MM-dd HH:mm:ss")
                });
            }
            else
            {
                return JsonConvert.SerializeObject(new Model.PingAnMeetingResponse()
                {
                    Result = false,
                    Error = "获取会议详细信息失败！",
                    Id = "0",
                    Name = meeting.Name,
                    Status = "0",
                    StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                });
            }

            
        }

        public string EndMeeting(int meetingId)
        {
            string error;
            ResponseBase response = new ResponseBase();
            if (ClientServiceFactory.Create().EndMeeting(meetingId.ToString(), hSession, out error))
            {
                response.Result = true;
            }
            else
            {
                response.Result = false;
                response.Error = error;
            }
            return JsonConvert.SerializeObject(response);
        }

        public string DeleteMeeting(int meetingId)
        {
            string error;
            ResponseBase response = new ResponseBase();
            if (ClientServiceFactory.Create().DeleteMeeting(meetingId.ToString(), hSession, out error))
            {
                response.Result = true;
            }
            else
            {
                response.Result = false;
                response.Error = error;
            }
            return JsonConvert.SerializeObject(response);
        }

        public string AudioControl(int meetingId, string alias, string ip, bool isMute)
        {
            string error;
            ResponseBase response = new ResponseBase();
            if (ClientServiceFactory.Create().AudioControl(meetingId,  alias,  ip,  isMute, hSession, out error))
            {
                response.Result = true;
            }
            else
            {
                response.Result = false;
                response.Error = error;
            }
            return JsonConvert.SerializeObject(response);
        }

        public string VTXConfiguration(string IP, int Port, string serverIp, int serverPort, string sipname, string sippassword, int height, int width, int pos_x, int pos_y, string displayname)
        {
            string error;
            ResponseBase response = new ResponseBase();
            if (ClientServiceFactory.Create().VTXConfiguration(IP, Port, serverIp, serverPort, sipname, sippassword, height, width, pos_x, pos_y, displayname, out error))
            {
                response.Result = true;
            }
            else
            {
                response.Result = false;
                response.Error = error;
            }
            return JsonConvert.SerializeObject(response);
        }

        public string VTXInit(string IP, int Port, string logLevel)
        {
            string error;
            ResponseBase response = new ResponseBase();
            try
            {
                if (ClientServiceFactory.Create().VTXInit(IP, Port, logLevel, out error))
                {
                    response.Result = true;
                }
                else
                {
                    response.Result = false;
                    response.Error = error;
                }
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Error = ex.Message;
            }
            return JsonConvert.SerializeObject(response);
        }

        public string VTXChangeVol(string IP, int Port, bool plusAction)
        {
            string error;
            ResponseBase response = new ResponseBase();
            if (ClientServiceFactory.Create().VTXChangeVol(IP, Port, plusAction, out error))
            {
                response.Result = true;
            }
            else
            {
                response.Result = false;
                response.Error = error;
            }
            return JsonConvert.SerializeObject(response);
        }

        public List<MeetingRoom> GetMeetingRooms(string alias)
        {
            List<MeetingRoom> list = new List<MeetingRoom>();
            string error;
            foreach (var item in alias.Split(" ".ToCharArray()))
            {
                SearchRoomListQuery query = new SearchRoomListQuery();
                query.alias = item;
                query.roomType = "-1";
                query.pageSize = 10;
                query.pageNumber = 1;

                List<MeetingRoom> roomList;

                if (ClientServiceFactory.Create().TryGetSearchRoomList(query, hSession, out roomList, out error))
                {
                    list.AddRange(roomList);
                }
            }

            return list;
        }
    }
}
