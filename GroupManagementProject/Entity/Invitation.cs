using System;
using System.Collections.Generic;

namespace GroupManagementProject.Entity;

public partial class Invitation
{
    public int UserId { get; set; }

    public int GroupId { get; set; }

    public bool? Status { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
