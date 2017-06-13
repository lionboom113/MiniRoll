using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities
{
    public class Roll
    {
        public Roll()
        {
            Result = new List<int>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Creater { get; set; }
        public DateTime RollTime { get; set; }
        public int RollRangeBoundaryBottom { get; set; }
        public int RollRangeBoundaryTop { get; set; }
        public List<int> Result { get; set; }
        public bool IsRolled { get; set; }
        public override bool Equals(object obj)
        {
            return ((Roll)obj).Id.Equals(this.Id);
        }
    }
}
