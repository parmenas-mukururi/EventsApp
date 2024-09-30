using api.DTOs.Requests;
using api.DTOs.Responses;

namespace api.Interfaces
{
    public interface IEventService
    {
        Task<CreateEventResponseDTO> CreateEvent(CreateEventRequestDTO createEventRequestDTO);
    }
}
