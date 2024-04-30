using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task_tracker_api_backend.Models
{
    public class UserModel
    {
        public int ID { get; set; }

        public string? Username { get; set; }
        public string? Salt { get; set; }
        public string? Hash { get; set; }

        public UserModel()
        {

        }
    }
}