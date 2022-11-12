﻿using System;
using System.Collections.Generic;

namespace GroupManagementProject.Entity;

public partial class MemberIssue
{
    public int UserId { get; set; }

    public int IssueId { get; set; }

    public bool? Status { get; set; }

    public virtual Issue Issue { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
