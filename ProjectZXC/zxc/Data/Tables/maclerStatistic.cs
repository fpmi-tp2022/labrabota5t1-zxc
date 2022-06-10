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
    [Table("maclerStatisticd")]
    public class maclerStatistic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long statisticsId { get; set; }

        [Required]
        public int maclerID { get; set; }
        public string maclerName { get; set; }
        public int amount { get; set; }
        public double sumprice { get; set; }
    }
}
