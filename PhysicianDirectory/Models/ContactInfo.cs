using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhysicianDirectory.Models
{
    public class ContactInfo
    {
        public ulong Id { get; set; }
        [Required]
        public string HomeAddress { get; set; }
        [Required]
        public ulong HomePhone { get; set; }
        [Required]
        public string OfficeAddress { get; set; }
        [Required]
        public ulong OfficePhone { get; set; }
        [Required]
        public string EmailAdd { get; set; }
        [Required]
        public ulong CellphoneNumber { get; set; }
    }
}