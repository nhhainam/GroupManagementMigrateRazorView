using System;
using System.Collections.Generic;

namespace GroupManagementProject.Entity;

public partial class Project
{
    public int ProjectId { get; set; }

    public string? ProjectName { get; set; }

    public string? Description { get; set; }

    public DateTime? Createdate { get; set; }

    public int? GroupId { get; set; }

    public bool? Status { get; set; }

    public virtual Group? Group { get; set; }

    public virtual ICollection<Issue> Issues { get; } = new List<Issue>();
}
