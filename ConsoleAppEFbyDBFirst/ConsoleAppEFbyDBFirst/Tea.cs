//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleAppEFbyDBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tea
    {
        public int Id { get; set; }
        public string NameSort { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> TypeTeaId { get; set; }
        public string DescriptionInfo { get; set; }
        public decimal NumberGrams { get; set; }
        public decimal Price { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual TypesTea TypesTea { get; set; }
    }
}
