﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resenha.Util
{
    public class Enumerator
    {
        public enum StatusProcess
        {
            Error_Application = 0,
            Success = 1,
            Invalid_Credentials = 2
        }


        public enum OriginAccess
        {
            FACEBOOK = 1,
            APPLICATION = 2
        }
    }
}
