namespace ServisTakip.Core.Utilities.Results
{
    public class PagedResult<T> : PagedResultBase
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static PagedResult<T> Success(T data)
        {
            return new PagedResult<T> { Data = data,  IsSuccess = true };
        }

        //Static Factory Method
        public static PagedResult<T> Success(string message)
        {
            return new PagedResult<T> { Message = message,  IsSuccess = true };
        }

        public static PagedResult<T> Success(T data, string message)
        {
            return new PagedResult<T> { Data = data, Message = message,  IsSuccess = true };
        }

        public static PagedResult<T> Success()
        {
            return new PagedResult<T> {  IsSuccess = true };
        }

        public static PagedResult<T> Fail(string message)
        {
            return new PagedResult<T>
            {
                
                IsSuccess = false,
                Message = message
            };
        }
    }
}
