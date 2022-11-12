﻿using System;
using System.Collections.Generic;

namespace GroupManagementProject.Entity;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public bool? Status { get; set; }

    public virtual ICollection<Member> Members { get; } = new List<Member>();
}
