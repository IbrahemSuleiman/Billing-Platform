using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IOT_PMS.Models
{
    public class W_Bill
    {
        public string Id { get; set; }
        [DisplayName("رقم الفاتورة")]
        public string Number { get; set; }
        [DisplayName("تاريخ الإصدار")]
        public string DateofAnnounce { get; set; }
        [DisplayName("قيمة الفاتورة")]
        public string Price { get; set; }
        [DisplayName("ملاحظات")]
        public string Notes { get; set; }

        public string UserId { get; set; }
        public virtual User user { get; set; }
        public string CounterId { get; set; }
        public virtual E_Counter e_counter { get; set; }

    }
}