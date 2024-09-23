namespace api.Helpers
{
    public class ExceptionHelper
    {
        public static List<string> GetErrorMessages(Exception ex)
        {
            var errorMessages = new List<string>();
            var currentException = ex;

            while (currentException != null)
            {
                var message = $"Type: {currentException.GetType().Name}, Message: {currentException.Message}";
                var stackTrace = currentException.StackTrace != null ? $", StackTrace: {currentException.StackTrace}" : "";

                errorMessages.Add(message + stackTrace);

                currentException = currentException.InnerException;
            }

            return errorMessages;
        }
    }
}
