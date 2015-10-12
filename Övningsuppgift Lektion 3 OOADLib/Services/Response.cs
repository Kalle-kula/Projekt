using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    public class Response<T>
    {
        public T Entity { get; set; }

        public List<T> EntityList { get; set; }

        public ErrorCode Error { get; set; }

        public bool Success { get { return Error == ErrorCode.None; } }
    }


    public enum ErrorCode
    {
        None,
        InvalidState,
        DuplicateEntity,
        InvalidLogin
    }
}
