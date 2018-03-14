using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Model
{
    public class TokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Hours { get; set; }
    }


    [NotMapped]
    public class BodyToken
    {
        public string token { get; set; }
        public DateTime dtStartToken { get; set; }
        public DateTime dtExpirationToken { get; set; }
    }
}
