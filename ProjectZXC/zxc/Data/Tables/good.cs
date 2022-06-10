using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zxc.Data.Tables
{
    [Table("goods")]
    public class good
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long goodId { get; set; }

        [Required]
        public string name { get; set; }
        public string type { get; set; }
        public double price { get; set; }
        public string supplier { get; set; }
        public string storeDate { get; set; }
        public int amount { get; set; }
        public int maclerId { get; set; }
        public int dealId { get; set; }
        //[InverseProperty("goods")]
        //public macler macler { get; set; }
        //[InverseProperty("goods")]
        //public deal deal { get; set; }
    }
}
