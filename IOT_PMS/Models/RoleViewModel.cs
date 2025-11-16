using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IOT_PMS.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [DisplayName("نمط الحساب")]
        public string Name { get; set; }
    }
}