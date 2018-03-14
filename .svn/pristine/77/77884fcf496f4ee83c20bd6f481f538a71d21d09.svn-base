using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Model;
using Resenha.Util;
namespace Resenha.Model
{
    public class ReturnJson
    {

        public ReturnJson()
        {
            data = new List<object>();
            statusProcess = Enumerator.StatusProcess.Success;
        }
        [NotMapped]
        public Enumerator.StatusProcess statusProcess { get; set; }

        [NotMapped]
        public string message { get; set; }

        [NotMapped]
        public BodyToken bodyToken { get; set; }

        [NotMapped]
        public List<object> data { get; set; }

    }
}
