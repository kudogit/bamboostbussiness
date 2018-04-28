using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Core.Constants;

namespace Bamboo.Util.Exceptions
{
    public class ErrorModel
    {
        public ErrorCode Code { get; set; }

        public string Message { get; set; }

        public ErrorModel()
        {
        }

        public ErrorModel(ErrorCode code, string message)
        {
            Code = code;
            Message = message ?? code.GetDisplayName();
        }
    }
}
