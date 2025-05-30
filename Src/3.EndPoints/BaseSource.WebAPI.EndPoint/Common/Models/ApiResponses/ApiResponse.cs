namespace BaseSource.WebAPI.EndPoint.Common.Models.ApiResponses;

public class ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }

    // Optional: metadata for auth responses
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public string ReturnUrl { get; set; }

    public ApiResponse() { }

    public ApiResponse(bool isSuccess, string message = null, T data = default, int statusCode = 200)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
        StatusCode = statusCode;
    }
}

public class ApiResponse : ApiResponse<object>
{
    public ApiResponse() : base() { }

    public ApiResponse(bool isSuccess, string message = null, int statusCode = 200)
        : base(isSuccess, message, null, statusCode) { }
}


public static class ApiResponseFactory
{
    public static ApiResponse<T> Success<T>(T data, string message = "Success", int statusCode = 200)
        => new(true, message, data, statusCode);

    public static ApiResponse Success(string message = "Success")
        => new ApiResponse(true,message,statusCode:200);

    public static ApiResponse Success(string message = "Success", int statusCode = 200)
        => new(true, message, statusCode);

    public static ApiResponse<T> Fail<T>(string message = "Something went wrong", int statusCode = 400)
        => new(false, message, default, statusCode);

    public static ApiResponse Fail(string message = "Something went wrong", int statusCode = 400)
        => new(false, message, statusCode);
}
