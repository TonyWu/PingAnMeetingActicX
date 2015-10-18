using System;
using System.Collections.Generic;

using System.Text;
using Cosmoser.PingAnMeetingRequest.Common.Model;

namespace Cosmoser.PingAnMeetingRequest.Common.Interfaces
{
    public interface IConferenceHandler
    {
        bool Login(ref HandlerSession session);
        bool EndMeeting(string conferId, HandlerSession session, out string error);
        bool BookingMeeting(SVCMMeetingDetail meetingDetail, HandlerSession session, out string error);
        bool DeleteMeeting(string conferId, HandlerSession session, out string error);
        bool UpdateMeeting(SVCMMeetingDetail meetingDetail, string operateType, HandlerSession session, out string error, out string errorCode);
        bool TryGetMeetingDetail(string meetingId, HandlerSession session, out SVCMMeetingDetail meetingDetail);
        bool TryGetMeetingList(MeetingListQuery query, HandlerSession session, out List<SVCMMeeting> meetingList);
        bool TryGetSeriesList(HandlerSession session, out List<MeetingSeries> seriesList);
        bool TryGetMeetingRoomList(MeetingRoomListQuery query, HandlerSession session, out List<MeetingRoom> roomList);
        bool TryGetSearchRoomList(SearchRoomListQuery query, HandlerSession session, out List<MeetingRoom> roomList, out string error);
        bool TryGetLeaderList(HandlerSession session, out List<MeetingLeader> leaderList);
        bool TryGetMobileTermList(HandlerSession session, DateTime from, DateTime to, out List<MobileTerm> mobileTermList);
        bool TryGetRegionCatagory(RegionCatagoryQuery query, HandlerSession session, out RegionCatagory regionCatagory);
        bool TryGetMeetingScheduler(MeetingSchedulerQuery query, HandlerSession session, out List<MeetingScheduler> schedulerList);
        bool AudioControl(int meetingId, string alias, string ip, bool isMute, HandlerSession session, out string error);
        bool VTXConfiguration(string IP, int Port, string serverIp, int serverPort, string sipname, string sippassword, int height, int width, int pos_x, int pos_y, string displayname, out string error);
        bool VTXInit(string IP, int Port, string logLevel, out string error);
        bool VTXChangeVol(string IP, int Port, bool plusAction, out string error);
    }
}
