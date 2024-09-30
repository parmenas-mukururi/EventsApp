using api.Database;
using api.Database.Entities;
using api.DTOs.Requests;
using api.DTOs.Responses;
using api.Helpers;
using api.Interfaces;

namespace api.Services
{
    public class EventService : IEventService
    {
        private readonly AppDbContext _context;
        public EventService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CreateEventResponseDTO> CreateEvent(CreateEventRequestDTO createEventRequestDTO)
        {
            try
            {
                EventEntity newEvent = new EventEntity()
                {
                    Title = createEventRequestDTO.Title,
                    Description = createEventRequestDTO.Description,
                    Venue = createEventRequestDTO.Venue,
                    Time = createEventRequestDTO.Time,
                    Date = createEventRequestDTO.Date,
                    Price = createEventRequestDTO.Price,

                };
                _context.Events.Add(newEvent);
                await _context.SaveChangesAsync();

                return new CreateEventResponseDTO()
                {
                    Success = true,
                    Message = "Event created successfully"
                };
            }
            catch (Exception ex)
            {

                List<string> errorMessages = ExceptionHelper.GetErrorMessages(ex);

                return new CreateEventResponseDTO()
                {
                    Errors = errorMessages,
                    Message = "Event creation failed. Please try again later",
                    Success = false
                };
            }
        }
    }
}
