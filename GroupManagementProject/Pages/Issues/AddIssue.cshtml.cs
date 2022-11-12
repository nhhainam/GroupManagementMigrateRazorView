using GroupManagementProject.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using Group = GroupManagementProject.Entity.Group;

namespace GroupManagementProject.Pages.Issues
{
    public class AddIssueModel : PageModel
    {
        GroupManagementContext context = new GroupManagementContext();
        public void OnGet(string projectid, string groupid)
        {
            var username = HttpContext.Session.GetString("username");
            User user = context.Users.SingleOrDefault(u => u.Username == username && u.Status == true);
            Group group = context.Groups.SingleOrDefault(g => g.GroupId == int.Parse(groupid));
            Project project = context.Projects.SingleOrDefault(p => p.ProjectId == int.Parse(projectid));
            List<Member> members = context.Members.Include(m => m.User).Where(m => m.GroupId == int.Parse(groupid) && m.State == 1 && m.Status == true).ToList();

            ViewData["user"] = user;
            ViewData["members"] = members;
            ViewData["group"] = group;
            ViewData["project"] = project;
        }

        public void OnPost(string projectid, string groupid, string title, DateTime duedate, DateTime startdate, string description, string content, string assignee)
        {
            var username = HttpContext.Session.GetString("username");
            User user = context.Users.SingleOrDefault(u => u.Username == username && u.Status == true);
            Group group = context.Groups.SingleOrDefault(g => g.GroupId == int.Parse(groupid));
            Project project = context.Projects.SingleOrDefault(p => p.ProjectId == int.Parse(projectid));
            List<Member> members = context.Members.Include(m => m.User).Where(m => m.GroupId == int.Parse(groupid) && m.State == 1 && m.Status == true).ToList();

            ViewData["user"] = user;
            ViewData["members"] = members;
            ViewData["group"] = group;
            ViewData["project"] = project;

            Issue issue = new Issue { Assignee = int.Parse(assignee), Content = content, Creator = user.UserId, Description = description, DueDate = duedate, ProjectId = int.Parse(projectid), StartDate = startdate, Title = title, State = 1, Status = true };
            context.Issues.Add(issue);
            context.SaveChanges();
            ViewData["MessAddIssue"] = "Add issue success!";
        }
    }
}
