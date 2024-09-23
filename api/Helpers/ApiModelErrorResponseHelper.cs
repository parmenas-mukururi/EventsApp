using api.DTOs.Responses;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace api.Helpers
{
    public class ApiModelErrorResponseHelper
    {
        public static IActionResult CreateBadRequestResponse(ModelStateDictionary modelState)
        {
            var errors = modelState
                .Where(ms => ms.Value.Errors.Count > 0)
                .Select(ms => new
                {
                    Field = ms.Key,
                    Errors = ms.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                })
                .ToList();

            var combinedErrors = string.Join("; ", errors.SelectMany(e => e.Errors));

            var response = new BaseResponseDTO
            {
                Success = false,
                Message = combinedErrors,
                Errors = errors.SelectMany(e => e.Errors).ToList()
            };

            return new BadRequestObjectResult(response);
        }
    }
}
