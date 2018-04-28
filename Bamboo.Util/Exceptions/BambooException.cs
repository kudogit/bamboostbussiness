using Bamboo.Core.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Util.Exceptions
{
    public class BambooException : Exception
    {
        public BambooException(ErrorCode code) : base(code.GetDisplayName())
        {
            Code = code;
        }

        public BambooException(ErrorCode code, string message) : base(message)
        {
            Code = code;
        }

        public ErrorCode Code { get; set; }

    }
}
