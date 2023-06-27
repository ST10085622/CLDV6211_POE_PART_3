using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace RentYouRide.Models
{
    [MetadataType(typeof(RentalDisplayAltered))]
    public partial class tbl_Rental
    {
        public class RentalDisplayAltered
        {
            [DisplayName("Car No.")]
            public string CarNo { get; set; }

            [DisplayName("Inspector")]
            public string Inspector { get; set; }

            [DisplayName("Driver")]
            public string Driver { get; set; }

            [DisplayName("Rental Fee")]
            public decimal Rental_Fee { get; set; }

            [DisplayName("Start Date")]
            public System.DateTime Start_Date { get; set; }

            [DisplayName("End Date")]
            public System.DateTime End_Date { get; set; }


        }

    }
}