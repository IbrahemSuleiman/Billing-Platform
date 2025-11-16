using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IOT_PMS.Models
{
    public class E_Bill
    {
        public int Id { get; set; }
        [DisplayName("رقم الفاتورة")]
        public string Number { get; set; }
        [DisplayName("تاريخ الإصدار")]
        public string DateofAnnounce { get; set; }
        [DisplayName("قيمة الفاتورة")]
        public string Price { get; set; }
        [DisplayName("ملاحظات")]
        public string Notes { get; set; }
        public string UserId { get; set; }
        public string CounterId { get; set; }
    }
}