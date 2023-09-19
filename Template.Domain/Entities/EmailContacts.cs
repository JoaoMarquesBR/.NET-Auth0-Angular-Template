using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities
{
    public class EmailContacts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmailContactId { get; set; }

        [Required]
        [ForeignKey("Contact")]
        public int ContactId { get; set; }

        [Required]
        [ForeignKey("EmailRegistered")]
        public int EmailRegisteredId { get; set; }

    }
}
