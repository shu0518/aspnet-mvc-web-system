using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using ZooParkWeb.Models;

namespace ZooParkWeb.ViewModels
{
    public class GuestbooksViewModel
    {
        //顯示資料陣列
        public List<Guestbooks> DataList { get; set; }
    }
}