using System;
using System.Collections.Generic;
using System.Text;

namespace CBApi.Database.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string FullName { get; set; }

    }
}
