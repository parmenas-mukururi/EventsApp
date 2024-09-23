namespace api.DTOs.Responses
{
    public class BaseResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = [];
    }
}
