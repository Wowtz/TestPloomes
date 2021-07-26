using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestPloomes.Model
{
    [Table("tblcat")]
    public partial class Tblcat
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string NomeGato { get; set; }
        [Required]
        [StringLength(50)]
        public string Raça { get; set; }
        [Required]
        [StringLength(50)]
        public string Cor { get; set; }
        public double Peso { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Nascimento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataVisita { get; set; }
    }
}
