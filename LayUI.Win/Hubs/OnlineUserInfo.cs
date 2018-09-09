using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LayUI.Win
{
    public class OnlineUserInfo
    {
        //用户连接ID(唯一标识)
        public string ConnectionId { get; set; }
        //工号
        public string EmpCode { get; set; }
        //姓名
        public string EmpName { get; set; }

        //组播ID
        public string GroupId { get; set; }
        //用户头像
        public string Avatar { get; set; }

        ////用户状态
        //public string UserStates { get; set; }
    }
}