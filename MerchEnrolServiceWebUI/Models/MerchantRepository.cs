using MerchEnrolServiceWebUI.Context;
using MerchEnrolServiceWebUI.Enum;
using MerchEnrolServiceWebUI.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace MerchEnrolServiceWebUI.Models
{
    public class MerchantRepository : IMerchantRepository
    {

        public int AddMerchant(Merchant marchant)
        {

            using (MerchantContext db = new MerchantContext())
            {
                var lstDupMer = (from x in db.Merchants
                                 where x.MerchantName == marchant.MerchantName
                                 select x).ToList();

                if (lstDupMer.Count > 0)
                {
                    return lstDupMer.Count;
                }

                else
                {
                    db.Merchants.Add(marchant);
                    db.SaveChanges();
                }
            }
            return 0;
        }

        public void DeleteMerchant(Merchant marchant)
        {
            using (MerchantContext db = new MerchantContext())
            {

                db.Merchants.Remove(marchant);
                db.SaveChanges();

            }
        }

        public List<Merchant> GetAllMerchants(Merchant merchant)
        {
            using (MerchantContext db = new MerchantContext())
            {
                if (merchant.MerchantSearchBy.ToString() == SearchBy.Country.ToString())
                {
                    return (db.Merchants.Where(x => x.Country.StartsWith(merchant.TextSearch) || merchant.TextSearch == null)).ToList();

                }
                else
                {
                    return (db.Merchants.Where(x => x.MerchantName.StartsWith(merchant.TextSearch) || merchant.TextSearch == null)).ToList();
                }

            }
        }

        public Merchant GetMerchantById(int id)
        {
            using (MerchantContext db = new MerchantContext())
            {
                return db.Merchants.Find(id);
            }
        }

        public int UpdateMerchant(Merchant marchant)
        {

            using (MerchantContext db = new MerchantContext())
            {
                var lstDupMer = (from x in db.Merchants
                                 where x.MerchantName == marchant.MerchantName && x.Id != marchant.Id
                                 select x).ToList();

                if (lstDupMer.Count > 0)
                {
                    return lstDupMer.Count;
                }

                else
                {
                    db.Entry(marchant).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                }
            }
            return 0;
        }
    }
}