namespace DiiL.Sdk.BestSignSdk.Model
{
    public class BaseDTO<T> where T : class
    {
        public string errno { get; set; }
        public T data { get; set; }
        public string errmsg { get; set; }

    }
}
