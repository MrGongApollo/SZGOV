using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using LayUI.Win.BasicChat;
using System.Threading.Tasks;
using LayUI.Data.EntityModel;
using LayUI.Data;
using LayUI.Win.Help;
using System.Threading;

namespace LayUI.Win
{
    
    public class ChatHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections=new ConnectionMapping<string>();

        /// <summary>
        /// 在线用户
        /// </summary>
        static List<OnlineUserInfo> UserList = new List<OnlineUserInfo>();

        /// <summary>
        /// 群组id
        /// </summary>
        private string _groupId { get { return Context.QueryString["groupId"].ToString(); } }

        /// <summary>
        /// 头像地址
        /// </summary>
        private string _avatar { get { return Context.QueryString["avatar"].ToString(); } }

        /// <summary>
        /// 当前用户信息
        /// </summary>
        T_XT_User_Entity c_User
        {
            get
            {
                return new CommonHelper().getUserByEmpCode(Context.QueryString["EmpCode"].ToString());
            }
        }


        #region 用户连接、重连、断开 对话

        #region 连接
        public override Task OnConnected()
        {
            JoinRoom();
            return base.OnConnected();
        }
        #endregion

        #region 断开
        public override Task OnDisconnected(bool stopCalled)
        {
            LeaveRoom();//离开房间
            return base.OnDisconnected(stopCalled);
        }
        #endregion

        #region 重连
        public override Task OnReconnected()
        {
            JoinRoom(false);
            return base.OnReconnected();
        }
        #endregion

        #endregion

        #region 用户具体操作

        #region 加入房间
        /// <summary>
        /// 加入房间
        /// </summary>
        public void JoinRoom(bool isFist=true)
        {
            T_XT_User_Entity C_user = c_User;
            if (C_user != null)
            {
                UserList.Where(k => k.EmpCode == C_user.EmpCode&&k.GroupId==_groupId&&k.ConnectionId!=Context.ConnectionId).Select(p=>p.ConnectionId).ToList().ForEach(k=>{
                    Groups.Remove(k, _groupId);
                });
                
                if (!UserList.Any(k => k.ConnectionId == Context.ConnectionId))
                {
                    UserList.Add(new OnlineUserInfo
                    {
                        ConnectionId = Context.ConnectionId,
                        EmpCode = C_user.EmpCode,
                        EmpName = C_user.EmpName,
                        GroupId = _groupId,
                        Avatar = _avatar
                    });
                    Groups.Add(Context.ConnectionId, _groupId);//加入房间
                }

                Clients.Group(_groupId).receiveNotice(C_user.EmpName, isFist ? "加入了房间." : "重新连接.");
            }
        }
        #endregion

        #region 离开房间
        private void LeaveRoom()
        {
            var _user = UserList.Where(p => p.ConnectionId == Context.ConnectionId).FirstOrDefault();
            if (_user != null)
            {
                string _empname = _user.EmpName;
                UserList.Remove(_user);
                Clients.Group(_groupId).receiveNotice(_empname, "离开了房间.");
            }
        }
        #endregion

        #region 组播消息
        public void SendGroupMsg(string message)
        {
            T_XT_User_Entity C_user = c_User;
            if (C_user != null)
            {
                Clients.Group(_groupId).receiveMsg(C_user.EmpName, _avatar, message);
            }
        }
        #endregion

        #endregion


    }
}