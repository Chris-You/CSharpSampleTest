using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebAPISampleNet5
{
    public class EmployeeModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }

    public class EmployeeModelDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
