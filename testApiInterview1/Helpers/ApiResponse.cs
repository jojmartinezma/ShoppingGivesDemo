namespace testApiInterview1.Helpers
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }

        public ApiResponse()
        {
            StatusCode = 200;
        }
        
    }
}
