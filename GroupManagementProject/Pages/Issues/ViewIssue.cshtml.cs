using GroupManagementProject.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Group = GroupManagementProject.Entity.Group;

namespace GroupManagementProject.Pages.Issues
{
    public class ViewIssueModel : PageModel
    {
        GroupManagementContext context = new GroupManagementContext();
        public void OnGet(string projectid, string groupid)
        {
            var username = HttpContext.Session.GetString("username");
            User user = context.Users.SingleOrDefault(u => u.Username == username && u.Status == true);
            Member member = context.Members.SingleOrDefault(m => m.GroupId == int.Parse(groupid) && m.UserId == user.UserId && m.Status == true);
            Group group = context.Groups.SingleOrDefault(g => g.GroupId == int.Parse(groupid));
            Project project = context.Projects.SingleOrDefault(p => p.ProjectId == int.Parse(projectid));

            List<Issue> issues = context.Issues.Include(i => i.Project).Where(i => i.ProjectId == int.Parse(projectid) && i.Status == true).ToList();

            ViewData["user"] = user;
            ViewData["member"] = member;
            ViewData["group"] = group;
            ViewData["project"] = project;
            ViewData["issues"] = issues;
        }

        public void OnPostRemoveIssue(string projectid, string groupid, string issueid)
        {
            var username = HttpContext.Session.GetString("username");
            User user = context.Users.SingleOrDefault(u => u.Username == username && u.Status == true);
            Member member = context.Members.SingleOrDefault(m => m.GroupId == int.Parse(groupid) && m.UserId == user.UserId && m.Status == true);
            Group group = context.Groups.SingleOrDefault(g => g.GroupId == int.Parse(groupid));
            Project project = context.Projects.SingleOrDefault(p => p.ProjectId == int.Parse(projectid));
            Issue issue = context.Issues.SingleOrDefault(i => i.IssueId == int.Parse(issueid) && i.Status == true);
            issue.Status = false;
            context.SaveChanges();

            List<Issue> issues = context.Issues.Include(i => i.Project).Where(i => i.ProjectId == int.Parse(projectid) && i.Status == true).ToList();

            ViewData["user"] = user;
            ViewData["member"] = member;
            ViewData["group"] = group;
            ViewData["project"] = project;
            ViewData["issues"] = issues;

        }
    }
}
