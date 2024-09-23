namespace api.DTOs.Responses
{
    public class LoginResponseDTO : BaseResponseDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
