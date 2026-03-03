using System;
using System.Collections.Generic;

namespace VolCenterProject.Models;

public partial class EventStatus
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
