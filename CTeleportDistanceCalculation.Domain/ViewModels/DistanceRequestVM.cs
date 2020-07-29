using System.ComponentModel.DataAnnotations;

namespace CTeleportDistanceCalculation.Domain.ViewModels
{
    public class DistanceRequestVM
    {
        [MaxLength(3, ErrorMessage = "Maximum number of characters that can be entered is 3!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string IataCodeFrom { get; set; }

        [MaxLength(3, ErrorMessage = "Maximum number of characters that can be entered is 3!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string IataCodeTo { get; set; }
    }
}