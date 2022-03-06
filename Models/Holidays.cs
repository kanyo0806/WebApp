using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Holidays
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public  DateTime Date { get; set; }
        public string Type { get; set; }
    }
}