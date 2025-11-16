using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IOT_PMS.Models
{
    public class User
    {
        [DisplayName("الاسم")]
        public string FirstName { get; set; }
        [DisplayName("الكنية")]
        public string LastName { get; set; }
        [DisplayName("اسم الأب")]
        public string MiddleName { get; set; }  
        [DisplayName("العنوان")]
        public string Address { get; set; }
        [DisplayName("رقم الجوال")]
        public string Mobile { get; set; }
        [DisplayName("الرقم الوطني")]
        public string NationalId { get; set; }
    }
}