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
    [Table("deals")]
    public class deal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long dealId { get; set; }

        [Required]
        public string date { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int amount { get; set; }
        public string macler { get; set; }
        public string customer { get; set; }
        public int maclerId { get; set; }

        //[InverseProperty("deal")]
        //public List<good> goods { get; set; }
        //[InverseProperty("deals")]
        //public macler macler { get; set; }
    }
}
