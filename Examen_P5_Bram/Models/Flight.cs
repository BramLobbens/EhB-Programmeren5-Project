using Examen_P5_Bram.Translations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Examen_P5_Bram
{
    public partial class Flight
    {
        public Flight(FlightViewModel fvm)
        {
            Id = fvm.Id;
            AirplaneId = fvm.AirplaneId;
            From = fvm.From;
            To = fvm.To;
        }
    }

    public class FlightViewModel
    {
        public FlightViewModel()
        { }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "F_Airplane", ResourceType = typeof(Texts))]
        [ForeignKey("AirplaneId")]
        public int AirplaneId { get; set; }
        [Display(Name = "F_AirportFrom", ResourceType = typeof(Texts))]
        [ForeignKey("FromId")]
        public int From { get; set; }
        [Display(Name = "F_AirportTo", ResourceType = typeof(Texts))]
        [ForeignKey("ToId")]
        public int To { get; set; }
        public FlightViewModel(Flight flight)
        {
            Id = flight.Id;
            AirplaneId = flight.AirplaneId;
            From = flight.From;
            To = flight.To;
        }
    }
}