using MerchEnrolServiceWebUI.Enum;
using System.ComponentModel.DataAnnotations;


namespace MerchEnrolServiceWebUI.Models
{
    public class Merchant
    {


        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter merchant Name", AllowEmptyStrings = false)]
        public string MerchantName { get; set; }
        [Required(ErrorMessage = "Please enter added By", AllowEmptyStrings = false)]
        public string AddedBy { get; set; }
        [Required(ErrorMessage = "Please enter country", AllowEmptyStrings = false)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter merchant profit", AllowEmptyStrings = false)]
        public int MerchantProfit { get; set; }

        [Required(ErrorMessage = "Please enter date added in (mm/dd/yyyy)")]
        public string DateAdded { get; set; }

        [Required(ErrorMessage = "Please enter number of outlets", AllowEmptyStrings = false)]
        [Range(10, 500000, ErrorMessage = "Minimum no of outlets allowed is 10")]
        public int NoOfOutlets { get; set; }

        public string TextSearch { get; set; }

        public SearchBy MerchantSearchBy { get; set; }

    }
}