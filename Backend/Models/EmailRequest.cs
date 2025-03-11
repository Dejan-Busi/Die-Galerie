using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class EmailRequest
    {
        public string? Anrede { get; set; }
        public string? VorName { get; set; }
        public string? NachName { get; set; }
        public string? AbsenderEmail { get; set; }
        public string? Nachricht { get; set; }
    }

}

