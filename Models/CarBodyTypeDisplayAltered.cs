using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentYouRide.Models
{
    [MetadataType(typeof(CarBodyTypeDisplayAltered))] // here we call upon the class we creating below the partial class, this class contians the changed data which is accpetd and altered in this line of code
    public partial class tbl_CarBodyType //the partial class is to link this class to the partial class created in the tbl_CarBodyType under models
    {
        public class CarBodyTypeDisplayAltered //this class is to hold the changed metadata of the labels 
        {
            //changing the display look of the labels
            [DisplayName("Description")]
            public string Description { get; set; }

        }

    }
}