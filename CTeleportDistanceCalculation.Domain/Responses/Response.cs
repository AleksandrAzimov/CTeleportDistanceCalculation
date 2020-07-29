using CTeleportDistanceCalculation.Domain.Enums;

namespace CTeleportDistanceCalculation.Domain.Responses
{
    public class Response<T>
    {
        public T Data { get; set; }
        public Status ResponseStatus { get; set; }
        public string Message { get; set; }

        private Response()
        {
        }

        public static Response<T> Success(T data)
        {
            return new Response<T> { Data = data, ResponseStatus = Status.Success };
        }

        public static Response<T> Error(string message)
        {
            return new Response<T> { ResponseStatus = Status.Error, Message = message };
        }
    }
}