using System;
using System.Collections.Generic;

namespace MahalaxmiAPI.ModelView
{
    public class ResponseView<T>
    {
        public List<T> ResponseList { get; set; }
        public T ResponseObject { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
    }
}
