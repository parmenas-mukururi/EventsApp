using api.Database;
using api.Database.Entities;
using api.DTOs.Requests;
using api.DTOs.Responses;
using api.Helpers;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<EditEventResponseDTO> EditEvent(EditEventRequestDTO editEventRequestDTO)
        {
            try
            {
                var eventEntity = await this.GetEventById(editEventRequestDTO.EventId);

                if (eventEntity == null)
                {
                    return new EditEventResponseDTO()
                    {
                        Success = false,
                        Message = "Event not found",
                    };
                }

                eventEntity.Title = editEventRequestDTO.Title;
                eventEntity.Description = editEventRequestDTO.Description;
                eventEntity.Date = editEventRequestDTO.Date;
                eventEntity.Price = editEventRequestDTO.Price;
                eventEntity.Time = editEventRequestDTO.Time;
                eventEntity.Venue = editEventRequestDTO.Venue;

                _context.Events.Update(eventEntity);
                await _context.SaveChangesAsync();

                return new EditEventResponseDTO()
                {
                    Success = true,
                    Message = "Event updated successfully"
                };
            }
            catch (Exception ex)
            {
                List<string> errorMessages = ExceptionHelper.GetErrorMessages(ex);

                return new EditEventResponseDTO()
                {
                    Errors = errorMessages,
                    Message = "Event failed to edit. Please try again later",
                    Success = false
                };
            }
        }

        public async Task<EventEntity> GetEventById(Guid id)
        {
            return await _context.Events.FirstOrDefaultAsync(e => e.EventId == id);
        }

    }
}

