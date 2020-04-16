using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meister.SDK.Identity.NetCore.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Secret { get; set; }
        public List<User> Users { get; set; }
        public List<MeisterConnection> Connections { get; set; }
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public long ConnectionId { get; set; }
        [ForeignKey("ConnectionId")]
        public MeisterConnection Connection { get; set; }
    }
}
