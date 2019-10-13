using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intravision.DataAccess.Dto
{
    public class Coin
    {
        [Key]
        public int Id { get; set; }
        public int ParValue { get; set; }
        public bool IsAvailable { get; set; }
    }
}
