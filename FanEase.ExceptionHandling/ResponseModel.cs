using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class ResponseModel<T>
    {
        public bool Succeed { get; set; } = true;
        public string error { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
