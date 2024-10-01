using api.DTOs.Requests;
using api.Helpers;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [HttpPost("createEvent")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateEvent(CreateEventRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return ApiModelErrorResponseHelper.CreateBadRequestResponse(ModelState);
            }
            var results = await _eventService.CreateEvent(request);
            if (results.Success)
            {
                return Created("", results);
            }
            return BadRequest(results);
        }

        [HttpPut("editEvent")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditEvent(EditEventRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return ApiModelErrorResponseHelper.CreateBadRequestResponse(ModelState);
            }
            var results = await _eventService.EditEvent(request);
            if (results.Success)
            {
                return Ok(results);
            }
            return BadRequest(results);
        }
    }
}
