namespace Maylzam_App_.Result
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        
        public Result(bool success, string msg = "", T data = default)
        {
            Success = success;
            Message = msg;
            Data = data;
        }
        public static Result<T> Fail(string msg = "")
        {
            return new Result<T>(false, msg: msg);
        }

        public static Result<T> Sucess(T data, string msg = "successful")
        {
            return new Result<T>(true, data: data, msg: msg);
        }
    }
}
