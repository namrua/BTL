using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL.Areas.Common
{
    [Serializable]
    public class UserLogin
    {

        public long UserID { set; get; }
        public String UserName { set; get; }
    }
}