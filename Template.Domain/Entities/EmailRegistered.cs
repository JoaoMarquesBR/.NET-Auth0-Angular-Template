using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities
{
    public class EmailRegistered
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmailRegisteredId { get; set; }

        [Required]
        [ForeignKey("Account")]
        public int AccountId { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [MaxLength]
        public string MsgBody { get; set; }

        [Required]
        public DateTime SendDate { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime LastAltered { get; set; }
    }
}
