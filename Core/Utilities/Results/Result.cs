using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message): this(success)
        {
            //getter can be set in ctor
           Message = message;
        }

        public Result(bool success)
        {
            //getter can be set in ctor
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
