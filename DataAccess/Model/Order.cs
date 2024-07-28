using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string IdentityUserId { get; set; }
        public DateTime OrderDate  { get; set; }
        public decimal TotalAmount { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
