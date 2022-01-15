using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonsDb
{
    public partial class Person
    {
        public long Id { get; set; }
     
        [Required]
        [RegularExpression(@"^[A-Z]\w+")]
        public string? Firstname { get; set; }

        
        [Required]
        [RegularExpression(@"\w+")]
        public string? Lastname { get; set; }
        
        [Required]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}$")]
        public string Born { get; set; } = null!;
        
        [Required]
        [RegularExpression(@"^\+\d{2}\s\(\d{2}\)\s\d{4,6}$")]
        public string? Tel { get; set; }
        public long AdressId { get; set; }

        public virtual Adress Adress { get; set; } = null!;

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Firstname)}: {Firstname}, {nameof(Lastname)}: {Lastname}, {nameof(Born)}: {Born}, {nameof(Tel)}: {Tel}, {nameof(AdressId)}: {AdressId}, {nameof(Adress)}: {Adress}";
        }
    }
}
