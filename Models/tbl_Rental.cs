//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentYouRide.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Rental
    {
        public int ID_Rental { get; set; }
        public string CarNo { get; set; }
        public string Inspector { get; set; }
        public string Driver { get; set; }
        public decimal Rental_Fee { get; set; }
        public System.DateTime Start_Date { get; set; }
        public System.DateTime End_Date { get; set; }
    }
}