//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrnekProje.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Answer
    {
        public System.Guid Id { get; set; }
        public System.Guid QuestionId { get; set; }
        public string Name { get; set; }
        public int IsTrue { get; set; }
    
        public virtual Question Question { get; set; }
    }
}
