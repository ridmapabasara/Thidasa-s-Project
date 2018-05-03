using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThidasaAssignemnt.DbContext;

namespace ThidasaAssignemnt.Models
{
    public class ViewEmployeeDetails
    {
        public string  Name{ get; set; }
        public List<string> Skills { get; set; }
        public List<string> Comments { get; set; }

        public List<QualificationsOfEmployee> Qualifications { get; set; }
    }
}