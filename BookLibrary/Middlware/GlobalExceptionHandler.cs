using Newtonsoft.Json;

namespace BookLibrary.Middlware
{
    public class GlobalExceptionHandler
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
