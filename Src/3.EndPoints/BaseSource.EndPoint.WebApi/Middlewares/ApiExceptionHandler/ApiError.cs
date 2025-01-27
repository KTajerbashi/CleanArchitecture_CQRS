namespace BaseSource.EndPoint.WebApi.Middlewares.ApiExceptionHandler
{
    public class ApiError
    {
        public string Id { get; set; }
        public short Status { get; set; }
        public string Code { get; set; }
        public string Links { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string TraceId { get; set; }
    }
    public class ErrorDetails
    {
        public string Errors { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }
    }
}
