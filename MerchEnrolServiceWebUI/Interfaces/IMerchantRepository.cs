using MerchEnrolServiceWebUI.Models;
using System.Collections.Generic;

namespace MerchEnrolServiceWebUI.Interfaces
{
  public interface IMerchantRepository
    {
        List<Merchant> GetAllMerchants(Merchant marchant);
        Merchant GetMerchantById(int id);
        int AddMerchant(Merchant marchant);
        int UpdateMerchant(Merchant marchant);
        void DeleteMerchant(Merchant marchat);
        
    }
}
