
namespace E_Invoice_API.Core.DTO.Request
{
    public class ChangePasswordRequest
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirmation { get; set; }
    }
}
