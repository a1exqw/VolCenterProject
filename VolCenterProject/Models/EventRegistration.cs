using System;
using System.Collections.Generic;

namespace VolCenterProject.Models;

public partial class EventRegistration
{
    public int Id { get; set; }

    public int IdEvent { get; set; }

    public int IdVolunteer { get; set; }

    public DateOnly RegistrationDate { get; set; }

    public int IdStatus { get; set; }

    public virtual Event IdEventNavigation { get; set; } = null!;

    public virtual RegistrationStatus IdStatusNavigation { get; set; } = null!;

    public virtual User IdVolunteerNavigation { get; set; } = null!;
}
