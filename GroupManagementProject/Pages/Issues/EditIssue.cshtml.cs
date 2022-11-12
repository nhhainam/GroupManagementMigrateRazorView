using GroupManagementProject.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroupManagementProject.Pages.Issues
{
    public class EditIssueModel : PageModel
    {
        GroupManagementContext context = new GroupManagementContext();
        public void OnGet(string issueid, string groupid, string projectid)
        {
            var username = HttpContext.Session.GetString("username");
            User user = context.Users.SingleOrDefault(u => u.Username == username && u.Status == true);
            Issue issue = context.Issues.SingleOrDefault(i => i.IssueId == int.Parse(issueid) && i.Status == true);
            Group group = context.Groups.SingleOrDefault(g => g.GroupId == int.Parse(groupid));
            Project project = context.Projects.SingleOrDefault(p => p.ProjectId == int.Parse(projectid));


            ViewData["user"] = user;
            ViewData["issue"] = issue;
            ViewData["group"] = group;
            ViewData["project"] = project;
        }

        public void OnPost(string issueid, string groupid, string projectid, string title, DateTime duedate, DateTime startdate, string description, string content, string state)
        {
            var username = HttpContext.Session.GetString("username");
            User user = context.Users.SingleOrDefault(u => u.Username == username && u.Status == true);
            Issue issue = context.Issues.SingleOrDefault(i => i.IssueId == int.Parse(issueid) && i.Status == true);
            Group group = context.Groups.SingleOrDefault(g => g.GroupId == int.Parse(groupid));
            Project project = context.Projects.SingleOrDefault(p => p.ProjectId == int.Parse(projectid));


            ViewData["user"] = user;
            ViewData["issue"] = issue;
            ViewData["group"] = group;
            ViewData["project"] = project;

            if (title != null)
            {
                issue.Title = title;
            }
            if (description != null)
            {
                issue.Description = description;
            }
            if (content != null)
            {
                issue.Content = content;
            }
            issue.DueDate = duedate;
            issue.StartDate = startdate;
            issue.State = int.Parse(state);
            context.SaveChanges();
            ViewData["MessEditIssue"] = "Update succesfully!";

        }
    }
}
