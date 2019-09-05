using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace efDemo.Models
{
    public class Keyboard
    {
        public int ID { get; set; }
        [MaxLength(100,ErrorMessage ="长度为100以内")]
        public string Name { get; set; }
        [Range(0,100,ErrorMessage ="范围在0到100之间")]
        public decimal Price { get; set; }
    }
}