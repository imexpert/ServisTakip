namespace ServisTakip.Core.Utilities.Results
{
    public class ResponseMessage<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

        //Static Factory Method
        public static ResponseMessage<T> Success(T data)
        {
            return new ResponseMessage<T> { Data = data, StatusCode = 200, IsSuccess = true };
        }

        //Static Factory Method
        public static ResponseMessage<T> Success(string message)
        {
            return new ResponseMessage<T> { Message = message, StatusCode = 200, IsSuccess = true };
        }

        public static ResponseMessage<T> Success(T data, string message)
        {
            return new ResponseMessage<T> { Data = data, Message = message, StatusCode = 200, IsSuccess = true };
        }

        public static ResponseMessage<T> Success()
        {
            return new ResponseMessage<T> { StatusCode = 200, IsSuccess = true };
        }

        public static ResponseMessage<T> Fail(string message)
        {
            return new ResponseMessage<T>
            {
                StatusCode = 500,
                IsSuccess = false,
                Message = message
            };
        }

        public static ResponseMessage<T> Fail(int statusCode, string message)
        {
            return new ResponseMessage<T>
            {
                StatusCode = statusCode,
                IsSuccess = false,
                Message = message
            };
        }

        public static ResponseMessage<T> NoDataFound(string message)
        {
            return new ResponseMessage<T>
            {
                StatusCode = 404,
                IsSuccess = false,
                Message = message
            };
        }
    }
}
