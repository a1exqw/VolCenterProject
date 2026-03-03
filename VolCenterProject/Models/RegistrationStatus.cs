using System;
using System.Collections.Generic;

namespace VolCenterProject.Models;

public partial class RegistrationStatus
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<EventRegistration> EventRegistrations { get; set; } = new List<EventRegistration>();
}
