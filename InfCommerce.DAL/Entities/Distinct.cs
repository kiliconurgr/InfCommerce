﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfCommerce.DAL.Entities
{
    [Table("Distinct")]
    public class Distinct
    {
        public int ID { get; set; }

        [Column(TypeName ="varchar(30)"),Display(Name = "İlçe Adı"),StringLength(30),Required(ErrorMessage ="İlçe Geçilemez...")]
        public string Name { get; set; }

        public int? CityID { get; set; }
        public City City { get; set; }
    }
}
