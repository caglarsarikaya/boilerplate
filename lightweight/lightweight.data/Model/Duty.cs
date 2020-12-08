using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace lightweight.data.Model
{
    public class Duty
    {

        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public virtual User User { get; set; }
        public virtual DutyStatuses DutyStatuses { get; set; }

    }
}
