using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThidasaAssignemnt.DbContext;
namespace ThidasaAssignemnt.Models
{
    public class FeedBack
    {
        public string EmployeeId { get; set; }

        public string Comment { get; set; }

        public List<SelectListItem> EmployeeList { get; set; }
    }
}