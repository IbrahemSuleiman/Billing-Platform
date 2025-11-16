using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IOT_PMS.Models
{
    public class E_Counter
    {
        public int Id { get; set; }
        [DisplayName("رقم العداد")]
        public string SerialNumber { get; set; }
        [DisplayName("نوع العداد")]
        public string RegistrationType { get; set; }
        [DisplayName("قيمة القراءة")]
        public string CounterValue { get; set; }
        [DisplayName("تاريخ الاشتراك")]
        public string RegistrationDate { get; set; }
        public string UserId { get; set; }
    }
}