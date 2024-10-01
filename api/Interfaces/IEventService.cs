using api.Database.Entities;
using api.DTOs.Requests;
using api.DTOs.Responses;

namespace api.Interfaces
{
    public interface IEventService
    {
        Task<CreateEventResponseDTO> CreateEvent(CreateEventRequestDTO createEventRequestDTO);
        Task<EditEventResponseDTO> EditEvent(EditEventRequestDTO editEventRequestDTO);
        Task<EventEntity> GetEventById(Guid id);
    }
}
