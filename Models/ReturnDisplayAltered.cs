using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentYouRide.Models
{
    [MetadataType(typeof(ReturnDisplayAltered))]
    public partial class tbl_Return
    {
        public class ReturnDisplayAltered
        {
            [DisplayName("Car No.")]
            public string CarNo { get; set; }

            [DisplayName("Inspector")]
            public string Inspector { get; set; }

            [DisplayName("Driver")]
            public string Driver { get; set; }

            [DisplayName("Return Date")]
            public System.DateTime Return_Date { get; set; }

            [DisplayName("Elapsed Date")]
            public int Elapsed_Date { get; set; }
                      
            [DisplayName("Fine")]
            public decimal Fine { get; set; }

        }
    }
}