using System.ComponentModel.DataAnnotations;

namespace WebGYM.Models.Model
{
    public class AmountRequestModel
    {
        [Required(ErrorMessage = "Plan is Required")]
        public int PlanId { get; set; }
        [Required(ErrorMessage = "Scheme is Required")]
        public int SchemeId { get; set; }
    }
}
