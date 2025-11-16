using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IOT_PMS.Models
{
    public class W_Counter
    {
        public string Id { get; set; }
        [DisplayName("رقم العداد")]
        public string SerialNumber { get; set; }
        [DisplayName("نوع العداد")]
        public string CounterType { get; set; }
        [DisplayName("قيمة العداد")]
        public string CounterValue { get; set; }
        [DisplayName("تاريخ الاشتراك")]
        public string RegistrationDate { get; set; }
        public string UserId { get; set; }
        public virtual User user { get; set; }
    }
}