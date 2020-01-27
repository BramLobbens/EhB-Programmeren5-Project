using Examen_P5_Bram.Translations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Examen_P5_Bram
{
    public partial class Booking
    {
        public Booking()
        { }

        public Booking(BookingViewModel bvm)
        {
            Id = bvm.Id;
            FlightId = bvm.FlightId;
            UserId = bvm.UserId;
        }
    }

    public class BookingViewModel
    {
        public BookingViewModel()
        { }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "B_Flight", ResourceType = typeof(Texts))]
        [ForeignKey("FlightId")]
        public int FlightId { get; set; }
        [Display(Name = "B_User", ResourceType = typeof(Texts))]
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public BookingViewModel(Booking booking)
        {
            Id = booking.Id;
            FlightId = booking.FlightId;
            UserId = booking.UserId;

        }
    }
}