
namespace FanEase.UI.Models
{
    public class ResponseModel<T>
    {
        public bool Succeed { get; set; } = true;
        public string error { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
