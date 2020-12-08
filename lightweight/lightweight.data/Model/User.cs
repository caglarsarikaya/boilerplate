using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lightweight.data.Model
{
    public class User
    {
        public User()
        {
            Duty = new Collection<Duty>();
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }

        public ICollection<Duty> Duty { get; set; }
    }
}