﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.Common.Exceptions
{
    public class ValidatorException : Exception
    {
        public ValidatorException(string message):base(message) { }

    }
}
