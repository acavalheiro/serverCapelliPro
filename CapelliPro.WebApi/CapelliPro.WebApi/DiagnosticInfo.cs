using System;

namespace CapelliPro.WebApi
{
    public class DiagnosticInfo
    {
         public string UserId { get; set; } 
        public string Disease { get; set; }
        public string Solution { get; set; }
        public  DateTime Date { get; set; }
    }
}