using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Session
    {
        int id { get; set; }
        bool active { get; set; } = true;
        string session_code { get; set; }
    }
}
