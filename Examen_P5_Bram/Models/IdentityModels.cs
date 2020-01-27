using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Examen_P5_Bram.Translations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Examen_P5_Bram.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "A_FirstName", ResourceType = typeof(Texts))]
        public string FirstName { get; set; }
        [Display(Name = "A_LastName", ResourceType = typeof(Texts))]
        public string LastName { get; set; }
        [Display(Name = "A_Language", ResourceType = typeof(Texts))]
        public string LanguageId { get; set; }

        [Display(Name = "A_Language", ResourceType = typeof(Texts))]
        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; }
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

        //public ApplicationDbContext()
        //    : base("Name=Prog5Entities")
        //{
        //    Database.SetInitializer<Prog5Entities>(null);// Remove default initializer
        //    Configuration.ProxyCreationEnabled = false;
        //    Configuration.LazyLoadingEnabled = false;
        //}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}