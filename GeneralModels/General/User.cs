using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GeneralModels.General
{
    public class User
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
