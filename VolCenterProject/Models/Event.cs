using System;
using System.Collections.Generic;

namespace VolCenterProject.Models;

public partial class Event
{
    public int Id { get; set; }

    public string EventName { get; set; } = null!;

    public int Category { get; set; }

    public DateOnly EventDate { get; set; }

    public string Location { get; set; } = null!;

    public int VolunteersNeeded { get; set; }

    public int IdCoordinator { get; set; }

    public int IdStatus { get; set; }

    public virtual ICollection<EventRegistration> EventRegistrations { get; set; } = new List<EventRegistration>();

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual User IdCoordinatorNavigation { get; set; } = null!;

    public virtual EventStatus IdStatusNavigation { get; set; } = null!;
}
