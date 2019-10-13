using Intravision.DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intravision.Models
{
    public class AdminViewModel
    {
        public List<Coin> Coins { get; set; } = new List<Coin>();
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
