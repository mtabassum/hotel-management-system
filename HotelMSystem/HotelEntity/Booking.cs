using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace HotelEntity
{
    public class Booking
    {
        public int id { get; set; }
        [Required]
        public int code { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [RegularExpression("^[0-9]{11}$",ErrorMessage = "Invalid mobile number !!!")]
        public string mobile { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string hotelname { get; set; }
        [Required]
        [RegularExpression("[1-9]*$", ErrorMessage = "Room must be greater than zero !!!")]
        public int totalrooms { get; set; }
        [Required]
        [RegularExpression("[1-9]*$", ErrorMessage = "Day must be greater than zero !!!")]
        public int totaldays { get; set; }
        [Required(ErrorMessage="Payment first !!!")]
        public float dueamount { get; set; }
        [Required]
        public string bookingdate { get; set; }
    }
}
