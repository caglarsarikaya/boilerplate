using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lightweight.webapi.DTOs
{
    public class UserDto
    {

        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string FullName { get; set; }
   
        public bool Status { get; set; }
        public string Role { get; set; }

    }
}
