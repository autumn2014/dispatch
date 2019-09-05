using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace efDemo.Models
{
    public class Mouse
    {
        public int MouseId { get; set; }
        [MaxLength(100)]
        public string MouseType { get; set; }
        public float Price { get; set; }
    }
}