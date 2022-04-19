using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfCommerce.DAL.Entities
{
    //ORM:
    [Table("Category")]
    public class Category
    {
        public int ID { get; set; }//id Id ID

        //[Key]
        //public string TCKN { get; set; }

        [Column(TypeName ="varchar(30)"),Display(Name ="Kategori Adı"),StringLength(30),Required(ErrorMessage ="Kategori Boş Geçilemez...")]
        public string Name { get; set; }
    }
}
