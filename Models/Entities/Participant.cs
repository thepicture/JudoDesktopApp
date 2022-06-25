//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JudoDesktopApp.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Participant
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int GenderId { get; set; }
        public System.DateTime BirthDate { get; set; }
        public Nullable<int> SportsClubId { get; set; }
        public string PostCode { get; set; }
        public int HometownId { get; set; }
        public decimal WeightInPounds { get; set; }
        public int WeightCategoryId { get; set; }
        public int AgeCategoryId { get; set; }
    
        public virtual AgeCategory AgeCategory { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Hometown Hometown { get; set; }
        public virtual SportsClub SportsClub { get; set; }
        public virtual WeightCategory WeightCategory { get; set; }
    }
}
