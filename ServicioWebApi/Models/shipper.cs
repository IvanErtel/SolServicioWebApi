using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServicioWebApi.Models
{
    [Index(nameof(CompanyName), Name = "IX_Shippers", IsUnique = true)]

    public partial class Shipper
    {
        [Key]
        public int ShipperID { get; set; }
        [Required]
        [StringLength(40)]
        public string? CompanyName { get; set; }
        [StringLength(24)]
        public string? Phone { get; set; }
    }
}
