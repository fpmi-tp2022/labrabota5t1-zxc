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
    [Table("maclers")]
    public class macler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long maclerId { get; set; }

        [Required]
        public string name { get; set; }
        public string address { get; set; }
        public string birthday { get; set; }

        //[InverseProperty("macler")]
        //public List<good> goods { get; set; }
        //[InverseProperty("macler")]
        //public List<deal> deals { get; set; }
    }
}
