using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace RentYouRide.Models
{
    [MetadataType(typeof(CarDisplayMetaData))] // here we call upon the class we creating in the partial class, this class contians the changed data which is accpetd and altered in this line of code
    public partial class tbl_Car //the partial class is to link this class to the partial class created in the tbl_Car under models
    {
        public class CarDisplayMetaData //this class is to hold the changed metadata of the labels 
        {
            //changing the display look of the labels 
            [DisplayName("Car No.")]
            public string CarNo { get; set; }

            [DisplayName("Car Make")]
            public string CarMake { get; set; }

            [DisplayName("Model")]
            public string Model { get; set; }

            [DisplayName("Body Type")]
            public string BodyType { get; set; }

            [DisplayName("Kilometers Travelled")]
            public int Kilometers_Travelled { get; set; }

            [DisplayName("Service Kilometers")]
            public int Service_Kilometers { get; set; }

            [DisplayName("Available")]
            public string Available { get; set; }

        }

    }
}