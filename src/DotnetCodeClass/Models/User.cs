using System;

namespace DotnetCodeClass.Models
{
    public class User
    {
        public Guid Guid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
