using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GFClaim.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
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
        // 这里给出所有要PM>add-migration时要创建的表的dbset
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<RevCode> RevCodes { get; set; }
        public DbSet<ProviderType> ProviderTypes { get; set; }

        public ApplicationDbContext()
            : base("MyConnection", throwIfV1Schema: false)  //"MyConnection"必须和Web.config的connectionString.Name相同
                                                            // 把它指向另一个connectionString可以切换数据库
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}