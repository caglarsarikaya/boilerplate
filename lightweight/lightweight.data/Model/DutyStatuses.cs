using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace lightweight.data.Model
{
    public class DutyStatuses
    {
        public DutyStatuses()
        {
            Duty = new Collection<Duty>();
        }
        public int Id { get; set; }
        public string Statue { get; set; }
        public ICollection<Duty> Duty { get; set; }
    }
}
