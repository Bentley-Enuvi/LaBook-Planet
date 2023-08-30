using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaBook_Planet.API.LibraryCore.API.DTOs
{
    public class ResponseObject<TData, TError>
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public bool Status { get; set; }
        public TError Errors { get; set; }
        public TData Data { get; set; }
    }
}
