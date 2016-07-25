using System.Data.Entity;

namespace MerchEnrolServiceWebUI.Context
{
    public class MerchantContext : DbContext
    {
        public DbSet<Models.Merchant> Merchants { get; set; }

    }
}