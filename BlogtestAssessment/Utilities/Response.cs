namespace BlogtestAssessment.Utilities
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public bool Succeeded { get; set; } 
        public string? Message { get; set; }

        public Response(bool success, string msg, T data)
        {
            Succeeded = success;
            Message = msg;
            Data = data;
        }

        public Response()
        {
        }

        public static Response<T> Fail(string message)
        {
            return new Response<T> { Succeeded = false, Message = message };
        }

        public static Response<T> Success(string message, T data)
        {
            return new Response<T> { Succeeded = true, Message = message, Data = data };
        }
    }
}
