namespace BeApi.ViewModels
{
    public enum ResponseStatusCode
    {
        NotFound = 404,
        MissingParameter = 400,
        DataProcessingError = 500,
        Success = 200,
        Unauthorized = 401,
        Forbidden = 403,
        BadRequest = 400,
        InternalServerError = 500,
        
    }

    public static class ResponseStatusCodeExtensions
    {
        public static string GetMessage(this ResponseStatusCode statusCode)
        {
            return statusCode switch
            {
                ResponseStatusCode.NotFound => "Resource not found",
                ResponseStatusCode.MissingParameter => "Missing parameter",
                ResponseStatusCode.DataProcessingError => "Data processing error",
                ResponseStatusCode.Success => "Success",
                ResponseStatusCode.Unauthorized => "Unauthorized access",
                ResponseStatusCode.Forbidden => "Forbidden access",
                _ => "Unknown status code"
            };
        }
    }
}