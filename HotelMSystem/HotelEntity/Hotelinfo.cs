using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace HotelEntity
{
    public class Hotelinfo
    {
        public int id { get; set; }
        [Required]
        public string hotelName { get; set; }
        [Required]
        public int rating { get; set; }
        [Required]
        public string facilities { get; set; }
        [Required]
        [RegularExpression("[1-9][0-9]*$",ErrorMessage="Price must be more than zero !!!")]
        public float roomprice { get; set; }
        [Required]
        [RegularExpression("[0-9]*$",ErrorMessage="Room can not be negative !!!")]
        public int totalrooms { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string area { get; set; }
    }
}
