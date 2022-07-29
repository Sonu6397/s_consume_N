using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace s_consume_N.Models
{
    public class Empmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public Nullable<decimal> Salary { get; set; }
    }
}