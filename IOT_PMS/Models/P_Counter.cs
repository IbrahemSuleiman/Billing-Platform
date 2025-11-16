using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IOT_PMS.Models
{
    public class P_Counter
    {
        public int Id { get; set; }
        [DisplayName("الرقم المتصل به")]
        public string PhoneNumber { get; set; }
        [DisplayName("مدة الاتصال")]
        public string Duration { get; set; }
        public string UserId { get; set; }
    }
}