using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThidasaAssignemnt.Models
{
    public class Sendchat
    {
        public string  Msg { get; set; }
        public string EmployeeId { get; set; }

   

        public List<SelectListItem> EmployeeList { get; set; }
        public List<ViewChatSent> ChatSent { get; set; }
        public List<ViewChatRecieved> ChatRecieved { get; set; }

    }
}