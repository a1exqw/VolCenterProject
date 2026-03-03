using System;
using System.Collections.Generic;

namespace VolCenterProject.Models;

public partial class User
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public int IdRole { get; set; }

    public string Email { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public virtual ICollection<EventRegistration> EventRegistrations { get; set; } = new List<EventRegistration>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
