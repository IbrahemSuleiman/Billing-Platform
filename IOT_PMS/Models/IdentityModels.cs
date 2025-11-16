using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace IOT_PMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public object DB { get; internal set; }
        [DisplayName("نوع الحساب")]
        public string UserType { get; set; }
        [DisplayName("نوع الاشتراك")]
        public string RegistrationType { get; set; }
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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<IOT_PMS.Models.RoleViewModel> RoleViewModels { get; set; }

        public System.Data.Entity.DbSet<IOT_PMS.Models.E_Counter> E_Counter { get; set; }

        public System.Data.Entity.DbSet<IOT_PMS.Models.E_Bill> E_Bill { get; set; }

        public System.Data.Entity.DbSet<IOT_PMS.Models.P_Bill> P_Bill { get; set; }

        public System.Data.Entity.DbSet<IOT_PMS.Models.P_Counter> P_Counter { get; set; }
    }
}